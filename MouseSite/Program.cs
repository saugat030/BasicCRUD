using Microsoft.EntityFrameworkCore;
using Mouse.DataAccess.Data;
using Mouse.DataAccess.Repository;
using Microsoft.AspNetCore.Identity;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MouseDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("dbcs")));

builder.Services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<MouseDbContext>();
builder.Services.AddRazorPages();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())//launch settins.json ma hunxa yo
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You
    //
    //
    //
    // may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

app.Run();
