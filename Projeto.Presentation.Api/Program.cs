using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Projeto.Application.Contracts;
using Projeto.Application.Services;
using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Services;
using Projeto.Infra.Data.Contexts;
using Projeto.Infra.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Configuração da string de conexão do EF
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer
(builder.Configuration.GetConnectionString("ProjetoDDD")));

//camada de repositório
builder.Services.AddTransient<IFuncionarioRepository, FuncionarioRepository>();
builder.Services.AddTransient<IDependenteRepository, DependenteRepository>();

//Camada de domínio
builder.Services.AddTransient<IFuncionarioDomainService, FuncionarioDomainService>();
builder.Services.AddTransient<IDependenteDomainService, DependenteDomainService>();

//Camada de aplicação
builder.Services.AddTransient<IFuncionarioApplicationService, FuncionarioApplicationService>();
builder.Services.AddTransient<IDependenteApplicationService, DependenteApplicationService>();


builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API para controle de Funcionários e Dependentes",
        Description = "Projeto Desenvolvido em NET CORE 7.0 API com EF e DDD.",        
        Contact = new OpenApiContact
        {
            Name = "Talvane Ramos",
            Email = "talvanesilvaramos@gmail.com"
        },        
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Projeto");
    options.RoutePrefix = string.Empty;
});

app.MapControllers();

app.Run();
