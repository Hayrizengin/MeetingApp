var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(); // mvc şablonu oluşturmaya çalışıyoruz

var app = builder.Build();
//mvc
// rest api
//razor pages

app.UseStaticFiles();
app.UseRouting();

// {controller=Home}/{action=Index}/id?
//app.MapDefaultControllerRoute(); // burada route kısmını projeye ekledik
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);


app.Run();
