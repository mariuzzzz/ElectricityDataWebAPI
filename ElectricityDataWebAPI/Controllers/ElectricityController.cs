using ElectricityDataWebAPI.DB;
using ElectricityDataWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ElectricityDataWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElectricityController : ControllerBase
    {
        private ElectricityContext _electricityContext;
        public ElectricityController(ElectricityContext electricityContext)
        {
            _electricityContext = electricityContext;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<DataModel> Get()
        {
            return _electricityContext.Data;
        }
    }
}
