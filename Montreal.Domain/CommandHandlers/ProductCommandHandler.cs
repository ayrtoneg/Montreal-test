using MediatR;
using Montreal.Domain.Commands;
using Montreal.Domain.Core.Bus;
using Montreal.Domain.Core.Notifications;
using Montreal.Domain.Events;
using Montreal.Domain.Interfaces;
using Montreal.Domain.Models;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Montreal.Domain.CommandHandlers
{
    public class ProductCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewProductCommand>,
        IRequestHandler<UpdateProductCommand>,
        IRequestHandler<RemoveProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMediatorHandler Bus;

        public ProductCommandHandler(IProductRepository productRepository,
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _productRepository = productRepository;
            Bus = bus;
        }

        public Task Handle(RegisterNewProductCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            var product = new Product(message.Id, message.Name, message.Description, message.Images, message.IdFatherProduct);

            if (_productRepository.GetById(product.Id) != null)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "Produto já adicionado"));
                return Task.CompletedTask;
            }

            _productRepository.Add(product);

            if (Commit())
            {
                Bus.RaiseEvent(new ProductRegisteredEvent(product.Id, product.Name, product.Description, product.Images, product.IdFatherProduct));
            }

            return Task.CompletedTask;
        }

        public Task Handle(UpdateProductCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            var product = new Product(message.Id, message.Name, message.Description, message.Images, message.IdFatherProduct);
            var existingProduct = _productRepository.GetById(product.Id);

            if (existingProduct != null && existingProduct.Id != product.Id)
            {
                if (!existingProduct.Equals(product))
                {
                    Bus.RaiseEvent(new DomainNotification(message.MessageType, "Produto não teve alterações"));
                    return Task.CompletedTask;
                }
            }

            _productRepository.Update(product);

            if (Commit())
            {
                Bus.RaiseEvent(new ProductUpdatedEvent(product.Id, product.Name, product.Description, product.Images, product.IdFatherProduct));
            }

            return Task.CompletedTask;
        }

        public Task Handle(RemoveProductCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            _productRepository.Remove(message.Id);

            if (Commit())
            {
                Bus.RaiseEvent(new ProductRemovedEvent(message.Id));
            }

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _productRepository.Dispose();
        }
    }
}
