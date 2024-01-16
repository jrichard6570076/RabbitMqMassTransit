using FluentValidation;
using MassTransit;
using SharedModels;
using System;

namespace RabbitMqMassTransit
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddMassTransit(busConfigurator =>
            {
                busConfigurator.SetKebabCaseEndpointNameFormatter();
                busConfigurator.UsingRabbitMq((context, busFactoryConfigurator) =>
                {
                    busFactoryConfigurator.Host("localhost", hostConfigurator => { });
                });
            });

            builder.Services.AddScoped<IValidator<Message>, MessageValidator>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.

           // app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
