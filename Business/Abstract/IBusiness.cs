using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBusiness
    {
        List<Car> GetByld(Car car);

        List<Car> GetAll();

        List<Car> GetCarsByBrandId(int id);

        List<Car> GetCarsByColorId(int id);

        void Add(Car car);

        void Update(Car car);

        void Delete(Car car);

        
    }
}
