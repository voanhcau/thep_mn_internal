# IntegrationHub API

ASP.NET Core integration layer between Odoo 19 and the legacy SQL Server 2016 ERP.

## Implemented scope

- `master.read`: implemented for `dbo.R81BAREMPHOI` and the allowlisted, paged
  generic master-data sync API used by Odoo 19, plus `dbo.fn_CalBaremBo` weight lookup.

`GET /api/v1/master-data/bar-weight?ma_vt=BD...&so_bo=1&so_cay_le=2`
returns the legacy function's `weightKg` (decimal). Odoo rounds it to whole kg
for portal orders. Grant the IntegrationHub SQL principal `EXECUTE` on
`dbo.fn_CalBaremBo` with `database/007_grant_fn_CalBaremBo_execute.sql`.
- `finance.read`: implemented for `dbo.vw_Tin_Dung`.
- `orders.write`: implemented for replacing one portal order's `dbo.R04CTDH` rows.
- `orders.read`, `delivery.read`, `documents.read`, `sync.admin`:
  authorization policies and module boundaries only.

## Portal order write-back

`PUT /api/v1/orders/customer-orders/{headerId}/r04ctdh` requires the
`orders.write` scope and a JSON body `{ "rows": [...] }`. The API validates all
row IDs, replaces only that order's rows inside a SQL transaction, and returns
`headerId` plus `rowCount`. Odoo submits this snapshot after its transaction
commits and retries failed transfers every five minutes. Grant the IntegrationHub
SQL user `SELECT`, `INSERT`, and `DELETE` on `dbo.R04CTDH` using
`database/006_grant_r04ctdh_order_sync.sql` before enabling the flow.
- `odoo.call`: implemented for authenticated, audited Odoo 19 model calls.

## Generic Odoo method API

The legacy system calls IntegrationHub with its normal OAuth2 bearer token. The
token must contain the dedicated `odoo.call` scope. IntegrationHub then calls
Odoo 19's JSON-2 API using a secret API key belonging to a technical service
account. Install the `new_system/odoo19/iwmn_api_gateway` addon and assign only
its **IWMN API Gateway Caller** group to that service account.

The gateway executes the target method with `with_user(userId)`. Odoo therefore
applies that user's access rights and record rules, and standard audit fields
such as `create_uid` and `write_uid` contain the originating Odoo user. Supplying
`userId` as context alone would not impersonate that user.

Create one `iwmn.r81dmbl` record (the underscore alias `iwmn_r81dmbl` is also
accepted):

```http
POST /api/v1/odoo/methods/call
Authorization: Bearer <JWT containing odoo.call>
Content-Type: application/json

{
  "model": "iwmn.r81dmbl",
  "method": "create",
  "userId": 42,
  "vals": {
    "ma_dt": "1071130",
    "so_bl": "BL-0001",
    "tien_bao_lanh": 100000000,
    "ngay_bd_bl": "2026-09-15",
    "ngay_kt_bl": "2027-09-15",
    "ma_dt_bl": "2VIB013",
    "ma_data": "A01",
    "ghi_chu": "Created by the legacy system",
    "lock": false,
    "tien_bao_lanh_nt": 0,
    "ngay_begin": "2026-09-15",
    "ngay_end": "2027-09-15",
    "so_bl_goc": "BL-0001",
    "ma_tte": "VND",
    "ty_gia": 1,
    "ngay_ph": "2026-09-15 00:00:00"
  }
}
```

A successful create returns the new Odoo record ID:

```json
{
  "success": true,
  "model": "iwmn.r81dmbl",
  "method": "create",
  "userId": 42,
  "result": {
    "id": 12345,
    "ids": [12345]
  }
}
```

Update a record by passing `recordIds`; `vals` becomes the first positional
argument of the method:

```json
{
  "model": "iwmn.r81dmbl",
  "method": "write",
  "userId": 42,
  "recordIds": [12345],
  "vals": {"ghi_chu": "Updated"}
}
```

For another public model method, use `args` for positional arguments and
`kwargs` for named arguments. `vals` and `args` are mutually exclusive:

