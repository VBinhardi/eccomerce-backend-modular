using Ecommerce.Application.Interfaces;
using Ecommerce.Application.Services;
using Ecommerce.Infrastructure.Data;
using Ecommerce.Infrastructure.Repositories;
using Ecommerce.Stock.Infrastructure.Interfaces;
using Ecommerce.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


        builder.Services.AddDbContext<EcommerceDbContext>(options =>
            options.UseNpgsql(connectionString));

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddScoped<IOrderService, OrderService>();
        //ALTERAR TUDO ISSO AQUI QUANDO TIRAR O MOCK
        builder.Services.AddSingleton<IOrderRepository, OrderRepository>();
        builder.Services.AddSingleton<IProductRepository, ProductRepository>();
       

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