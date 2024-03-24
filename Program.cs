using OgrenciBilgiSistemi.Database;
using OgrenciBilgiSistemi.Interfaces;
using OgrenciBilgiSistemi.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DataContext>();
builder.WebHost.UseUrls("http://192.168.1.2:7276");
//builder.WebHost.UseUrls("http://10.74.90.197:7276");
//builder.WebHost.UseUrls("http://172.16.165.124:7276");

//Session Ekleme
builder.Services.AddHttpContextAccessor();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddScoped<IKullanici, KullaniciRepository>();
var app = builder.Build();
app.UseHttpsRedirection();
app.UseRouting();

// Routingten sonra session çaðýrýlýr.




app.UseStaticFiles(new StaticFileOptions
{
    RequestPath = "/wwwroot"
});
app.UseAuthentication();
app.UseSession();
app.MapControllerRoute("main", "{controller=Login}/{action=Login}/{id?}");
app.Run();