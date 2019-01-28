using System;

namespace kafka_dotnet.consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var bookingConsumer = new BookingConsumer();
            bookingConsumer.Listen(Console.WriteLine);
        }
    }
}
