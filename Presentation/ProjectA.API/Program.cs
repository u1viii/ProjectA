using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ProjectA.Application;
using ProjectA.Application.Features.Commands.Categories.CreateCategory;
using ProjectA.Infrastructure;
using ProjectA.Persistance;
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
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SigningKey"]))
        };
    });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

