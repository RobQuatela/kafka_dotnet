using System;

namespace kafka_dotnet.producer
{
    class Program
    {
        static void Main(string[] args)
        {
            // write message for producer to send to consumers
            System.Console.WriteLine("Enter your message. Enter q to quit");
            var message = "";

            while((message = System.Console.ReadLine()) != "q")
            {
                var producer = new BookingProducer();
                producer.Produce(message);
            }
        }
    }
}
