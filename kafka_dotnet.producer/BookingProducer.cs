using System.Collections.Generic;
using System.Text;

namespace kafka_dotnet.producer
{
    public class BookingProducer : IBookingProducer
    {
        public void Produce(string message)
        {
            var config = new Dictionary<string, object>
            {
                { "bootstrap.servers", "localhost:9092" }
            };

            using(var producer = new Confluent.Kafka.Producer<Confluent.Kafka.Null, string>(config, null, new Confluent.Kafka.Serialization.StringSerializer(Encoding.UTF8)))
            {
                producer.ProduceAsync("first_topic", null, message).GetAwaiter().GetResult();
            }
        }
    }
}