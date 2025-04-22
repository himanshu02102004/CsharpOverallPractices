using CRUDTASK_CODE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("dbcon")));

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "CRUD API",
        Version = "1.0.0"  // You can specify a proper version here
    });

    // Explicitly setting the OpenAPI version (optional)
    c.AddServer(new OpenApiServer { Url = "/" });
});


builder.Services.AddSwaggerGenNewtonsoftSupport(); // Only once

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    try
    {
        var db = scope.ServiceProvider.GetRequiredService<ApiContext>();
        db.Database.EnsureCreated();
    }
    catch (Exception ex)
    {
        Console.WriteLine("❌ DB Init Error: " + ex.Message);
    }
}


if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "CRUD API v1");
        c.RoutePrefix = "swagger"; // or "" to put Swagger at root
    });
}

app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();