```json
{
  "model": "iwmn.r81dmbl",
  "method": "search_read",
  "userId": 42,
  "args": [[['so_bl', '=', 'BL-0001']]],
  "kwargs": {"fields": ["so_bl", "ghi_chu"], "limit": 10},
  "context": {"lang": "vi_VN"}
}
```

Private methods and environment-changing methods such as `sudo`, `with_user`
and `with_env` are rejected. Other calls run with the target user's normal Odoo
permissions. An Odoo rejection is returned as HTTP `502` with the upstream HTTP
status and safe Odoo error type; a disabled or unreachable connection returns
HTTP `503`.

Configure the outbound Odoo connection only through environment variables or a
secret store:

```text
Odoo__Enabled=true
Odoo__BaseUrl=https://odoo.company.vn
Odoo__Database=production_database
Odoo__ApiKey=<service-account API key>
Odoo__TimeoutSeconds=30
```

`Odoo__Database` can be empty when the hostname uniquely selects one database.
The API key remains required even on an internal network: it authenticates only
the IntegrationHub service account and is not exposed to the legacy caller.

## R81BAREMPHOI endpoints

```http
GET /api/v1/master-data/billet-barems?page=1&pageSize=50
GET /api/v1/master-data/billet-barems?billetType=120x120
GET /api/v1/master-data/billet-barems?effectiveFrom=2019-01-01
GET /api/v1/master-data/billet-barems/1
Authorization: Bearer <JWT containing master.read>
```

The API deliberately exposes business-oriented JSON fields while the SQL adapter
contains the legacy mapping:

| SQL Server | JSON |
|---|---|
| `Ident00` | `id` |
| `Loai_Phoi` | `billetType` |
| `Ngay_Ap` | `effectiveDate` |
| `Barem` | `barem` |

## Credit-limit endpoint

```http
GET /api/v1/finance/credit-limits?ma_dt=1000001&ngay_hl=2026-08-20
Authorization: Bearer <JWT containing finance.read>
```

Both query parameters are required. The endpoint returns rows from
`dbo.vw_Tin_Dung` where `Ngay_Kt >= ngay_hl` and `Ma_Dt = ma_dt`.

## Generic master-data synchronization API

The shared endpoint exposes only the 75 MSSQL master tables registered in
`MasterDataEntityCatalog`; a caller cannot submit an arbitrary table name. It
reads the real SQL Server primary key and returns it as `keyFields`, including
composite keys.

List supported entities:

```http
GET /api/v1/master-data/sync/catalog
Authorization: Bearer <JWT containing master.read>
```

Read one page:

```http
GET /api/v1/master-data/sync/r81dmdt?page=1&page_size=500
Authorization: Bearer <JWT containing master.read>
```

Đồng bộ danh mục hợp đồng `R81DMHD` dùng cùng endpoint:

```http
GET /api/v1/master-data/sync/r81dmhd?page=1&page_size=500
Authorization: Bearer <JWT containing master.read>
```

Khóa chính trả về trong `keyFields` là `ma_hd`; Odoo dùng khóa này để cập nhật
bản ghi đã có hoặc tạo bản ghi mới.

Đồng bộ danh mục công trình `R81DMCTRINH`:

```http
GET /api/v1/master-data/sync/r81dmctrinh?page=1&page_size=500
Authorization: Bearer <JWT containing master.read>
```

Khóa chính trả về trong `keyFields` là `ma_ctrinh`.

Đồng bộ danh mục phụ lục công trình `R81DMPLCTRINH`:

```http
GET /api/v1/master-data/sync/r81dmplctrinh?page=1&page_size=500
Authorization: Bearer <JWT containing master.read>
```

Khóa chính trả về trong `keyFields` là `ma_plctrinh`.

`page` starts at `1`; `page_size` must be from `1` to `1000`. Continue requesting
the next page while `hasMore=true`. JSON property names are lower-case MSSQL
column names, matching the generated Odoo master fields in most cases:

```json
{
  "entity": "r81dmdt",
  "keyFields": ["ma_dt"],
  "page": 1,
  "pageSize": 500,
  "hasMore": true,
  "data": [
    {
      "ma_dt": "1000001",
      "ten_dt": "Tên khách hàng",
      "ident00": 1769
    }
  ]
}
```

