using Microsoft.EntityFrameworkCore;
using Vehicle_Configurator.Application.Interfaces;
using Vehicle_Configurator.Application.Services;
using Vehicle_Configurator.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;
using DinkToPdf.Contracts;
using DinkToPdf;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 43))
    )
);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    }); 
builder.Services.AddSwaggerGen();


// Add and configure the CORS policy.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowSpecificOrigin",
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:8080")
                                .AllowAnyHeader()
                                .AllowAnyMethod();

                      });
});

// Configure JWT Authentication
var jwtKey = builder.Configuration["Jwt:Key"];
if (string.IsNullOrEmpty(jwtKey))
{
    throw new InvalidOperationException("JWT Key not found in configuration.");
}

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
        };
    });

builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

builder.Services.AddScoped<PdfService>();

// Register the JwtService for dependency injection
builder.Services.AddScoped<JwtService>();
builder.Services.AddScoped<InvoiceGenerationService>();
builder.Services.AddScoped<ISegmentRepository, SegmentService>();
builder.Services.AddScoped<IManufacturerRepository, ManufacturerService>();
builder.Services.AddScoped<IModelRepository, ModelService>();
builder.Services.AddScoped<ISgMfgMasterRepository, SgMfgMasterService>();
builder.Services.AddScoped<IVehicleDetailRepository, VehicleDetailService>();
builder.Services.AddScoped<IComponentRepository, ComponentService>();
builder.Services.AddScoped<IAlternateComponentMasterRepository, AlternateComponentMasterService>();
builder.Services.AddScoped<IInvoiceDetailRepository, InvoiceDetailService>();
builder.Services.AddScoped<IInvoiceHeaderRepository, InvoiceHeaderService>();
builder.Services.AddScoped<IUserRepository, UserService>();
builder.Services.AddScoped<EmailService>();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}

var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
Console.WriteLine($"ASPNETCORE_ENVIRONMENT = {env}");


app.UseStaticFiles();

app.UseHttpsRedirection();

// Use the CORS policy here, before any controllers are mapped.
app.UseCors("AllowSpecificOrigin");

// Add authentication middleware
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
