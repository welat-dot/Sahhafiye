using System;
using System.Collections.Generic;
using System.Text;

namespace SahafiyeCore.Utilitis.Result.Abstract
{
    public interface IDataResult<T>:IResult
    {
        string kod { get; }
    }
}
