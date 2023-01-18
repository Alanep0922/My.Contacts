using System.Reflection;
using Backend.Middlewares;
using Backend.Models;
using Backend.Repository;
using Backend.Services;
using Backend.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DaoContext Configuration, EF Code First and Migrations
builder.Services.AddDbContext<DaoContext>();
var daoContext = builder.Services.BuildServiceProvider().GetService<DaoContext>();
daoContext.Database.Migrate();


builder.Services.AddTransient<ContactRepository>();
builder.Services.AddTransient<ContactService>();

builder.Services.AddTransient<IValidator<Contact>, ContactValidator>();
builder.Services.AddFluentValidationAutoValidation()
    .AddFluentValidationClientsideAdapters();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
