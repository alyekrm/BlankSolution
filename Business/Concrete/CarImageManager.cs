using Business.Abstract;
using Business.Constrants;
using Core.Utilies.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Web.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImage
    {
        ICarImageDal _manager;
        IHostEnvironment _hostEnvironment;
     

        public CarImageManager(ICarImageDal manager, IHostEnvironment hostEnvironment)
        {
            _manager = manager;
            _hostEnvironment = hostEnvironment;
        }

        public IResult Add(CarImage carImage)
        {

            var result = CheckIfImageLimitExceeded(carImage);
            if (!result.Success)
            {
                return result;
            }         
            _manager.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }


        public IResult Delete(CarImage carImage)
        {
            var result = _manager.Get(p => p.Id == carImage.Id);
            _manager.Delete(result);
            return new SuccessResult(Messages.CarImageDeleted);
        }


        public IResult Update(CarImage carImage)
        {
            var result = CheckIfImageLimitExceeded(carImage);
            if (!result.Success)
            {
                return result;
            }
            _manager.Update(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        public IDataResult<List<CarImage>> GetAll(CarImage carImage) 
        {
            var list = _manager.GetAll(p => p.CarId == carImage.CarId);
            if (list.Count==0)
            {
                CarImage _defCarImage = new CarImage() { ImagePath = $@"C:\Users\lapto\source\repos\BlankSolution\WebAPI\uploads\0d2e49f3 - 1158 - 468e-b5de - 263696b249c2.png" };
                List<CarImage> defList = new List<CarImage>();
                defList.Add(_defCarImage);
                return new SuccessDataResult<List<CarImage>>(defList);
            }
            return new SuccessDataResult<List<CarImage>>(list);

        }

        

        private IResult CheckIfImageLimitExceeded(CarImage carImage)
        {
            var result = _manager.GetAll(p => p.CarId == carImage.CarId).Count;
            if (result>=5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        public IResult UploadImage([FromForm] Entities.Concrete.FileUpload fileUpload,int id )
        {

            CarImage carImage = new CarImage() {CarId=id,Date=DateTime.Now };

            var result = CheckIfImageLimitExceeded(carImage);
            
            if (result.Success)
            {
                string path = _hostEnvironment.ContentRootPath + $@"\uploads\";


                string guidName = Guid.NewGuid().ToString();

                string extension = Path.GetExtension(fileUpload.Files.FileName);

                carImage.ImagePath = path + $@"\" + guidName;

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                using (FileStream fileStream = System.IO.File.Create(path + guidName+extension))
                {
                  
                    fileUpload.Files.CopyTo(fileStream);     
                    
                    fileStream.Flush();                   

                }
                _manager.Add(carImage);
                return new SuccessResult(Messages.CarImageAdded);
                
            }
            return new ErrorResult(Messages.MaxCarImageError);

        }

       
    }
}
