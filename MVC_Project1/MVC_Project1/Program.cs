using MVC_Project1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var provider = builder.Services.BuildServiceProvider();
var config = provider.GetRequiredService<IConfiguration>();
builder.Services.AddDbContext<StudentDbContext>(item => item.UseSqlServer(config.GetConnectionString("mvc1")));






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

app.UseRouting();


app.UseEndpoints(endpoint =>
{
    endpoint.MapGet("/Home", async (context) =>
    {
        await context.Response.WriteAsync("This is Home page .... GET  ");

    });

    endpoint.MapPut("/Home", async (context) =>
    {
        await context.Response.WriteAsync("this is home page ......PUT");
    });



});




app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
