using Microsoft.EntityFrameworkCore;
using NguyenDuyAn_241230651.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(options =>
{
    // Thông báo lỗi tiếng Việt khi nhập giá không phải là số
    options.ModelBindingMessageProvider.SetValueMustBeANumberAccessor(
        tenTruong => $"{tenTruong} phải là số");
    options.ModelBindingMessageProvider.SetAttemptedValueIsInvalidAccessor(
        (giaTri, tenTruong) => $"{tenTruong} phải là số");
});

builder.Services.AddDbContext<QLHangHoaContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("QLHangHoa")));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
