using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DatStreamingKafka.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerController : ControllerBase
    {
        private ProducerConfig _config;

        public ProducerController(ProducerConfig config)
        {
            this._config = config;
        }

        [HttpPost("send")]
        public  async Task<ActionResult> Get(string Topic, [FromBody]Employee employee)
        {
            string serializeEMployee = JsonConvert.SerializeObject(employee);
            using(var Producer =new ProducerBuilder<Null, string>(_config).Build())
            {
                await Producer.ProduceAsync(Topic, new Message<Null, string> { Value = serializeEMployee });
                Producer.Flush(TimeSpan.FromSeconds(0));
                return Ok(true);
            }
        }
        
    }

    public class Employee
    {
        public int Id { get; set; }
        public string name { get; set; }
    }
}
