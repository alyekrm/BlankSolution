using Business.Abstract;
using Business.Constrants;
using Core.Entities.Concrete;
using Core.Utilies.Result;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {

        IUserDal _manager;

        public UserManager(IUserDal manager)
        {
            _manager = manager;
        }

        public IResult Add(User user)
        {
            _manager.Add(user);
            return new SuccessResult();
           
        }

        public IDataResult<User> GetByMail(string email)
        {
           
            return new SuccessDataResult<User>( _manager.Get(filter:u=>u.Email==email));
        }

        public IDataResult< List<OperationClaim> >GetClaims(User user)
        {

            return new SuccessDataResult<List<OperationClaim>>( _manager.GetClaims(user));
        }
    }
}