Examples of discovered keys are `ident00` for `r81baremphoi`, `ma_dt` for
`r81dmdt`, and the composite key `thang,nam` for `r81dmlaisuat`. Grant the API
database principal read access with
`database/004_grant_master_data_sync_read.sql`.

## Aggregate credit-limit endpoint

API dữ liệu dashboard hạn mức gọi stored procedure
`dbo.sp_rptSODTC01_Check` và yêu cầu Bearer token có scope `finance.read`:

```http
GET /api/v1/finance/credit-limit-summaries?ngay_ct=2026-08-20&ma_dt=1071017&is_trieu=1&is_th=0&language_id=V&ma_dvcs=A01
Authorization: Bearer <access_token>
```

Request trên tương đương:

```sql
EXEC dbo.sp_rptSODTC01_Check '2026-08-20', '1071017', 'V', 'A01';
```

| Query parameter | Bắt buộc | Mặc định | Stored procedure parameter | Mô tả |
|---|---:|---|---|---|
| `ngay_ct` | Có | - | `@Ngay_Ct` | Ngày báo cáo, dùng định dạng `yyyy-MM-dd`. |
| `ma_dt` | Có | - | `@Ma_Dt` | Mã đối tượng/khách hàng, tối đa 20 ký tự. |
| `is_trieu` | Không | `1` | - | Giữ tương thích API; store dashboard không sử dụng. |
| `is_th` | Không | `0` | - | Giữ tương thích API; store dashboard không sử dụng. |
| `language_id` | Không | `V` | `@Language_ID` | Ngôn ngữ báo cáo, tối đa 10 ký tự. |
| `ma_dvcs` | Không | `A01` | `@Ma_DvCs` | Mã đơn vị cơ sở, tối đa 10 ký tự. |

API trả toàn bộ các dòng nghiệp vụ có `Stt` và `Bold` từ result set. Dòng
`Bold = 1` là số tổng hợp; dòng `Bold = 0` là dữ liệu chi tiết dùng để drill-down
trên dashboard. Các trường được chuẩn hóa thành JSON camelCase như `sequence`,
`content`, `amount`, `documentDate`, `quantity`, `deliveryOrderQuantity`,
`paymentMethod`, `warehouseCode`, `vehicleNumber`, `bargeNumber`,
`deliveryOrderNumber`, `bold` và `level`. Không có dữ liệu thì trả HTTP `200 OK`
với `[]`.

Ví dụ cURL:

```bash
curl --request GET \
  'http://localhost:9119/api/v1/finance/credit-limit-summaries?ngay_ct=2026-08-20&ma_dt=1071017&is_trieu=1&is_th=0&language_id=V&ma_dvcs=A01' \
  --header 'Accept: application/json' \
  --header 'Authorization: Bearer <access_token>'
```

Ví dụ PowerShell, sử dụng `$accessToken` đã lấy từ `/connect/token`:

```powershell
Invoke-RestMethod `
  -Method Get `
  -Uri 'http://localhost:9119/api/v1/finance/credit-limit-summaries?ngay_ct=2026-08-20&ma_dt=1071017&is_trieu=1&is_th=0&language_id=V&ma_dvcs=A01' `
  -Headers @{ Authorization = "Bearer $accessToken" }
