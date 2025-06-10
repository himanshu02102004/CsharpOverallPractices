using System;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

using CRUD_TASK_WEB;
using CRUD_TASK_WEB.Models;
using CRUD_TASK_WEB.Services;
using CRUD_TASK_WEB.Services.IServices;
using CRUD_TASK_WEB.NewServices;
using CRUD_TASK_WEB.NewServices.INewServices;
using CRUD_TASK_WEB.NewServices2;
using CRUD_TASK_WEB.NewServices2.INewServices2;

var builder = WebApplication.CreateBuilder(args);

// ---------------------- Services Configuration ----------------------

builder.Services.AddDbContext<ApiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("dbcon")));

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductServices, ProductServices>();
builder.Services.AddScoped<IOrderServices, OrderServices>();
builder.Services.AddScoped<IUserService, UserServices>();

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ---------------------- JWT Authentication ----------------------

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

var app = builder.Build();

// ---------------------- Middleware Configuration ----------------------

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();

// ---------------------- Start Server ----------------------

app.Run();

// ---------------------- OPTIONAL: Basic Auth Client Test ----------------------
// If you still want to test an external API using Basic Auth, you can do it in a separate method like this:

/*
await TestBasicAuth();

async Task TestBasicAuth()
{
    var url = "http://localhost:5139";
    var username = "himu";
    var password = "password";

    var client = new HttpClient
    {
        BaseAddress = new Uri(url)
    };

    var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);

    try
    {
        var response = await client.GetAsync("/Login");

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine(content);
        }
        else
        {
            Console.WriteLine("Error: " + response.StatusCode);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Exception: " + ex.Message);
    }
}
*/
