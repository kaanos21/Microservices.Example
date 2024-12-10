using MassTransit;
using Shared.Events;

namespace Payment.API.Consumers
{
    public class StockReservedEventConsumer : IConsumer<StockReservedEvent>
    {
        readonly IPublishEndpoint _publishEndpoint;
        

        public Task Consume(ConsumeContext<StockReservedEvent> context)
        {
            //ödeme işlem
            if (true)
            {
                //ödeme başarılı
                PaymentCompletedEvent paymentCompletedEvent = new()
                {
                    OrderId = context.Message.OrderId,
                };
                _publishEndpoint.Publish(paymentCompletedEvent);
                Console.WriteLine("ödeme başarılı");
            }
            else
            {
                //ödemede sıkıntı
                PaymentFailedEvent paymentFailedEvent = new()
                {
                    OrderId = context.Message.OrderId,
                    Message = "bakiye yetersiz"
                };
                _publishEndpoint.Publish(paymentFailedEvent);
            }
            return Task.CompletedTask;
        }
    }
}
