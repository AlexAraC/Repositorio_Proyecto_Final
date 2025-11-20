using Microsoft.EntityFrameworkCore;
using ProyectoFinal_VitaliAPI.Data;
using ProyectoFinal_VitaliAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<VitaliDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("VitaliDb")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<MedicoService>();
builder.Services.AddScoped<PacienteServices>();
builder.Services.AddScoped<CitaMedicaService>();
builder.Services.AddScoped<HistorialClinicoService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();


app.MapControllers();

app.Run();
