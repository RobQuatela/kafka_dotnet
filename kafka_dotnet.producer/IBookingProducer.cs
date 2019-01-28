namespace kafka_dotnet.producer
{
    public interface IBookingProducer
    {
         void Produce(string message);
    }
}