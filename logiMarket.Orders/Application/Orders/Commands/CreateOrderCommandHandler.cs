using logiMarket.OrderService.Core.Models;
using logiMarket.OrderService.Infrastructure.Data;
using logiMarket.Shared.Events;
using MassTransit;
using MediatR;

namespace logiMarket.OrderService.Application.Orders.Commands
{
    public class CreateOrderCommandHandler(ApplicationDbContext dbContext, IPublishEndpoint publishEndPoint) : IRequestHandler<CreateOrderCommand, Guid>
    {
        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var orderId = Guid.NewGuid();
            var order = new Order
            {
                OrderId = orderId,
                CustomerInfo = request.CustomerId,
                TenantId = request.TenantId,
                TotalAmount = request.TotalAmount,
                Status = OrderStatus.Placed
            };
            await dbContext.Orders.AddAsync(order, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);
            await publishEndPoint.Publish(new OrderPlacedEvent(orderId, request.CustomerId, request.TenantId, request.TotalAmount), cancellationToken);
            return orderId;
        }
    }
}