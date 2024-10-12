using col.Backend.Data;
using col.Backend.Repositories.Implementations.Productos;
using col.Backend.Repositories.Interfaces.Productos;
using col.Backend.UnitsOfWork.Implementations.Productos;
using col.Backend.UnitsOfWork.Interfaces.Productos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer("name=LocalConnection"));

builder.Services.AddScoped<IProductosRepository, ProductosRepository>();

builder.Services.AddScoped<IProductoUnitOfWork, ProductoUnitOfWork>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

// se modifica la seguridad
app.UseCors(x => x
		.AllowAnyMethod()
		.AllowAnyHeader()
		.SetIsOriginAllowed(origin => true)
		.AllowCredentials());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
