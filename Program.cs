using tareaAPIS_v1.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlServer<Dbtareas901Context>(builder.Configuration.GetConnectionString("conexion"));
builder.Services.AddCors(p =>
{
    p.AddPolicy("NUEVAPOLITICA", app =>
    {
        app.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader(); // Permite cualquier encabezado
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//ACTIVACION DE POLITICAS
app.UseCors("NUEVAPOLITICA");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
