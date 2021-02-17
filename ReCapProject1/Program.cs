﻿using Business.Concrete;
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


            Console.WriteLine("GetALL");


            foreach (var item in businessManager.GetCarDetails())
            {
                Console.WriteLine("{0},{1},{2},{3}", item.CarName, item.BrandName, item.ColorName, item.DailyPrice);
            }

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
  
            businessManager.Add(car);
            Console.WriteLine("------Added-------");

            foreach (var item in businessManager.GetCarDetails())
            {
                Console.WriteLine("{0},{1},{2},{3}", item.CarName, item.BrandName, item.ColorName, item.DailyPrice);
            }
            businessManager.Delete(car);

            Console.WriteLine("-----Deleted-----");

            foreach (var item in businessManager.GetCarDetails())
            {
                Console.WriteLine("{0},{1},{2},{3}", item.CarName, item.BrandName, item.ColorName, item.DailyPrice);
            }
            
      
            Console.WriteLine("-----Updated-----");

            businessManager.Update(new Car { Id = 5, Name = "xxx", BrandId = 1,ColorId=1,DailyPrice=00 });

            foreach (var item in businessManager.GetCarDetails())
            {
                Console.WriteLine("{0},{1},{2},{3}", item.CarName, item.BrandName, item.ColorName, item.DailyPrice);
            }
        }
    }
}
