using System;
using System.Collections.Generic;
using System.Text;

namespace SahafiyeCore.Utilitis.Result.Abstract
{
    public interface IDataResult<T>:IResult
    {
        //public string kod { get; }
        public T Data { get;}
    }
}
