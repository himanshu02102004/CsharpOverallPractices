using CRUDTASK_CODE.Filters;
using CRUDTASK_CODE.Models;


using Microsoft.EntityFrameworkCore;

using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddDbContext<UserContrext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("dbcon")));

builder.Services.AddDbContext<ApiContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("dbcon")));





builder.Services.AddControllers(opt =>
{
    opt.Filters.Add(new MyLogging());

});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();







builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");
    });
}


using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<UserContrext>();
    db.Database.EnsureCreated(); // or db.Database.Migrate();
}

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();


