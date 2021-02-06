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

        void Add(Car car);

        void Update(Car car);

        void Delete(Car car);
    }
}
