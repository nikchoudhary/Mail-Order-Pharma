using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailOrderPharmacy_DrugService.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MailOrderPharmacy_DrugService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugLocController : ControllerBase
    {
        public static List<DrugLocation> list = new List<DrugLocation>
        {
            new DrugLocation
            {
                Drug_Id = 1,
                Name = "Paracetamol",
                ExpiryDate = new DateTime(2022, 08, 10),
                Location="Pune",
                Available_Stock =100
            }
        };
        // GET: api/<DrugLocController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<DrugLocController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DrugLocController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DrugLocController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DrugLocController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
