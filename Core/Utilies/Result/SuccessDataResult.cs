using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilies.Result
{
    public class SuccessDataResult<T>:DataResult<T>
    {
        public SuccessDataResult(string message,T data):base(true,data,message)
        {

        }

        public SuccessDataResult(T data):base(true,data)
        {

        }

        public SuccessDataResult(string message):base(true,default,message)
        {

        }
        public SuccessDataResult():base(true,default)
        {

        }
    }
}
