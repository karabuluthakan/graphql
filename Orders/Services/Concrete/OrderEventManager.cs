using System;
using System.Collections.Concurrent;
using Orders.Models;
using Orders.Services.Abstract;
using System.Reactive.Subjects;
using System.Reactive.Linq;

namespace Orders.Services.Concrete
{
    public class OrderEventManager : IOrderEventService
    {
        private readonly ISubject<OrderEvent> _eventStream = new ReplaySubject<OrderEvent>(1);
        public ConcurrentStack<OrderEvent> AllEvents { get; }

        public OrderEventManager()
        {
            AllEvents = new ConcurrentStack<OrderEvent>();
        }

        public void AddError(Exception exception)
        {
            _eventStream.OnError(exception);
        }

        public OrderEvent AddEvent(OrderEvent orderEvent)
        {
            AllEvents.Push(orderEvent);
            _eventStream.OnNext(orderEvent);
            return orderEvent;
        }

        public IObservable<OrderEvent> EventStream()
        {
            return _eventStream.AsObservable();
        }
    }
}