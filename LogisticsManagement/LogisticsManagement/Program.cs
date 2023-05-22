using LogisticsManagement.CustomValidations;
using LogisticsManagement.Models;
using LogisticsManagement.Models.Authentication;
using LogisticsManagement.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IPersonnelRepository, PersonnelRepository>();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(builder.Configuration.GetSection(key: "ConnectionStrings:DefaultConnection").Value));
builder.Services.AddIdentity<AppUser, AppRole>(e =>
{
    e.Password.RequiredLength = 5; 
    e.Password.RequireNonAlphanumeric = false; 
    e.Password.RequireLowercase = false; 
    e.Password.RequireUppercase = false; 
    e.Password.RequireDigit = false;
    e.User.RequireUniqueEmail = true; //Unique email addresses
    e.User.AllowedUserNameCharacters = "abcçdefghiýjklmnoöpqrsþtuüvwxyzABCÇDEFGHIÝJKLMNOÖPQRSÞTUÜVWXYZ0123456789-._@+";
}).AddPasswordValidator<CustomPasswordValidation>().AddUserValidator<CustomUserValidation>().AddErrorDescriber<CustomIdentityErrorDescriber>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(e => { 
    e.LoginPath = new PathString("/user/login"); 
    e.Cookie = new CookieBuilder() {
        Name = "LogisticSystemCookie", //cookie name
        HttpOnly = false, //prevent access to cookie from client-side
        //Expiration = TimeSpan.FromMinutes(2), //expritaion time for cookie
        SameSite = SameSiteMode.Lax, //prevent sending unnecessary cookies for some requests
        SecurePolicy = CookieSecurePolicy.Always //accessible on https
    };
    e.SlidingExpiration = true; 
    e.ExpireTimeSpan = TimeSpan.FromMinutes(2);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseStatusCodePages();
app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
