using System;
using System.Collections.Generic;
using System.Text;

namespace kafka_dotnet.consumer
{
    public class BookingConsumer : IBookingConsumer
    {
        public void Listen(Action<string> message)
        {
            // configuration for kafka to find brokers
            var config = new Dictionary<string, object>
            {
                {
                    "group.id", "booking_consumer"
                },
                {
                    "bootstrap.servers", "localhost:9092"
                },
                {
                    "enable.auto.commit", "false"
                }
            };

            // subscribe consumer to producer topics
            // null is there because we are not using consumer/producer keys
            using(var consumer = new Confluent.Kafka.Consumer<Confluent.Kafka.Null, string>(config, null, new Confluent.Kafka.Serialization.StringDeserializer(Encoding.UTF8)))
            {
                // consumer subscribing to the topic
                consumer.Subscribe("first_topic");
                consumer.OnMessage += (_, msg) =>
                {
                    message(msg.Value);
                };

                while (true)
                    consumer.Poll(100);
            }
        }
    }
}