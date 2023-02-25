using eCommerce.API.Database;
using eCommerce.API.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<eCommerceContext>(
    options =>
    options.UseSqlServer(configuration.GetConnectionString("eCommerce"))
);
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();



var app = builder.Build();

#region Atualizar banco de dados com as migra��es pendentes
//garante que todas as migra��es pendentes sejam aplicadas ao banco de dados toda vez que a API � iniciada

var scope = app.Services.CreateScope();

var services = scope.ServiceProvider;

var context = services.GetRequiredService<eCommerceContext>();

context.Database.Migrate();
#endregion

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
