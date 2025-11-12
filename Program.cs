using RestauranteAPI.Controllers;
using RestauranteAPI.Repositories;
using RestauranteAPI.Services;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("RestauranteDB");

builder.Services.AddScoped<IPlatoPrincipalRepository, PlatoPrincipalRepository>();
builder.Services.AddScoped<IPostreRepository, PostreRepository>();
builder.Services.AddScoped<IBebidaRepository, BebidaRepository>();
builder.Services.AddScoped<IComboRepository, ComboRepository>();
builder.Services.AddScoped<IPlatoPrincipalService, PlatoPrincipalService>();
builder.Services.AddScoped<IPostreService, PostreService>();
builder.Services.AddScoped<IBebidaService, BebidaService>();
builder.Services.AddScoped<IComboService, ComboService>();
builder.Services.AddScoped<IMenuDelDiaRepository, MenuDelDiaRepository>();
builder.Services.AddScoped<IMenuDelDiaService, MenuDelDiaService>();

<<<<<<< HEAD

=======
>>>>>>> master
// Add services to the container.

builder.Services.AddControllers();
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



//PlatoPrincipalController.InicializarDatos();
app.Run();
