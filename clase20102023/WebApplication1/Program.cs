using System.Security.Cryptography;

var builder = WebApplication.CreateBuilder(args);

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


/*
    Problema 4.1:
        Crear proyecto Web API sobre .Net 5.0 utilizando IDE Visual Studio. La API
        debe exponer un único método GET que retorne la fecha actual: número, día de la
        semana, mes y año.
        * Definir un modelo: Fecha con las datos antes mencionados
        * Probar la API mediante la herramienta integrada Swagger.
*/