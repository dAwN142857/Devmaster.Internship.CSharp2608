using Microsoft.AspNetCore.Mvc.ModelBinding;
using NetCoreMVCLAB5_BaiTuLam.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(options =>
{
    // Việt hóa các thông báo lỗi mặc định của model binding
    var p = options.ModelBindingMessageProvider;
    p.SetValueMustNotBeNullAccessor(_ => "Vui lòng nhập giá trị cho trường này.");
    p.SetMissingBindRequiredValueAccessor(f => $"Thiếu giá trị cho '{f}'.");
    p.SetMissingKeyOrValueAccessor(() => "Vui lòng nhập giá trị.");
    p.SetAttemptedValueIsInvalidAccessor((v, f) => $"Giá trị '{v}' không hợp lệ cho '{f}'.");
    p.SetUnknownValueIsInvalidAccessor(f => $"Giá trị không hợp lệ cho '{f}'.");
    p.SetValueIsInvalidAccessor(v => $"Giá trị '{v}' không hợp lệ.");
    p.SetValueMustBeANumberAccessor(f => $"'{f}' phải là một số (ví dụ: 150000).");
    p.SetNonPropertyAttemptedValueIsInvalidAccessor(v => $"Giá trị '{v}' không hợp lệ.");
    p.SetNonPropertyUnknownValueIsInvalidAccessor(() => "Giá trị không hợp lệ.");
    p.SetNonPropertyValueMustBeANumberAccessor(() => "Giá trị phải là một số.");
});

// Kho dữ liệu trong bộ nhớ (Category + Product)
builder.Services.AddSingleton<DataStore>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();   // phục vụ wwwroot/products
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Products}/{action=Index}/{id?}");

app.Run();
