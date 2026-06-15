using System.ComponentModel.DataAnnotations;

namespace logiMarket.Shared.Events
{
    public record OrderPlacedEvent(Guid OrderId, string CustomerId, string TenantId, decimal TotalAmount);
    public record OrderStatusChangedEvent(Guid OrderId, string CustomerId, string TenantId, OrderStatus NewStatus, string Message);

    public record CreateOrderRequest([property: Required] string CustomerId, [property: Required] string TenantId, [property: Required, Range(0.01, double.MaxValue, ErrorMessage = "Amount must be non negative and greater than zero")] decimal TotalAmount);
}
