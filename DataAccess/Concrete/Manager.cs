using Core.DataAccess.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class Manager : IService<Car>
    {
        List<Car> _cars;

        public Manager()
        {
          
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetByld(Car car)
        {
            var Filtered = _cars.Where(c => c.BrandId == car.BrandId).ToList();
            return Filtered;
        }

        public Car GetLast(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            throw new NotImplementedException();
        }

        //public void Update(Car car)
        //{
        //    Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
        //    carToUpdate.BrandId = car.BrandId;
        //    carToUpdate.ColorId = car.ColorId;
        //    carToUpdate.DailyPrice = car.DailyPrice;
        //    carToUpdate.Description = car.Description;
        //    carToUpdate.Id = car.Id;
        //    carToUpdate.ModelYear = car.ModelYear;
        //}
    }
}
