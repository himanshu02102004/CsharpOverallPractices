
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MVC_PART1.Models;
using MVC_PART1.Services;
using MVC_PART1;
using System.Text;
using MVC_PART1.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.AddSession();
builder.Services.AddSingleton<JwtService>();
builder.Services.AddScoped<IAccountServices, AccountServices>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("dbcs")));


////builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
////    .AddCookie(options =>
////    {
////        options.LoginPath = "/Account/Login";
////        options.AccessDeniedPath = "/Account/AccessDenied";
////       options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // ? recommended
////        options.SlidingExpiration = true;                  // ? keeps session alive
////    });



builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

builder.Services.AddAuthorization();



if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//app.Use(async (context, next) =>
//{
//    var token = context.Request.Cookies["AuthToken"];
//    Console.WriteLine("Middleware token: " + token);
//    if (!string.IsNullOrEmpty(token))
//    {
//        context.Request.Headers.Authorization = "Bearer " + token;
//    }

//    await next();
//});

//app.UseMiddleware<TokenMiddleware>();


builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

app.UseSession();


app.UseSession();


app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