```

Một phần response mẫu:

```json
[
  {
    "partnerCode": "1071017",
    "sequence": 0,
    "content": "I.1 Nợ quá hạn",
    "amount": 14482131642,
    "documentDate": null,
    "quantity": 0,
    "deliveryOrderQuantity": 0,
    "bold": true,
    "level": 1,
    "customerName": "Tên khách hàng"
  }
]
```

Các trường tiền tệ trong response phụ thuộc `is_trieu`: khi bằng `1`, procedure
quy đổi các trường được hỗ trợ sang đơn vị triệu đồng. Tài khoản SQL của API
cần quyền `EXECUTE` trên procedure; có thể dùng script
`database/005_grant_sp_rptSODTC01_Check_execute.sql`.

## Credit-limit detail endpoint

API chi tiết gọi `dbo.sp_rptSODTC01_Check` và lọc `Level` ở phía server. Chỉ
chấp nhận bốn nhóm dùng trên dashboard: `4` (Hóa đơn), `6` (Lệnh duyệt chờ
giao hàng), `10` (PXK/NMHH) và `12` (Ký gửi).

```http
GET /api/v1/finance/credit-limit-details?ngay_ct=2026-08-20&ma_dt=1000001&level=4&language_id=V&ma_dvcs=A01
Authorization: Bearer <access_token>
```

Request tương đương việc chạy:

```sql
EXEC dbo.sp_rptSODTC01_Check '2026-08-20', '1000001', 'V', 'A01';
```

Response giữ nguyên tên cột của result set để không làm mất các cột nghiệp vụ
động của báo cáo:

```json
{
  "level": 4,
  "columns": ["So_Ct", "Ngay_Ct", "Tien", "Level"],
  "items": [
    {"So_Ct": "HD001", "Ngay_Ct": "2026-08-20T00:00:00", "Tien": 1250000, "Level": 4}
  ]
}
```

Chạy `database/005_grant_sp_rptSODTC01_Check_execute.sql` để cấp quyền thực thi
cho database principal của IntegrationHub.

## Configuration

Never commit the real connection string or private keys. Configure these values
with environment variables:

```text
Authentication__Authority=https://identity.example.com/realms/integration
Authentication__Audience=integration-api
LegacyDatabase__ConnectionString=Server=...;Database=...;User ID=integration_api;Password=...;Encrypt=True;TrustServerCertificate=False
```

The JWT must be issued for the configured audience. Policies read space-separated
OAuth scopes from the standard `scope` claim.

## Built-in client-credentials token issuer

The API can optionally issue its own RS256 access tokens. This mode is intended
for server-to-server integrations. The private key is used only to sign tokens;
the matching public key is used by the API to validate them and is published as
JWKS.

Do not commit either a production client secret or a private key. Generate an
RSA key pair in the deployment secret store. One OpenSSL example is:

```bash
openssl genpkey -algorithm RSA -pkeyopt rsa_keygen_bits:3072 -out token-signing-private.pem
openssl rsa -pubout -in token-signing-private.pem -out token-signing-public.pem
```

Enable and configure the issuer through secret-backed environment variables:

```text
TokenIssuer__Enabled=true
TokenIssuer__Issuer=https://api.company.vn
TokenIssuer__Audience=integration-api
TokenIssuer__KeyId=integration-signing-2026-01
TokenIssuer__PrivateKeyPath=/run/secrets/token-signing-private.pem
TokenIssuer__PublicKeyPath=/run/secrets/token-signing-public.pem
TokenIssuer__AccessTokenLifetimeMinutes=30
TokenIssuer__Clients__0__ClientId=odoo-integration
TokenIssuer__Clients__0__ClientSecret=<long random value from the secret store>
TokenIssuer__Clients__0__AllowedScopes__0=finance.read
TokenIssuer__Clients__0__AllowedScopes__1=master.read
```

The issuer refuses to start if the keys are missing, malformed, or do not form
the same RSA pair. `AccessTokenLifetimeMinutes` must be exactly 30. Local token
validation uses zero clock skew and also rejects a JWT whose declared lifetime
is longer than 1,800 seconds.

### Huong dan doi tac lay access token

Token endpoint su dung OAuth 2.0 Client Credentials, danh cho ket noi
server-to-server. Moi doi tac duoc cap rieng `client_id`, `client_secret` va danh
sach `scope` duoc phep. Doi tac khong can va khong duoc nhan private key.

#### 1. Thong tin request

```http
POST https://api.company.vn/connect/token
Content-Type: application/x-www-form-urlencoded
Accept: application/json
```

Body phai gui theo dang `x-www-form-urlencoded`, **khong gui JSON**:

| Tham so | Bat buoc | Gia tri/vi du | Mo ta |
|---|---:|---|---|
| `grant_type` | Co | `client_credentials` | Gia tri co dinh, phai viet dung nhu vi du. |
| `client_id` | Co | `odoo-integration` | Ma ung dung do don vi quan tri API cap cho doi tac. |
| `client_secret` | Co | `...` | Bi mat ung dung do don vi quan tri API cap; khong ghi vao log hay source code. |
| `scope` | Co | `finance.read` | Quyen muon su dung. Nhieu quyen duoc ngan cach bang mot dau cach, vi du `finance.read master.read`. Moi quyen phai duoc cap cho `client_id`. |

Vi du cURL day du (khuyen nghi dung `--data-urlencode` de ma hoa an toan cac
ky tu dac biet trong `client_secret`):

```bash
curl --request POST 'https://api.company.vn/connect/token' \
  --header 'Accept: application/json' \
  --header 'Content-Type: application/x-www-form-urlencoded' \
  --data-urlencode 'grant_type=client_credentials' \
  --data-urlencode 'client_id=odoo-integration' \
  --data-urlencode 'client_secret=<client-secret-do-doi-tac-duoc-cap>' \
  --data-urlencode 'scope=finance.read'
