# Lab 5 - ViewComponent & lọc dữ liệu (đồng bộ / AJAX)

Làm tiếp từ `Lab4_Solution`. Chỉ project **MyWebApp** thay đổi, `DBFirstApp` giữ nguyên.

## Các file thêm / sửa so với Lab 4
| File | Nội dung |
|---|---|
| `ViewComponents/MajorViewComponent.cs` (mới) | ViewComponent lấy danh sách `Major`, trả về view `RenderMajor` |
| `Views/Shared/Components/Major/RenderMajor.cshtml` (mới) | Menu chuyên ngành: `<li id="MajorID">` (bản AJAX, bỏ controller/action trong thẻ `a`) |
| `Controllers/LearnerController.cs` | `Index(int? mid)` (lọc đồng bộ) + `LearnerByMajorID(int mid)` (trả PartialView cho AJAX) |
| `Views/Learner/LearnerTable.cshtml` (mới) | PartialView chứa bảng Learner, trả về khi gọi AJAX |
| `Views/Learner/Index.cshtml` | Gọi `Component.InvokeAsync("Major")`, `div#content` + `@section Scripts` (jQuery AJAX) |
| `Views/Shared/MyLayout.cshtml` | Thêm jQuery và `@RenderSection("Scripts", required: false)` |

## Cách chạy
1. Mở `MyWebApp/appsettings.json`, thay `YOUR_PASSWORD` bằng mật khẩu `sa` (như Lab 4).
2. Mở `MyWebApp.sln`, đặt `MyWebApp` làm Startup Project, chạy (F5) -> `/Learner`.
3. Bấm **IT / Economics / Mathematics** -> bảng chỉ còn Learner của ngành đó (không reload trang).

## Phần 1 - Load đồng bộ (nếu cần demo riêng)
Đổi `Views/Shared/Components/Major/RenderMajor.cshtml` thành bản đồng bộ:

```cshtml
@model IEnumerable<Major>
<ul class="nav">
    @foreach (var m in Model)
    {
        <li class="nav-item">
            <a asp-controller="Learner" asp-action="Index"
               asp-route-mid="@m.MajorID" class="nav-link">@m.MajorName</a>
        </li>
    }
</ul>
```
và comment lại `@section Scripts { ... }` trong `Views/Learner/Index.cshtml`. Khi đó mỗi lần bấm sẽ gọi `Learner/Index?mid=...` và load lại cả trang.
