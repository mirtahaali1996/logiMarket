using logiMarket.Shared.Events;
using MassTransit;

namespace logiMarket.NotificationService.Consumers
{
    public class OrderPlacedConsumer(ILogger<OrderPlacedConsumer> logger) : IConsumer<OrderPlacedEvent>
    {
        public Task Consume(ConsumeContext<OrderPlacedEvent> context)
        {
            var message = context.Message;
            logger.LogInformation("Order ID : {OrderId}", message.OrderId);
            logger.LogInformation("Customer ID : {CustomerId}", message.CustomerId);
            logger.LogInformation("Total Amount : {TotalAmount}", message.TotalAmount);

            return Task.CompletedTask;
        }
    }
}