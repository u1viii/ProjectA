using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ProjectA.API.Extensions;
using ProjectA.Application;
using ProjectA.Application.Features.Commands.Categories.CreateCategory;
using ProjectA.Infrastructure;
using ProjectA.Persistance;
using Serilog;
using Serilog.Context;
using Serilog.Sinks.MSSqlServer;
using System.Collections.ObjectModel;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddFluentValidation(config=>config.RegisterValidatorsFromAssemblyContaining<CreateCategoryCommandValidator>());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddInfrastructureServices();
builder.Services.AddPersistanceServices();
builder.Services.AddApplicationServices();
builder.Services.AddCors(opt =>
{
    opt.AddDefaultPolicy(policy =>
    {
        //policy.AllowAnyHeader();
        //policy.AllowAnyOrigin();
        //policy.AllowAnyMethod();
        policy.WithOrigins("http://127.0.0.1:5500/,https://127.0.0.1:5500/").AllowAnyHeader().AllowAnyOrigin();
    });
    //opt.AddPolicy("CorsPolicy",
    //        builder => builder.AllowAnyOrigin()
    //            .AllowAnyMethod()
    //            .AllowAnyHeader());
});
ColumnOptions options = new ColumnOptions();
    Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Error()
    .WriteTo.Console()
    .WriteTo.File(Path.Combine("Logs", "Log-"+DateTime.UtcNow.ToString("dd-MM-yyyy")+".txt"))
    .WriteTo.MSSqlServer(builder.Configuration.GetConnectionString("MSSql"),
        sinkOptions: new MSSqlServerSinkOptions
        {
            TableName = "Logs",
            AutoCreateSqlTable = true
        }, columnOptions: new ColumnOptions()
        {
            AdditionalColumns = new Collection<SqlColumn>()
            {
                new SqlColumn
                {
                    ColumnName = "Username", PropertyName="Username", DataType = System.Data.SqlDbType.VarChar
                }
            }
        })
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Host.UseSerilog();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt => 
    {
        opt.TokenValidationParameters = new()
        {
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidAudience = builder.Configuration["Token:Audience"],
            ValidIssuer = builder.Configuration["Token:Issuer"],
            LifetimeValidator = (notBefore, expires, securityToken, validationParameters) => securityToken != null ? DateTime.UtcNow < expires : false,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SigningKey"])),
            NameClaimType = ClaimTypes.Name
        };
    });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseConfigureExceptionHandler<Program>(app.Services.GetRequiredService<ILogger<Program>>());
app.UseCors();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.Use(async (context, next) =>
{
    var username = context.User.Identity.IsAuthenticated ? context.User.Identity.Name: null;
    LogContext.PushProperty("Username",username);
    await next();
});
app.MapControllers();

app.Run();

