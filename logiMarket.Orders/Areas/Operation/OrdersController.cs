using logiMarket.Shared.Events;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace logiMarket.OrderService.Areas.Operation
{
    [Area("Operation")]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public OrdersController(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        [HttpPost("placeOrder")]
        public async Task<IActionResult> PlaceOrder(CreateOrderRequest request)
        {
            var orderId = Guid.NewGuid();
            var orderPlacedEvent = new OrderPlacedEvent(
                OrderId: orderId,
                CustomerId: request.CustomerId,
                TenantId: request.TenantId,
                TotalAmount: request.TotalAmount);

            await _publishEndpoint.Publish(orderPlacedEvent);


            return Ok(new { Message = "successfull", OrderId = orderId });

        }

    }
}
