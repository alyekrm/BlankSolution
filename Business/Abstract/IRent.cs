using Core.Utilies.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRent
    {
        IDataResult<List<Rental>> GetAll();

        IResult Add(Rental rental);

        IResult Update(Rental rental);

        IResult Delete(Rental rental);

        IResult CarReturn(int id);

        IDataResult<Rental> GetById(int id);
    }
}
