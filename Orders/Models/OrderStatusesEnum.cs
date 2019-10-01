using System;

namespace Orders.Models
{
    [Flags]
    public enum OrderStatusesEnum
    {
        CREATED = 2,
        PROCESSING = 4,
        COMPLETED = 8,
        CANCELLED = 16,
        CLOSED = 32
    }
}