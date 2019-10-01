using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using GraphQL.Resolvers;
using GraphQL.Subscription;
using GraphQL.Types;
using Orders.Models;
using Orders.QraphQL.Enums;
using Orders.QraphQL.Types;
using Orders.Services.Abstract;

namespace Orders.QraphQL.Subscriptions
{
    public class OrderSubscription : ObjectGraphType<object>
    {
        private readonly IOrderEventService _eventService;

        public OrderSubscription(IOrderEventService eventService)
        {
            Name = "Subscription";
            _eventService = eventService;
            AddField(new EventStreamFieldType
            {
                Name = "orderEvent",
                Arguments = new QueryArguments(new QueryArgument<ListGraphType<OrderStatusesGraphEnum>>
                    {Name = "statuses"}),
                Type = typeof(OrderEventType),
                Resolver = new FuncFieldResolver<OrderEvent>(ResolveEvent),
                Subscriber = new EventStreamResolver<OrderEvent>(Subscribe)
            });
        }

        private OrderEvent ResolveEvent(ResolveFieldContext context)
        {
            var orderEvent = context.Source as OrderEvent;
            return orderEvent;
        }

        private IObservable<OrderEvent> Subscribe(ResolveEventStreamContext context)
        {
            var statusList =
                context.GetArgument<IList<OrderStatusesEnum>>("statuses", new List<OrderStatusesEnum>());

            if (statusList.Count > 0)
            {
                OrderStatusesEnum statuses = 0;

                foreach (var status in statusList)
                {
                    statuses = statuses | status;
                }

                return _eventService.EventStream().Where(x => (x.Status & statuses) == x.Status);
            }

            return _eventService.EventStream();
        }
    }
}