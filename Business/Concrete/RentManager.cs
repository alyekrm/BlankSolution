using Business.Abstract;
using Business.Constrants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcers.Validation;
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


        //[ValidationAspect(typeof(RentValidator))] validator içinde veritabanından gelen rental verisine erişim returndate sorgulamasından sonra aktif olacak

        public IResult Add(Rental rental)
        {


            List<Rental> carStatus = _manager.GetAll(c => c.CarId == rental.CarId);

            foreach (var item in carStatus)
            {
                ValidationTool.Validate(new RentValidator(), item);
            }
            rental.RentDate = DateTime.Now;

            _manager.Add(rental);
            return new SuccessResult(Messages.CarRented);

        }

        public IResult CarReturn(Rental rental)
        {

            List<Rental> rentData = _manager.GetAll(p => p.CarId == rental.CarId  );

            foreach (var item in rentData)
            {
                if (item.ReturnDate == null)
                {
                    item.ReturnDate = DateTime.Now;
                    _manager.Update(item);
                }
            }


            //rental.ReturnDate = DateTime.Now;

            //_manager.Update(rental);
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
