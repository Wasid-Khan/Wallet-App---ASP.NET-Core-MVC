using Expense_Tracker.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//DIs
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder
    .Configuration.GetConnectionString("DevConnection")));

//Register syncfunction license
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBMAY9C3t2XVhhQlJHfVtdXGVWfFN0QHNYfVRycF9DZEwxOX1dQl9mSX1ScURhW3lfeXFSR2M=");

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
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");

app.Run();
