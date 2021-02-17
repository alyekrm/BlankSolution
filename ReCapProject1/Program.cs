using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReCapProject1
{
    class Program
    {
        static void Main(string[] args)
        {
            BusinessManager businessManager = new BusinessManager(new EfCarDal());

            businessManager.Update(new Car { Id = 5, Name = "cba", BrandId = 1, ColorId = 1, DailyPrice = 00 });

            Console.WriteLine("GetALL");


            Print(businessManager);
            
            Car car = NewCar(businessManager);

            businessManager.Add(car);
            
            Console.WriteLine("------Added-------");

            Print(businessManager);
            
            businessManager.Delete(car);

            Console.WriteLine("-----Deleted-----");

            Print(businessManager);

            Console.WriteLine("-----Updated-----");

            businessManager.Update(new Car { Id = 5, Name = "xxx", BrandId = 1, ColorId = 1, DailyPrice = 00 });

            Print(businessManager);
        }

        private static Car NewCar(BusinessManager businessManager)
        {
            Car car = new Car() { Name = "a" };
            businessManager.Add(car);
            car.Name = "abc";
            car.DailyPrice = 0;
            businessManager.Add(car);

            car.DailyPrice = 111;
            car.BrandId = 1;
            car.ColorId = 1;

            foreach (var item in businessManager.GetAll())
            {
                var id = item.Id;
                car.Id = id + 1;
            }

            return car;
        }

        private static void Print(BusinessManager businessManager)
        {
            foreach (var item in businessManager.GetCarDetails())
            {
                Console.WriteLine("{0},{1},{2},{3}", item.CarName, item.BrandName, item.ColorName, item.DailyPrice);
            }
        }
    }
}
