using System;
using LFC.BLL;
using LFC.BLL.Contracts;
using LFC.BLL.Interfaces;
using LFC.BLL.Services;
using LFC.Web;
using LFC.DAL;
using LFC.DAL.Contracts;
using LFC.DAL.Models;
using LFC.DAL.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Seq("http://localhost:5341")
    .CreateLogger();

Log.Information("Starting up");
try 
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddTransient<IAuthService, AuthService>();
    builder.Services.AddTransient<ICourseService, CourseService>();
    
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    builder.Services
        .AddDbContext<LFCDbContext>(options =>
            options.UseNpgsql(connectionString)
            )
        .AddScoped(typeof(IRepository<>), typeof(Repository<>));
    builder.Services.AddDatabaseDeveloperPageExceptionFilter();
    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

    builder.Services.ConfigureApplicationCookie(options =>
    {
        //options.AccessDeniedPath = "/Identity/Account/AccessDenied";
        options.Cookie.HttpOnly = true;
        options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
        //options.LoginPath = "/Identity/Account/Login";
        //options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
        options.SlidingExpiration = true;
    });
    builder.Services.AddDefaultIdentity<User>(options =>
        {
            options.Password.RequiredUniqueChars = 0;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireDigit = false;
            options.Password.RequiredLength = 1;
            options.Password.RequireUppercase = false;
        })
        .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<LFCDbContext>();
    // builder.Services.AddAuthorization(options =>
    // {
    //     options.AddPolicy("ElevatedRights", policy =>
    //         policy.RequireRole("Teacher", "Student"));
    // });
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
    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    app.MapRazorPages();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    Log.Information("Shut down complete");
    Log.CloseAndFlush();
}

