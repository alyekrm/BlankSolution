﻿using Business.Abstract;
using Business.Constrants;
using Core.Entities.Concrete;
using Core.Utilies.Result;
using Core.Utilies.Security.Hashing;
using Core.Utilies.Security.JWT;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        IUserService _userService;
        ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService,ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var operationClaims = _userService.GetClaims(user);
            var accessToken=_tokenHelper.CreateToken(user, operationClaims.Data);
            return new SuccessDataResult<AccessToken>(Messages.AccessTokenCreated, accessToken);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email) ;
            

            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.Data.PasswordHash,userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }
            return new SuccessDataResult<User>(Messages.SuccesfulLogin,userToCheck.Data);
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            User user = new User() {Email=userForRegisterDto.Email,
                FirstName=userForRegisterDto.FirstName,
                LastName=userForRegisterDto.LastName,
                PasswordHash=passwordHash,
                PasswordSalt=passwordSalt,
                Status=true };
            _userService.Add(user);
            return new SuccessDataResult<User>(Messages.UserAdded,user);
        }

        public IResult UserExits(string email)
        {
            if (_userService.GetByMail(email).Data!=null)
            {
                return new ErrorResult(Messages.UserAlreadyExits);
            }
            return new SuccessResult();
        }
    }
}
