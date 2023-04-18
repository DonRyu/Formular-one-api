using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Formular_one_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Formular_one_api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class DriversController : ControllerBase
    {
        private static readonly List<Driver> _drivers = new List<Driver>()
        {
            new Driver(){
                Id = 1,
                Name = "Lewis Hamilton",
                DriverNumber = 44,
                Team = "Mercedes"
            },
            new Driver(){
                Id = 2,
                Name = "Valtteri Bottas",
                DriverNumber = 77,
                Team = "Mercedes"
            },
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_drivers);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var driver = _drivers.FirstOrDefault(x => x.Id == id);
            if (driver == null)
            {
                return NotFound();
            }
            return Ok(driver);
        }

        [HttpPost]
        [Route("AddDriver")]
        public IActionResult AddDriver(Driver driver)
        {
            _drivers.Add(driver);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteDriver/{id}")]
        public IActionResult DeleteDriver(int id)
        {
            var driver = _drivers.FirstOrDefault(x => x.Id == id);
            if (driver == null)
            {
                return NotFound();
            }
            _drivers.Remove(driver);
            return Ok();
        }

        [HttpPatch]
        [Route("UpdateDriver/{id}")]
        public IActionResult UpdateDriver(int id, Driver driver)
        {
            var driverToUpdate = _drivers.FirstOrDefault(x => x.Id == id);
            if (driverToUpdate == null)
            {
                return NotFound();
            }
            driverToUpdate.Name = driver.Name;
            driverToUpdate.DriverNumber = driver.DriverNumber;
            driverToUpdate.Team = driver.Team;
            return Ok();
        }
    };
}


