using Microsoft.EntityFrameworkCore;
using ProyectoFinal_VitaliAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<VitaliDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("VitaliDb")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// (Más adelante agregaremos autenticación básica aquí)

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();

// app.UseAuthentication();   // cuando implementes auth
// app.UseAuthorization();

app.MapControllers();

app.Run();
