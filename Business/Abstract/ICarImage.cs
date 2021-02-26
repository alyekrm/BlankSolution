
using Business.Concrete;
using Core.Utilies.Result;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImage
    {
      
        IResult UploadImage([FromForm] FileUpload fileUpload,int id, IHostEnvironment hostEnvironment);

        IDataResult<List<CarImage>> GetAll(CarImage carImage);

        IResult Delete(CarImage carImage);

        IResult Update(CarImage carImage);

    }
}
