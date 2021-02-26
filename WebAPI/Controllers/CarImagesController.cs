using Business.Abstract;
using Business.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImage _manager;
       

        public CarImagesController(ICarImage manager)
        {
            _manager = manager;
           
        }

        [HttpPost("uploadimage")]
        public IActionResult UploadImage([FromForm]FileUpload fileUpload,[FromForm]int id)
        {
            var result=_manager.UploadImage(fileUpload,id);           

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("getimage")]
        public IActionResult getImage(CarImage carImage)
        {
            var result=_manager.GetAll(carImage);
            if(result.Success)
            {
                
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("deleteimage")]
        public IActionResult deleteImage(CarImage carImage)
        {
            var result = _manager.Delete(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("updateimage")]
        public IActionResult updateImage(CarImage carImage)
        {
            var result = _manager.Delete(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
