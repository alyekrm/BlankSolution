using Business.Concrete;
using DataAccess.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ReCapProject1
{
    class Program
    {
        static void Main(string[] args)
        {
            BusinessManager businessManger = new BusinessManager(new Manager());

            Console.WriteLine("GetALL");
            businessManger.GetAll();
            foreach (var item in businessManger.GetAll())
            {
                Console.WriteLine(item.DailyPrice);
            }

            Car nCar = new Car() { Id = 9, BrandId = "1", ColorId = "1", DailyPrice = 150.0, Description = "EcoVan", ModelYear = "2018" };
            businessManger.Add(nCar);
            foreach (var item in businessManger.GetAll())
            {
                Console.WriteLine(item.DailyPrice);
            }

            Console.WriteLine("GetById");
            businessManger.GetByld(nCar);
            Car yCar = new Car() { Id = 9, BrandId = "2", ColorId = "2", DailyPrice = 2150.0, Description = "EEcoVan", ModelYear = "2018" };
            Console.WriteLine("Update");
            businessManger.Update(yCar);
            foreach (var item in businessManger.GetAll())
            {
                Console.WriteLine(item.DailyPrice);
            }

            businessManger.Delete(yCar);
            Console.WriteLine("Delete");
            foreach (var item in businessManger.GetAll())
            {
                Console.WriteLine(item.DailyPrice);
            }
        }
    }
}
