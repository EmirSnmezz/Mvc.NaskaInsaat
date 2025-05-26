using NaskaInsaat.Controllers.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<LocalizationService>();
var app = builder.Build();
app.UseDeveloperExceptionPage();
app.UseStaticFiles();
app.MapControllerRoute(name: "", pattern:"{controller=Home}/{action=Index}");

app.Run();
