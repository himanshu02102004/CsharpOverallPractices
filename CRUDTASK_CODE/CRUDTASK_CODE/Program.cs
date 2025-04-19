
using CRUDTASK_CODE.Models;


////// Add services to the container.




builder.Services.AddDbContext<ApiContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("dbcon")));


////// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
          .AddNewtonsoftSupport();
////// Add services to the container.
builder.Services.AddControllers()
   .AddNewtonsoftJson();

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);



var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    app.UseDeveloperExceptionPage();
   app.UseSwagger();
   app.UseSwaggerUI(c =>
   {
      c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");
  });
}

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApiContext>();
  db.Database.EnsureCreated(); // or db.Database.Migrate();
}

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();




