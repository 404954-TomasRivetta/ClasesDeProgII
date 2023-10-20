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
 Crear proyecto Web API sobre .Net 5.0 utilizando IDE Visual Studio. La API
debe contener:
    * Un controlador llamado CashController que tenga como atributo de
    clase una lista de objetos Moneda. Cada moneda contiene: Nombre y
    valor en pesos de dicha moneda. Por ejemplo: Nombre: {“Dolar”,
    Valor:180}, {“Peso argentino”, Valor:1}
    * 1 método GET: que permita obtener todos los objetos Moneda creados
    hasta el momento.
    * 1 método GET/1: con un parámetro que sea el nombre de la moneda a
    consultar. Si no la encuentra deberá informar con un mensaje: “Moneda
    no registrada”
    * 1 método POST que permita crear una moneda y agregarla a la lista.
    Como respuesta este método devuelve el objeto creado.
    * Probar la API utilizando POSTMAN.
 */