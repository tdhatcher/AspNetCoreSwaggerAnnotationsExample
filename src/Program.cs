using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SwaggerAnnotationsExample.Data;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddValidatorsFromAssemblyContaining<Program>();
builder.Services.AddDbContext<MemoryContext>(options =>
{
    options.LogTo(Console.WriteLine);
    options.EnableSensitiveDataLogging();
    options.UseInMemoryDatabase("memorydatabase", b => b.EnableNullChecks());
});
builder.Services.AddControllers().AddJsonOptions(options => 
{
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();
    options.DescribeAllParametersInCamelCase();
    options.UseInlineDefinitionsForEnums();
    options.SwaggerDoc("v1", new OpenApiInfo 
    { 
        Title = "Api with Swagger Example",
        Version = "v1",
        Description = "This is the stragest and most useless api in the world that came about through late night experimentation with all sorts of .NET",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Todd Hatcher",
            Email = "bad@gmail.com",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "MIT License",
            Url = new Uri("https://www.mit.edu/~amini/LICENSE.md")
        }
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

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
