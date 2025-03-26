using Microsoft.EntityFrameworkCore;
using APIGestorTareas.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("GestorTareasBD"));

builder.Services.AddCors(options =>
{
    options.AddPolicy("conexionFrontend",
        policy => policy.WithOrigins("http://localhost:4200") // Cambia según el host del frontend
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

builder.Services.AddControllers()
    .AddNewtonsoftJson();
builder.Services.AddScoped<AppDbContext>();

var app = builder.Build();
app.UseCors("conexionFrontend");
app.UseAuthorization();
app.MapControllers();

app.Run();