using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BusinessManager : IBusiness
    {
        IService _manager;

        public BusinessManager(IService manager)
        {
            _manager = manager;
        }

        public void Add(Car car)
        {
            _manager.Add(car);
        }

        public void Delete(Car car)
        {
            _manager.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _manager.GetAll();
        }

        public List<Car> GetByld(Car car)
        {
            return _manager.GetByld(car);
        }

        public void Update(Car car)
        {
            _manager.Update(car);
        }
    }
}
