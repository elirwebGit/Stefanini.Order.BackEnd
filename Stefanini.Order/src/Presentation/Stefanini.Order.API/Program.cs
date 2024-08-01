using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using Stefanini.Order.IOC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo()
    {
        Version = "v1.1.0",
        Title = "Stefanini-Order",
        Description = "App Plataforma de venda de produto",
        TermsOfService = new Uri("https://www.uol.com.br"),
        Contact = new OpenApiContact { Email = "elirweb@gmail.com", Name = "Elir", Url = new Uri("https://www.uol.com.br") }


    }
        );

    

 

    var applicationBasePath = PlatformServices.Default.Application.ApplicationBasePath;
    var applicationName = PlatformServices.Default.Application.ApplicationName;
    var xmlDocumentPath = Path.Combine(applicationBasePath, $"{applicationName}.xml");

    if (File.Exists(xmlDocumentPath))
    {
        options.IncludeXmlComments(xmlDocumentPath);
    }


});
builder.Services.AddControllers();

// Configure the connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Register services
Bootstrap.Register(builder.Services);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
       builder =>
       {
           builder.AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader()
          .AllowAnyOrigin();
       });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(setup =>
    {
        setup.SwaggerEndpoint("/swagger/v1/swagger.json", "Stefanini");
    });
}

app.UseHttpsRedirection();




app.UseCors(x => x
           .AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader());

// Adiciona o middleware de roteamento
app.UseRouting();

// Adiciona o middleware para endpoints
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
