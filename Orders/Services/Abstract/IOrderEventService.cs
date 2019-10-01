using System;
using System.Collections.Concurrent;
using Orders.Models;

namespace Orders.Services.Abstract
{
    public interface IOrderEventService
    {
        ConcurrentStack<OrderEvent> AllEvents { get; }
        void AddError(Exception exception);
        OrderEvent AddEvent(OrderEvent orderEvent);
        IObservable<OrderEvent> EventStream();
    }
}