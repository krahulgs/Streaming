using System;
using System.Collections.Generic;
using System.Text;
using Confluent.Kafka;

namespace StreamingProducer
{
    public class BookingProducer : IBookingProducer
    {
        
        public async void Produce(string message)
        {
            var config = new ProducerConfig { BootstrapServers = "localhost:9092" };

            using(var p= new ProducerBuilder<Null, String>(config).Build())
            {
                try
                {
                    var dr = await p.ProduceAsync("temp-topic", new Message<Null, string> { Value = message });
                    Console.WriteLine($"Delivered  '{dr.Value}'  to '{dr.TopicPartitionOffset}'");
                }
                catch(ProduceException<Null, string> e)
                {

                    Console.WriteLine($"Delivery failed: {e.Error.Reason}");
                }
            }

           
        }
    }
}
