using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Montreal.Application.Interfaces;
using Montreal.Application.Services;
using Montreal.Domain.CommandHandlers;
using Montreal.Domain.Commands;
using Montreal.Domain.Core.Bus;
using Montreal.Domain.Core.Notifications;
using Montreal.Domain.EventHandlers;
using Montreal.Domain.Events;
using Montreal.Domain.Interfaces;
using Montreal.Infra.CrossCutting.Bus;
using Montreal.Infra.Data.Context;
using Montreal.Infra.Data.Repository;
using Montreal.Infra.Data.UoW;

namespace Montreal.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Application
            services.AddScoped<IProductAppService, ProductAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<ProductRegisteredEvent>, ProductEventHandler>();
            services.AddScoped<INotificationHandler<ProductUpdatedEvent>, ProductEventHandler>();
            services.AddScoped<INotificationHandler<ProductRemovedEvent>, ProductEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewProductCommand>, ProductCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateProductCommand>, ProductCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveProductCommand>, ProductCommandHandler>();

            // Infra - Data
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<MontrealContext>();
        }
    }
}
