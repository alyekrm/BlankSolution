using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car car)
        {
            
            if (car.Name.Length < 2 )
            {
                Console.WriteLine("Araba ismi minimum 2 karakter olmalıdır");
            }
            else if(car.DailyPrice <= 0)
            {
                Console.WriteLine("Araba günlük fiyatı 0'dan büyük olmalıdır.");
            }
            else
            {
                using (RentContext context = new RentContext())
                {
                    var addedCar = context.Entry(car);
                    addedCar.State = EntityState.Added;
                    context.SaveChanges();
                }
            }
            
            
           
        }

        public void Delete(Car car)
        {
            using (RentContext context = new RentContext())
            {
                var deletedCar = context.Entry(car);
                deletedCar.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (RentContext context = new RentContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (RentContext context = new RentContext())
            {
                return filter==null ? context.Set<Car>().ToList():
                    context.Set<Car>().Where(filter).ToList();
            }
        }

        public List<Car> GetByld(Car car)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            using (RentContext context = new RentContext())
            {
                var updatedCar = context.Entry(car);
                updatedCar.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