```

Gia tri body tuong duong sau khi URL-encode:

```text
grant_type=client_credentials&client_id=odoo-integration&client_secret=<client-secret>&scope=finance.read
```

Tren Postman:

1. Chon method `POST` va URL `https://api.company.vn/connect/token`.
2. Tai tab **Headers**, them `Accept: application/json`.
3. Tai tab **Body**, chon **x-www-form-urlencoded**.
4. Them bon key `grant_type`, `client_id`, `client_secret`, `scope` theo bang tren.
5. Bam **Send**. Khong chon **raw/JSON** va khong gui cac tham so tren query string.

#### 2. Response thanh cong

API tra HTTP `200 OK`:

```json
{
  "access_token": "eyJhbGciOiJSUzI1NiIsImtpZCI6Li4u",
  "token_type": "Bearer",
  "expires_in": 1800,
  "scope": "finance.read"
}
```

| Truong | Y nghia |
|---|---|
| `access_token` | JWT duoc ky bang RS256, dung de goi cac API nghiep vu. |
| `token_type` | Luon la `Bearer`. |
| `expires_in` | So giay token con hieu luc tinh tu luc cap; luon la `1800` giay (30 phut). |
| `scope` | Cac quyen thuc te da duoc cap trong token. |

Doi tac nen luu token tam thoi trong bo nho/cache va tai su dung trong cac
request tiep theo. Khong nen goi `/connect/token` lai cho tung request. Can xin
token moi khi token sap het han; token da het 30 phut se bi API tu choi.

#### 3. Dung access token goi API nghiep vu

Gui token trong HTTP header, dung dinh dang `Bearer`, co mot dau cach giua
`Bearer` va token:

```http
Authorization: Bearer <access_token>
```

Vi du goi API han muc tin dung:

```bash
curl --request GET \
  'https://api.company.vn/api/v1/finance/credit-limits?ma_dt=1000001&ngay_hl=2026-08-20' \
  --header 'Accept: application/json' \
  --header 'Authorization: Bearer <access_token-nhan-tu-connect-token>'
```

`access_token` phai co scope `finance.read`. Neu khong gui token, token sai chu
ky, sai issuer/audience hoac da het han, API tra `401 Unauthorized`. Neu token
hop le nhung khong co scope ma endpoint yeu cau, API tra `403 Forbidden`.

#### 4. Response loi khi xin token

| HTTP | `error` | Nguyen nhan thuong gap |
|---:|---|---|
| `400` | `unsupported_grant_type` | `grant_type` khac `client_credentials` hoac bi bo trong. |
| `400` | `invalid_scope` | `scope` bi bo trong, sai ten hoac chua duoc cap cho client. |
| `401` | `invalid_client` | `client_id`/`client_secret` sai, thieu hoac khong khop. |
| `404` | - | Chuc nang cap token noi bo dang tat (`TokenIssuer:Enabled=false`) hoac sai URL. |
| `415` | - | Gui sai `Content-Type`; endpoint chi nhan `application/x-www-form-urlencoded`. |

Mau response loi:

```json
{
  "error": "invalid_client",
  "error_description": "Client authentication failed."
}
```

Khong tu dong gui lai lien tuc khi nhan `invalid_client` hoac `invalid_scope`.
Doi tac can kiem tra lai thong tin duoc cap hoac lien he don vi quan tri API.

Public metadata is available at:

```text
GET /.well-known/oauth-authorization-server
GET /.well-known/openid-configuration
GET /.well-known/jwks.json
```

When `TokenIssuer:Enabled=false`, the existing external
`Authentication:Authority` configuration remains active instead.

