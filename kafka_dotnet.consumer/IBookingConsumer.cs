using System;

namespace kafka_dotnet.consumer
{
    public interface IBookingConsumer
    {
         void Listen(Action<string> message);
    }
}