using System;
using System.Collections.Generic;
using System.Text;

namespace StreamingProducer
{
    public interface IBookingProducer
    {
        void Produce(string message);
    }
}
