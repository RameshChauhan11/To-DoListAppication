using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using To_DoListAppication.Repository;
using To_DoListAppication.ToDoDBContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ISinInService, SinInService>();
builder.Services.AddScoped<IWorkRecordSevice,workRecordService>();
builder.Services.AddScoped<Icheckuser,CheckUser>();
//enable sql server
builder.Services.AddDbContext<TODoDBContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("defaults"));
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/home/Login";
        
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=login}/{action=login}/{id?}");

app.Run();

