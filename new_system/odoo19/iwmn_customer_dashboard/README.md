# IWMN Customer Credit Dashboard

Module Odoo 19 hiển thị dashboard dư nợ và hạn mức tại `/my`, là trang đầu tiên
của người dùng portal sau khi đăng nhập.

## Cấu hình

1. Cài `iwmn_base`, `portal`, `website`, sau đó cài module này.
2. Vào **Thiết lập > Dashboard khách hàng** và nhập URL IntegrationHub,
   `client_id`, `client_secret`, mã đơn vị cơ sở và timeout.
3. Mở liên hệ công ty của tài khoản portal, chọn **Khách hàng ERP (hạn mức)**.
   Dashboard dùng `ma_dt` của bản ghi này khi gọi
   `GET /api/v1/finance/credit-limit-summaries`.

OAuth token được lấy và cache ở server Odoo. Secret và token không được đưa vào
HTML hoặc JavaScript phía trình duyệt.

## Cache dữ liệu dashboard

Dashboard lưu kết quả hạn mức theo từng khách hàng ERP và ngày báo cáo trong
model `iwmn.customer.credit.dashboard.cache`. Lần mở đầu tiên trong ngày gọi
IntegrationHub và ghi cache; các lần mở `/my` tiếp theo chỉ đọc database Odoo.
Nút **Làm mới** gọi `/my?refresh=1`, ép lấy lại dữ liệu API, cập nhật cache rồi
chuyển về `/my` để tránh việc F5 tiếp tục gọi API. Nếu IntegrationHub lỗi trong
lúc làm mới, dashboard tiếp tục hiển thị bản cache hiện có kèm cảnh báo.

## Đơn đặt hàng trên portal

- `/my/orders`: danh sách và trạng thái đơn của khách hàng đang đăng nhập.
- Module phụ thuộc và kế thừa controller `sale` để chủ động ghi đè hai route
  chuẩn `/my/orders` và `/my/orders/<id>`; tránh trang đơn bán hàng mặc định của
  Odoo bắt request trước trang đơn đặt hàng portal của TMN.
- Phạm vi đơn hàng portal được nhận diện thống nhất theo người tạo portal,
  toàn bộ contact thuộc cùng `commercial_partner_id`, hoặc cùng khách hàng ERP.
  Cách này giúp các đơn cũ gắn vào contact con vẫn xuất hiện tại `/my/orders`.
- `/my/orders/new`: nhập đơn theo 5 bước, hỗ trợ nhiều dòng hàng, xe và xà lan;
  có thể lưu nháp hoặc gửi TMN xác nhận.
- Sau khi gửi xác nhận, trang chi tiết đơn hiển thị nút **In phiếu đặt hàng PDF**.
  Phiếu lấy thông tin khách hàng, phương tiện, hàng hóa và yêu cầu từ đơn hiện tại;
  phần xác nhận và chữ ký của TMN được để trống theo mẫu BM – 04 QT-KD-02/09.
  Khách chỉ tải được phiếu của đơn thuộc phạm vi portal của mình đã gửi xác nhận.
- Khách hàng chỉ chọn một trong 6 khu vực giao/nhận: Phú Mỹ, Cần Thơ, Phú Quốc,
  Đà Nẵng, Nha Trang hoặc Dĩ An - Bình Dương. Kho cụ thể là thông tin nội bộ do
  PKD phân bổ, kể cả trường hợp một đơn được tách sang nhiều kho.
- Thép cây nhập **tổng số cây**. Hệ thống tìm barem theo size/mác/chiều dài rồi
  tự quy đổi thành số bó, số cây lẻ và kg. Thép cuộn chỉ nhập khối lượng kg.
- Ô sản phẩm tìm gần đúng đồng thời theo `ma_vt` hoặc `ten_vt`, chỉ trong nhóm
  `THEPCANDAI` và trả tối đa 10 kết quả. Khách phải chọn một kết quả gợi ý;
  size, mác thép, chiều dài và dạng sản phẩm được lấy trực tiếp từ `R81DMVT`.
- Danh sách hàng hóa dùng giao diện giỏ hàng thu gọn, có ảnh sản phẩm, vùng cuộn
  riêng và bảng tổng hợp số mặt hàng, số cây, kg, giá tham khảo. Nhân viên có thể
  tải ảnh riêng tại trường **Hình ảnh trên portal** của danh mục `R81DMVT`; nếu
  chưa có ảnh, hệ thống dùng hình minh họa thép cây/thép cuộn mặc định.
- Danh mục **Hợp đồng portal** và **Công trình portal** là lớp dữ liệu trung gian
  để import/đồng bộ từ `R81DMHD`, `R81DMCTRINH` và `R81DMPLCTRINH`; portal tự
  lọc theo khách hàng ERP đang gắn với tài khoản.
- Phương tiện bắt buộc chọn xe, xà lan hoặc cả hai. Khi gửi đơn phải có biển số
  xe/số xà lan phù hợp. Khách được sửa phương tiện trước khi đến cổng và được
  hủy đơn cho đến trước khi phương tiện ra cổng.
- Đơn giá khách nhập chỉ mang tính tham khảo. PKD cập nhật giá và tồn kho chính
  thức ở màn hình nội bộ; số quyết định giá không được đưa ra portal.
- Nhân viên nội bộ xử lý tại menu **Đơn hàng Portal > Đơn hàng khách nhập**,
  cập nhật trạng thái, liên kết hóa đơn và file CNXX.
- Nhân viên cập nhật số SOCP, kho phân bổ, trạng thái tại cổng, tồn kho, giá
  chính thức, hóa đơn điện tử và CNXX tại màn hình nội bộ.

Các bản ghi portal luôn gắn với `commercial_partner_id` của tài khoản. Các route
chi tiết/chỉnh sửa đều kiểm tra khách hàng sở hữu đơn trước khi đọc hoặc ghi.
# Đồng bộ đơn hàng sang SQL Server

Khối lượng thép cây được tính qua IntegrationHub `GET /api/v1/master-data/bar-weight`
(scope `master.read`), gọi trực tiếp `dbo.fn_CalBaremBo`. Odoo vẫn quy đổi số
cây sang bó/cây lẻ theo `Num_Bars` của vật tư và làm tròn kết quả API đến kg
nguyên. Cần cấp `EXECUTE` trên hàm SQL bằng script
`database/007_grant_fn_CalBaremBo_execute.sql` của IntegrationHub.

Khi đơn chuyển từ nháp sang “Chờ TMN xác nhận”, Odoo lưu đơn trước rồi gửi toàn bộ
các dòng sang `PUT /api/v1/orders/customer-orders/{id}/r04ctdh` của IntegrationHub.
API thay thế tập dòng theo `ID_Web_Header` trong một transaction; gửi lại không tạo
dòng trùng. Nếu kết nối lỗi, đơn vẫn ở Odoo với trạng thái **Lỗi đồng bộ** và cron
thử lại mỗi 5 phút. Cấp thêm scope `orders.write` cho client của Odoo trên
IntegrationHub. Triển khai endpoint mới và chạy script cấp quyền
`database/006_grant_r04ctdh_order_sync.sql` trước khi thử gửi đơn.
