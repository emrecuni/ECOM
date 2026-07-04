using System.Net.Mail;
using System.Text;
using System.Text.Json.Serialization;
using ECOM.API.Data;
using ECOM.API.Infrastructure.Interfaces;
using ECOM.API.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.MaxDepth = 128;
    });

// Ayrıca HTTP JSON options için de:
builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.SerializerOptions.MaxDepth = 128;
});
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Bunu ekle:
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.MaxDepth = 128;
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen(options =>
//{
//    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
//    {
//        In = ParameterLocation.Header,
//        Description = "JWT token girin: Bearer {token}",
//        Name = "Authorization",
//        Type = SecuritySchemeType.ApiKey
//    });

//    options.AddSecurityRequirement(new OpenApiSecurityRequirement
//    {
//        {
//            new OpenApiSecurityScheme
//            {
//                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
//            },
//            Array.Empty<string>()
//        }
//    });
//});
builder.Services.AddMemoryCache();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
        };
    });
builder.Services.AddSingleton(new Iyzipay.Options
{
    ApiKey = builder.Configuration["Iyzico:ApiKey"],
    SecretKey = builder.Configuration["Iyzico:SecretKey"],
    BaseUrl = builder.Configuration["Iyzico:BaseUrl"]
});
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ISmtpService, SmptService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<SmtpClient>(provider =>
{
    var config = provider.GetRequiredService<IConfiguration>();
    var smtpClient = new SmtpClient
    {
        Host = config["Smtp:Host"]!,
        Port = int.Parse(config["Smtp:Port"] ?? "25"),
        EnableSsl = bool.Parse(config["Smtp:EnableSsl"] ?? "false"),
        Credentials = new System.Net.NetworkCredential(
            config["Smtp:SenderMail"],
            config["Smtp:Password"])
    };
    return smtpClient;
});
//builder.Services.AddAuthorization(options =>
//{
//    options.FallbackPolicy = new AuthorizationPolicyBuilder()
//        .RequireAuthenticatedUser()
//        .Build(); // varsayılan: her şey kapalı
//});

var app = builder.Build();

app.Use(async (context, next) =>
{
    Console.WriteLine($"Path: {context.Request.Path}");
    Console.WriteLine($"Auth Header: {context.Request.Headers["Authorization"]}");
    await next();
    Console.WriteLine($"Response: {context.Response.StatusCode}");
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
    app.MapOpenApi();
    app.MapScalarApiReference(); // https://localhost:{PORT}/scalar/v1
}

app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();