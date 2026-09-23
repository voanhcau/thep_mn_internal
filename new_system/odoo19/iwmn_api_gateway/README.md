# IWMN API Gateway

Addon nay cung cap method JSON-2 `iwmn.api.gateway/call_as_user` cho
`api_core_system`. API key xac thuc tai khoan dich vu; thao tac dich duoc chay
bang `with_user(user_id)` de Odoo ap dung ACL, record rule va ghi dung
`create_uid`/`write_uid` cua nguoi thuc hien.

## Cai dat

1. Cai addon `iwmn_api_gateway` tren Odoo 19.
2. Tao mot tai khoan bot rieng, khong dung tai khoan Administrator.
3. Gan nhom **IWMN API Gateway Caller** cho tai khoan bot.
4. Tao API key cho bot va luu key vao secret `Odoo__ApiKey` cua IntegrationHub.
5. Cau hinh `Odoo__BaseUrl` va, neu mot host co nhieu database,
   `Odoo__Database`.

Khong can gan quyen tren cac model nghiep vu cho bot. Quyen nghiep vu duoc kiem
tra theo `user_id` duoc truyen vao. Cac method private va cac method thay doi
environment nhu `sudo`, `with_user`, `with_env` bi chan.
