using Api.Configurations;
using Api.Exceptions;
using Application.Configurations;
using Persistence.Configurations;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApiServices();
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);

builder.Services.AddProblemDetails();




var app = builder.Build();
app.UseStatusCodePages();  // [1]
app.UseExceptionHandler(); // [2]

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();

app.MapControllers();

app.Run();
