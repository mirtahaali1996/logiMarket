using logiMarket.Shared.Events;

namespace logiMarket.OrderService.Core.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public string TenantId { get; set; }

        public string CustomerInfo { get; set; }

        public decimal TotalAmount { get; set; }

        public OrderStatus Status { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}