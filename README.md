# Project Title

## Giới thiệu

Đây là một dự án ví dụ sử dụng .NET 8 và Angular 18. Dự án bao gồm một ứng dụng web với các tính năng quản lý sản phẩm, bao gồm thêm, sửa, xóa và tìm kiếm sản phẩm. Đăng nhập, đăng ký đăng xuất.
Sử dụng JWT để xác thực người dụng , ngăn truy cập vào trang sản phẩm nếu người dụng chưa đăng nhập . Authorize API Product chống kẻ tấn công sử dụng các công cụ test như PostMan

## Công Nghệ Sử Dụng

- **Backend**: .NET 8 với CQRS và MediaTr
- **Frontend**: Angular 18
- **Cơ sở dữ liệu**: SQL Server

## Cài Đặt và Cấu Hình

### Backend (.NET 8)

1. **Cài đặt .NET 8 SDK**

   Để phát triển và chạy dự án .NET, bạn cần cài đặt .NET 8 SDK từ [trang chính thức của .NET](https://dotnet.microsoft.com/download/dotnet/8.0).

2. **Tải mã nguồn**

   ```bash
   git clone https://github.com/tribui228/BaiTestPhuHung.git
   cd BaiTestPhuHung

3. **Angular**
cài đặt gói : npm install -g @angular/cli và npm install
chạy ứng dụng : ng serve

3. **Backend**
gen tự động database : Tool ->nuget package manager ->  package manager consonle -> gõ lệnh add-migration v2 -> gõ lệnh update-database

cấu hình setting : chạy bằng IIS Express với port 44385 và Angular với port 4200 . Cấu hình connectstring cho program.cs cho phù hợp với máy
