using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentsController : ControllerBase
    {
        IRent _rentManager;

        public RentsController(IRent rentManager)
        {
            _rentManager = rentManager;
        }

        [HttpPost("addRent")]
        public IActionResult AddRent(Rental rent)
        {
            var result = _rentManager.Add(rent);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delRent")]
        public IActionResult DelRent(Rental rent)
        {
            var result = _rentManager.Delete(rent);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("updRent")]
        public IActionResult UpdRent(Rental rent)
        {
            var result = _rentManager.Update(rent);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("rentReturn")]
        public IActionResult RentReturn(Rental rental)
        {
            var result = _rentManager.CarReturn(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _rentManager.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
