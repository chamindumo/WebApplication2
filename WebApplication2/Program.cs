using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;
using Serilog;
using WebApplication2;
using WebApplication2.Middelware;
using WebApplication2.Repositery;
using WebApplication2.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using WebApplication2.Service;
using ikvm.runtime;
using WebApplication2.Profiles;
using sun.awt;
using System.Configuration;
using WebApplication2.Endpoints_Routs_Api;

var builder = WebApplication.CreateBuilder(args);
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
//builder.Services.AddTransient<BasicAuthHandler>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAutoMapper(typeof(Books), typeof(Product));





builder.Services.AddTransient<IBookRepositery, BookRepository>(); 
builder.Services.AddTransient< BookRepository>();


builder.Services.AddTransient<IProductRepositery, ProductRepositery>();
builder.Services.AddTransient<ProductRepositery>();

builder.Services.AddTransient<IBookService, BookServices1>();
builder.Services.AddTransient<IProductService, ProductService1>();
builder.Services.AddTransient<ProductService1>();
builder.Services.AddTransient<BookServices1>();

//builder.Services.AddTransient<GlobaleExceptionHandlingMiddelware>();




var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseMiddleware<BasicAuthHandler>("Test");
//app.UseMiddleware<GlobaleExceptionHandlingMiddelware>();

app.UseHttpsRedirection();

app.Books();

app.Product();






app.Run();
