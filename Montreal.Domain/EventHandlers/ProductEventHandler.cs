﻿using MediatR;
using Montreal.Domain.Events;
using System.Threading;
using System.Threading.Tasks;

namespace Montreal.Domain.EventHandlers
{
    public class ProductEventHandler :
        INotificationHandler<ProductRegisteredEvent>,
        INotificationHandler<ProductUpdatedEvent>,
        INotificationHandler<ProductRemovedEvent>
    {
        public Task Handle(ProductUpdatedEvent message, CancellationToken cancellationToken)
        {
            // Send some notification e-mail

            return Task.CompletedTask;
        }

        public Task Handle(ProductRegisteredEvent message, CancellationToken cancellationToken)
        {
            // Send some greetings e-mail

            return Task.CompletedTask;
        }

        public Task Handle(ProductRemovedEvent message, CancellationToken cancellationToken)
        {
            // Send some see you soon e-mail

            return Task.CompletedTask;
        }
    }
}
