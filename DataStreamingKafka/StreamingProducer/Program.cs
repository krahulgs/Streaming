using System;

namespace StreamingProducer
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Console.WriteLine("Enter your message");
            var message = default(string);

            while((message = Console.ReadLine()) != "q")
            {
                var objProducer = new BookingProducer();
                objProducer.Produce(message);

            }
          
        }
    }
}
