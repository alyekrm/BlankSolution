using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IService<T> where T : class, IEntities, new()
    {
        List<Car> GetByld(Car car);

        T Get(Expression<Func<T, bool>> filter);

        List<T> GetAll(Expression<Func<T,bool>> filter=null);

        void Add(Car car);

        void Update(Car car);

        void Delete(Car car);
    }
}
