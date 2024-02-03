using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using JobAppSystem.Data;
using JobAppSystem.Areas.Identity.Data;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("JobAppSystemDbContextConnection") ?? throw new InvalidOperationException("Connection string 'JobAppSystemDbContextConnection' not found.");

builder.Services.AddDbContext<JobAppSystemDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<Perdoruesi>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<JobAppSystemDbContext>();

builder.Services.AddScoped<IKonkursiRepository, KonkursiRepository>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();

