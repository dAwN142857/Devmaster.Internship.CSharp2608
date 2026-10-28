# Lab 4 - Entity Framework (Code First & Database First)

Solution gồm 2 project (.NET 10, ASP.NET Core MVC):

| Project | Nội dung |
|---|---|
| `MyWebApp` | Phần I – Code First: Models, SchoolContext, DbInitializer, CRUD bảng Learner |
| `DBFirstApp` | Phần II – Database First: Models/DbContext sinh từ DB `School`, controller + views scaffold |

## Cách chạy
1. Cài .NET 10 SDK (hoặc VS 2026 có workload ASP.NET) và SQL Server (bật SQL Authentication, enable `sa`, restart server).
2. Mở `appsettings.json` của mỗi project, thay `YOUR_PASSWORD` bằng mật khẩu `sa`.
   (Hoặc làm đúng đề: chuột phải *Connected Services* → Add → SQL Server Database → tên `SchoolContext`, lưu vào Secrets.json.)
3. Mở `MyWebApp.sln`, đặt `MyWebApp` làm Startup Project, chạy (F5) → vào `/Learner`.
   DbInitializer tự tạo DB `School` và dữ liệu mẫu.
4. Đặt `DBFirstApp` làm Startup Project, chạy → vào `/Learners` (dùng lại DB `School` đã tạo ở bước 3).

## Chạy lại Scaffold bằng tay (Database First)
Trong Package Manager Console (Default project: DBFirstApp):

    Scaffold-DbContext "Data Source=(local);Initial Catalog=School;Persist Security Info=True;User ID=sa;Password=...;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -Project DBFirstApp -OutputDir Models -Force

Các file trong `DBFirstApp/Models` đã được viết sẵn tương đương kết quả lệnh này.
