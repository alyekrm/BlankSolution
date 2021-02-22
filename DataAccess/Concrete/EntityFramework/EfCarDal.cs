using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentContext>, ICarDal
    {
      
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentContext rentContext=new RentContext())
            {
                var result = from car in rentContext.Cars
                             join color in rentContext.Colors on car.ColorId equals color.Id
                             join brand in rentContext.Brands on car.BrandId equals brand.Id
                             select new CarDetailDto
                             {
                                 BrandName = brand.Name,
                                 ColorName = color.Name,
                                 DailyPrice = car.DailyPrice,
                                 CarName = car.Name
                             };
                return result.ToList();
                                
            }
        }
    }
}
