using System;
using System.Collections.Generic;
using System.Text;

namespace Propostas.Infra.CrossCutting.Bus
{
    using MediatR;

    public sealed class InMemoryBus // : IMediatorHandler
    {
        /*
        private readonly IMediator mediator;
        private readonly IEventStore eventStore;

        public InMemoryBus(IEventStore eventStore, IMediator mediator)
        {
            this.eventStore = eventStore;
            this.mediator = mediator;
        }

        public Task SendCommand<T>(T command)
            where T : Command
        {
            return this.Publish(command);
        }

        public Task RaiseEvent<T>(T @event)
            where T : Event
        {
            if (!@event.MessageType.Equals("DomainNotification"))
            {
                this.eventStore?.Save(@event);
            }

            return this.Publish(@event);
        }

        private Task Publish<T>(T message)
            where T : Message
        {
            return this.mediator.Publish(message);
        }
        */
    }
}
