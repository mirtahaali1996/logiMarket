namespace logiMarket.OrderService.Application.Orders.Commands
{
    public record CreateOrderCommand(string CustomerId, string TenantId, decimal TotalAmount);
}