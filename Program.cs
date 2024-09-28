using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PMSWebApi.Data;
using PMSWebApi.Controllers;
using PMSWebApi.Filters;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PMSWebApiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PMSWebApiContext") ?? throw new InvalidOperationException("Connection string 'PMSWebApiContext' not found.")));
// Add AutoMapper service
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
