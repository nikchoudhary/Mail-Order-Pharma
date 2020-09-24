using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailOrderPharmacy_DrugService.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MailOrderPharmacy_DrugService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class DrugsController : ControllerBase
    {
        readonly log4net.ILog _log4net;
        IDrug _con;
        public  DrugsController(IDrug con)
        {
            _con = con;
            _log4net = log4net.LogManager.GetLogger(typeof(DrugsController));
        }
        // GET: api/<DrugsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<DrugsController>/5
        [HttpGet("{id}")]
        public IActionResult GetDrugDetails(int id)
        {
            try
            {
                var obj = _con.searchDrugsByID(id);
                if (obj == null)
                {
                    return NotFound();
                }

                return Ok(obj);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        [HttpGet("GetDrugDetailByName/{name}")]
        //[Route("GetDrugDetailByName/name")]
        public IActionResult GetDrugDetailByName(string name)
        {
            try
            {
                var obj = _con.searchDrugsByName(name);
                if (obj == null)
                {
                    return NotFound();
                }

                return Ok(obj);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        // POST api/<DrugsController>
        [HttpGet("{id}/{loc}")]
        public IActionResult getDispatchableDrugStock(int id, string loc)
        {
            var drug = _con.getDispatchableDrugStock(id, loc);
            return Ok(drug);
        }

        // PUT api/<DrugsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DrugsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
