using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RestaurantBrowsingAndOrderingsSystem.Helpers;
using RestaurantSystemDataAccess.Data;
using RestaurantSystemDataAccess.Services;
using RestaurantSystemModels.Models;
var builder = WebApplication.CreateBuilder(args);
// http://mng.bz/5jdB change Pk in Identity Table to any Type 
// http://mng.bz/Xd61 extend Identityuser class  
// send Email http://mng.bz/6gBo  
// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// -  my servcie db
//-----------------------------------------------------------
builder.Services.AddScoped<IRestaurantService, RestaurantService>();
builder.Services.AddScoped<IMenuService, MenuService>();
builder.Services.AddScoped<IMealService, MealService>();
// ----------------------------------------------------------
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

///Authorization For Admin , Meal , Menu Controllers 
builder.Services.AddAuthorizationBuilder().AddPolicy
    (
        //Plocicy name  
        "AdminUser" , builder=> builder.RequireClaim
        (StaticData.UserTypeClaim , StaticData.AdminClaim )
    );

// ----------------------------
// ----------------------------//*--><

builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    //options.SignIn.RequireConfirmedAccount = true;
    options.Lockout.AllowedForNewUsers = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = true;
})
.AddEntityFrameworkStores<ApplicationDbContext>();


builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
 // notes from Chapter 24 
// generates a challenge response if the user is unauthenticated 401 
// generates a forbid    response if the user not Have claims 403 
app.UseAuthorization();
/// user --> C - action1 , 2 , 3 10  
/// 
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
