using Microsoft.EntityFrameworkCore;
using MyLastApi.Migrations;
using MyLastApi.Repositories;
//using MyLastApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Para as migrations:
builder.Services.AddDbContext<ContasContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
//,ServerVersion.Parse("")
));
builder.Services.AddMvc();
builder.Services.AddScoped<IUsuariosRepository, UsuariosRepository>();
//builder.Services.AddScoped<IValidacaoCpf, ValidacaoCpf>();
builder.Services.AddScoped<IContasBancariasRepository, ContasBancariasRepository>();

//AddControllers
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
