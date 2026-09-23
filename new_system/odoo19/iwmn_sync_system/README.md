# IWMN Master Data Synchronization

Addon `iwmn_sync_system` đồng bộ một master-data được chọn từ MSSQL qua
IntegrationHub API vào PostgreSQL của Odoo 19.

## Luồng xử lý

1. Quản trị viên chọn một đối tượng tại **IWMN > Đồng bộ hệ thống**.
2. Odoo gọi `POST /connect/token` với scope `master.read`.
3. Odoo gọi từng trang `GET /api/v1/master-data/sync/{entity}`.
4. API chỉ cho phép 75 entity trong allowlist, đọc khóa chính thật từ SQL Server
   và trả tên trường JSON dạng chữ thường tương ứng model Odoo.
5. Odoo tìm theo `keyFields` do API trả về. Có bản ghi thì `write`; chưa có thì
   `create`. Không dùng PostgreSQL `id` để so với ID của MSSQL.
6. Toàn bộ một lần chạy nằm trong savepoint: nếu lỗi, dữ liệu của lần chạy đó
   được rollback và màn hình lưu trạng thái thất bại.

## Cài đặt

Đảm bảo thư mục `new_system/odoo19` nằm trong `addons_path`, sau đó cập nhật danh
sách ứng dụng và cài theo thứ tự:

1. `iwmn_base`
2. `iwmn_sync_system`

Ví dụ dòng lệnh Odoo:

```bash
odoo-bin -d <database> -i iwmn_base,iwmn_sync_system --stop-after-init
```

Khi đã cài module, nâng cấp bằng:

```bash
odoo-bin -d <database> -u iwmn_sync_system --stop-after-init
```

## Cấu hình

Vào **Thiết lập > Đồng bộ master-data** và nhập:

| Trường | Localhost mẫu |
|---|---|
| Địa chỉ IntegrationHub | `http://localhost:9119` |
| Client ID | `odoo-local` |
| Client secret | giá trị trong `.env` của IntegrationHub |
| Thời gian chờ | `60` giây |

Client trên IntegrationHub phải có scope `master.read`. Nếu Odoo chạy trong
Docker thì `localhost` là container Odoo; cần dùng địa chỉ host phù hợp như
`http://host.docker.internal:9119` và cấu hình IntegrationHub lắng nghe ngoài
loopback cho riêng môi trường phát triển.

## Sử dụng

1. Vào **IWMN > Đồng bộ hệ thống**.
2. Tạo một bản ghi đồng bộ.
3. Chọn **Đối tượng master**, ví dụ `R81DMDT`, `R81DMVT`, `R81DMHD`, `R81DMCTRINH` hoặc `R81DMPLCTRINH`.
4. Giữ kích thước trang `500`, hoặc chọn từ `1` đến `1000`.
5. Lưu và nhấn **Đồng bộ**.
6. Kiểm tra số bản ghi đã nhận, đã tạo, đã cập nhật, đã bỏ qua và lỗi gần nhất.

Chỉ người thuộc nhóm **Settings / Administration** (`base.group_system`) có
quyền nhìn menu, cấu hình secret và chạy đồng bộ.

## Quyền SQL Server

Chạy `api_core_system/database/004_grant_master_data_sync_read.sql` sau khi thay
database principal nếu cần. Script chỉ cấp `SELECT` trên đúng 75 bảng thuộc
allowlist, không cấp `SELECT` toàn schema `dbo`.

## API response

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

Ví dụ khóa theo từng loại bảng:

- `R81BAREMPHOI`: `ident00`
- `R81DMDT`: `ma_dt`
- `R81DMLAISUAT`: khóa ghép `thang`, `nam`
