﻿using Business.Abstract;
using Business.Constrants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcers.Validation;
using Core.Utilies.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BusinessManager : IBusiness
    {
        ICarDal _manager;

        public BusinessManager(ICarDal manager)
        {
            _manager = manager;
        }

        
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
           
            _manager.Add(car);
            return new SuccessResult(Messages.CarAdded);
         
        }

        public IResult Delete(Car car)
        {
            _manager.Delete(car);
            return new SuccessResult(Messages.CarDeleted);

        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(Messages.CarListed,_manager.GetAll());
        }

        public IDataResult<Car> GetByld(int id)
        {
            return new SuccessDataResult<Car>(Messages.CarListed,_manager.Get(p=>p.Id==id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(Messages.CarListed,_manager.GetCarDetails());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(Messages.CarListed,_manager.GetAll(p => p.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(Messages.CarListed,_manager.GetAll(p => p.ColorId == id));
        }

        public IResult Update(Car car)
        {
            _manager.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }
        
    }
}
