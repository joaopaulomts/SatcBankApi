using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(option =>
    option.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Presentations"))
);

builder.Services.AddScoped<IServUsuario, ServUsuario>();
builder.Services.AddScoped<IRepoUsuario, RepoUsuario>();

builder.Services.AddScoped<IServDeposito, ServDeposito>();
builder.Services.AddScoped<IRepoDeposito, RepoDepositvo>();

builder.Services.AddScoped<IServTransferencia, ServTransferencia>();
builder.Services.AddScoped<IRepoTransferencia, RepoTransferencia>();

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