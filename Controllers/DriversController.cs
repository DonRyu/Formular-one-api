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
        private readonly IUnitOfWork _unitOfWork;
        public DriversController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _unitOfWork.Drivers.All());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var driver = await _unitOfWork.Drivers.GetById(id);
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
            await _unitOfWork.Drivers.Add(driver);
            await _unitOfWork.CompleteAsync();
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteDriver/{id}")]
        public async Task<IActionResult> DeleteDriver(int id)
        {
            var driver = await _unitOfWork.Drivers.GetById(id);
            if (driver == null)
            {
                return NotFound();
            }
            await _unitOfWork.Drivers.Delete(driver);
            await _unitOfWork.CompleteAsync();
            return Ok();
        }

        [HttpPatch]
        [Route("UpdateDriver/{id}")]
        public async Task<IActionResult> UpdateDriver(int id, Driver driver)
        {
            var existDriver = await _unitOfWork.Drivers.GetById(driver.Id);
            if (existDriver == null) return NotFound();

            await _unitOfWork.Drivers.Update(driver);
            await _unitOfWork.CompleteAsync();
            return Ok();
        }
    };
}


