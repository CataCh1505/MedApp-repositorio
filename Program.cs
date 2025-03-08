using MedApp_Api.DatabaseModels;
using MedApp_Api.Intefaces;
using MedApp_Api.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Necesario para usar entity framework
builder.Services.AddDbContext<DatabaseContext>(
    (options) =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("Database"));
    }
);

// Para implementar nuestros metodos
builder.Services.AddScoped<IRules, Rules>();
builder.Services.AddScoped<IRoles, Roles>();

// esto es para mapear los controladores.
builder.Services.AddControllers();

// Add services to the container.
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

//esto es para mapear controladores.
app.MapControllers();

app.Run();