## Chạy và debug localhost bằng Visual Studio

Profile `IntegrationHub.Api` được cấu hình chạy tại:

```text
http://localhost:9119
```

Các giá trị local nằm trong `src/IntegrationHub.Api/.env`. ASP.NET Core không
tự đọc `.env`, vì vậy project có một bộ nạp chỉ hoạt động khi
`ASPNETCORE_ENVIRONMENT=Development`. Biến môi trường thật của tiến trình luôn
được ưu tiên hơn giá trị trong file. `.env` và thư mục `.secrets` đã bị Git bỏ
qua; không commit secret hoặc private key.

### 1. Chuẩn bị lần đầu

Nếu máy dev chưa có `.env`, sao chép file mẫu rồi chỉnh các giá trị local:

```powershell
Copy-Item `
  '.\src\IntegrationHub.Api\.env.localhost.example' `
  '.\src\IntegrationHub.Api\.env'
```

Mở PowerShell tại thư mục `new_system/api_core_system` và tạo cặp khóa RSA local:

```powershell
.\tools\generate-local-rsa-keys.ps1
```

Script tạo hai file sau:

```text
src/IntegrationHub.Api/.secrets/local-token-private.pem
src/IntegrationHub.Api/.secrets/local-token-public.pem
```

Nếu hai file đã tồn tại, script chủ động dừng để không ghi đè khóa đang dùng.

Mở `src/IntegrationHub.Api/.env` và sửa chuỗi kết nối SQL Server:

```text
LegacyDatabase__ConnectionString="Server=YOUR_SQL_SERVER,1433;Database=YOUR_DATABASE;User ID=YOUR_USER;Password=YOUR_PASSWORD;Encrypt=True;TrustServerCertificate=True"
```

Các tài khoản test mặc định chỉ dành cho localhost:

```text
client_id=odoo-local
client_secret=LOCAL_ONLY_odoo_secret_9119_change_me
scope=finance.read
```

Có thể đổi `client_secret` trong `.env`; Odoo/Postman phải gửi đúng giá trị mới.

### 2. Chạy bằng Visual Studio

1. Mở `IntegrationHub.slnx` trong Visual Studio.
2. Đặt `IntegrationHub.Api` làm **Startup Project**.
3. Chọn launch profile **IntegrationHub.Api**, không chọn IIS Express.
4. Đặt breakpoint nếu cần, sau đó nhấn **F5**.
5. Kiểm tra cửa sổ Output có dòng `Now listening on: http://localhost:9119`.
6. Truy cập `http://localhost:9119/health/live`; kết quả thành công là HTTP 200
   với trạng thái `Healthy`.

Nếu ứng dụng báo không tìm thấy `.env`, kiểm tra profile có biến
`INTEGRATIONHUB_ENV_FILE=.env` và working directory đang là thư mục
`src/IntegrationHub.Api`.

### 3. Xin token tại localhost

PowerShell:

```powershell
$tokenResponse = Invoke-RestMethod `
  -Method Post `
  -Uri 'http://localhost:9119/connect/token' `
  -ContentType 'application/x-www-form-urlencoded' `
  -Body @{
    grant_type  = 'client_credentials'
    client_id   = 'odoo-local'
    client_secret = 'LOCAL_ONLY_odoo_secret_9119_change_me'
    scope       = 'finance.read'
  }

$tokenResponse
$accessToken = $tokenResponse.access_token
```

Kết quả phải có `token_type=Bearer` và `expires_in=1800`. Có thể kiểm tra riêng
bằng cURL:

```bash
curl --request POST 'http://localhost:9119/connect/token' \
  --header 'Content-Type: application/x-www-form-urlencoded' \
  --data-urlencode 'grant_type=client_credentials' \
  --data-urlencode 'client_id=odoo-local' \
  --data-urlencode 'client_secret=LOCAL_ONLY_odoo_secret_9119_change_me' \
  --data-urlencode 'scope=finance.read'
```

### 4. Gọi API hạn mức tín dụng bằng token

Tiếp tục trong cùng cửa sổ PowerShell:

