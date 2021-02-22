using Business.Abstract;
using Business.Constrants;
using Business.ValidationRules.FluentValidation;
using Core.Utilies.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentManager : IRent
    {

        IRentDal _manager;

        public RentManager(IRentDal manager)
        {
            _manager = manager;
        }

        public IResult Add(Rental rental)
        {

            List<Rental> carStatus = _manager.GetAll(c => c.CarId == rental.CarId);
            
            foreach (var item in carStatus)
            {

                var context = new ValidationContext<Rental>(item);
                RentValidator rentValidator = new RentValidator();
                var result = rentValidator.Validate(item);
                rental.CustomerId = item.CustomerId;
                
                if (result.IsValid)
                {
                    throw new ValidationException(result.Errors);
                }
            }
            rental.RentDate = DateTime.Now;

            _manager.Add(rental);
            return new SuccessResult(Messages.CarRented);

        }

        public IResult CarReturn(int id)
        {
            
            var rentData = _manager.Get(p=>p.CarId==id);
            
            rentData.ReturnDate = DateTime.Now;

            _manager.Update(rentData);
            return new SuccessResult(Messages.CarReturn);
        }

        public IResult Delete(Rental rental)
        {
            _manager.Delete(rental);
            return new SuccessResult(Messages.RentRecordDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
           
            return new SuccessDataResult<List<Rental>>(Messages.ListRents, _manager.GetAll());
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(Messages.ListRents, _manager.Get(p => p.CarId == id));
        }

        public IResult Update(Rental rental)
        {
            
            _manager.Update(rental);
            return new SuccessResult(Messages.RentRecordUpdated);
        }
    }
}
