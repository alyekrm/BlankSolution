﻿using Core.Entities.Concrete;
using Core.Utilies.Result;
using Core.Utilies.Security.JWT;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);

        IDataResult<User> Login(UserForLoginDto userForLoginDto);

        IResult UserExits(string email);

        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