```powershell
$headers = @{ Authorization = "Bearer $accessToken" }

Invoke-RestMethod `
  -Method Get `
  -Uri 'http://localhost:9119/api/v1/finance/credit-limits?ma_dt=1000001&ngay_hl=2026-08-20' `
  -Headers $headers
```

Nếu `/connect/token` chạy được nhưng API hạn mức lỗi khi truy vấn, kiểm tra lại
`LegacyDatabase__ConnectionString`, quyền `SELECT` trên `dbo.vw_Tin_Dung`, tên
database và khả năng kết nối tới SQL Server.

### 5. Ví dụ gọi từ Odoo/Python

Ví dụ tối thiểu dùng thư viện `requests`:

```python
import requests

base_url = "http://localhost:9119"

token_response = requests.post(
    f"{base_url}/connect/token",
    data={
        "grant_type": "client_credentials",
        "client_id": "odoo-local",
        "client_secret": "LOCAL_ONLY_odoo_secret_9119_change_me",
        "scope": "finance.read",
    },
    timeout=30,
)
token_response.raise_for_status()
access_token = token_response.json()["access_token"]

credit_response = requests.get(
    f"{base_url}/api/v1/finance/credit-limits",
    params={"ma_dt": "1000001", "ngay_hl": "2026-08-20"},
    headers={"Authorization": f"Bearer {access_token}"},
    timeout=30,
)
credit_response.raise_for_status()
credit_limits = credit_response.json()
```

Nên cache `access_token` trong Odoo và xin lại trước khi hết 1.800 giây, không
xin token mới cho từng bản ghi hoặc từng request.

`localhost` luôn là máy/container đang chạy Odoo:

- Odoo chạy trực tiếp trên cùng máy Windows: dùng `http://localhost:9119`.
- Odoo chạy trong Docker: `localhost` là container Odoo, không phải Windows.
  Cần cấu hình API lắng nghe trên interface phù hợp và dùng
  `http://host.docker.internal:9119`; cấu hình mặc định hiện tại chỉ mở loopback
  để an toàn cho test local.
- Odoo chạy trên máy khác: không thể dùng `localhost`; cần HTTPS, firewall và
  hostname/IP dành cho môi trường tích hợp.

Việc gọi server-to-server từ Odoo không phụ thuộc CORS. CORS chỉ liên quan khi
JavaScript trong trình duyệt gọi API từ một origin khác.

### 6. Trình tự đặt breakpoint để debug

1. `TokenController.Create`: nhận form từ Odoo/Postman.
2. `AccessTokenService.Issue`: kiểm tra client secret, scope và tạo JWT.
3. `RsaKeyStore.Load`: đọc cặp khóa RSA ở lần sử dụng đầu tiên.
4. `CreditLimitsController.Search`: nhận `ma_dt`, `ngay_hl` sau khi Bearer token
   đã được middleware xác thực.
5. `CreditLimitService.SearchAsync`: xử lý nghiệp vụ ứng dụng.
6. `CreditLimitReadRepository.SearchAsync`: chạy câu SQL có tham số vào
   `dbo.vw_Tin_Dung`.

Khi debug request nghiệp vụ, nếu breakpoint tại controller không được gọi:

- HTTP `401`: token thiếu, sai, hết hạn hoặc không đúng issuer/audience.
- HTTP `403`: token hợp lệ nhưng thiếu `finance.read`.
- HTTP `400`: thiếu/sai `ma_dt` hoặc `ngay_hl`.
- HTTP `500`: xem exception và kiểm tra kết nối/cấu trúc dữ liệu SQL Server.

## Build

The repository targets .NET 10 LTS:

```bash
dotnet restore IntegrationHub.slnx
dotnet build IntegrationHub.slnx -c Release
dotnet publish src/IntegrationHub.Api/IntegrationHub.Api.csproj -c Release -o deploy/publish
```

Then copy `.env.example` to `.env`, provide secrets through the deployment secret
store, and run `docker compose -f deploy/docker-compose.yml up -d`.

## Design rules

1. Odoo never connects directly to SQL Server.
2. SQL identifiers are fixed in Infrastructure; request values are parameters.
3. Read and write permissions are separate OAuth policies.
4. Legacy tables are not mapped wholesale with EF Core.
5. New modules must follow the existing Domain/Application/Infrastructure/API boundary.
