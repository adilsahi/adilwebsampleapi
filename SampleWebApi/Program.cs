using Microsoft.AspNetCore.Builder;
using SampleWebApi.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add Services
builder.Services.AddCustomServices();
// Add Db Context
builder.Services.AddCustomDbContext(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
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

