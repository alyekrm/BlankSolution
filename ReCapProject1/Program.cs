using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ReCapProject1
{
    class Program
    {
        static void Main(string[] args)
        {
            BusinessManager businessManager = new BusinessManager(new EfCarDal());

            Console.WriteLine("GetALL");
            

            foreach (var item in businessManager.GetAll())
            {
                Console.WriteLine(item.Name);
            }

            Car car = new Car() { Name = "a" };
            businessManager.Add(car);
            car.Name = "abc";
            car.DailyPrice = 0;
            businessManager.Add(car);
            
            car.DailyPrice = 111;
         
            foreach (var item in businessManager.GetAll())
            {
                var id = item.Id;
                car.Id = id + 1;
            }
            
            businessManager.Add(car);
            foreach (var item in businessManager.GetAll())
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine("Get By Id");
            foreach (var item in businessManager.GetCarsByBrandId(1))
            {
                Console.WriteLine( "{1},{0}" ,item.Name,item.Id);
            }

            Console.WriteLine("Get By Color Id");
            foreach (var item in businessManager.GetCarsByColorId(1))
            {
                Console.WriteLine("{1},{0}", item.Name, item.Id);
            }
        }
    }
}
