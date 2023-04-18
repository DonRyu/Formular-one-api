using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Formular_one_api.Data;
using Formular_one_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Formular_one_api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class DriversController : ControllerBase
    {

        private readonly ApiDbContext _context;
        public DriversController(ApiDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Drivers.ToListAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var driver = await _context.Drivers.FirstOrDefaultAsync(x => x.Id == id);
            if (driver == null)
            {
                return NotFound();
            }
            return Ok(driver);
        }

        [HttpPost]
        [Route("AddDriver")]
        public async Task<IActionResult> AddDriver(Driver driver)
        {
            _context.Drivers.Add(driver);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteDriver/{id}")]
        public async Task<IActionResult> DeleteDriver(int id)
        {
            var driver = await _context.Drivers.FirstOrDefaultAsync(x => x.Id == id);
            if (driver == null)
            {
                return NotFound();
            }
            _context.Drivers.Remove(driver);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPatch]
        [Route("UpdateDriver/{id}")]
        public async Task<IActionResult> UpdateDriver(int id, Driver driver)
        {
            var existDriver = await _context.Drivers.FirstOrDefaultAsync(x => x.Id == id);
            if (existDriver == null)return NotFound();
        
            existDriver.Name = driver.Name;
            existDriver.DriverNumber = driver.DriverNumber;
            existDriver.Team = driver.Team;

            await _context.SaveChangesAsync();
            return Ok();
        }
    };
}


