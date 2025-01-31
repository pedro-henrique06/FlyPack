using FlyPack.Application.Interfaces;
using FlyPack.Application.Services;
using FlyPack.Domain.Interfaces;
using FlyPack.Infrastructure.Context;
using FlyPack.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        builder.Services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });
        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        // Registro de Repositórios
        builder.Services.AddScoped<IFornecedorRepository, FornecedorRepository>();
        builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
        builder.Services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
        builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();

        // Registro de Serviços
        builder.Services.AddScoped<ApplicationDbContext>();
        builder.Services.AddScoped<INotificator, Notificator>();
        builder.Services.AddScoped<IFornecedorService, FornecedorService>();
        builder.Services.AddScoped<IClienteService, ClienteService>();
        builder.Services.AddScoped<IFuncionarioService, FuncionarioService>();
        builder.Services.AddScoped<IProdutoService, ProdutoService>();

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
    }
}