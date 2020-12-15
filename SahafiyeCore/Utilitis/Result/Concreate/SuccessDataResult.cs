using System;
using System.Collections.Generic;
using System.Text;

namespace SahafiyeCore.Utilitis.Result.Concreate
{
    public class SuccessDataResult<T>:DataResult<T>
    {
        public SuccessDataResult(T Data, string Message,string kod) : base(Data, Message, true,kod)
        {

        }
        public SuccessDataResult(T Data,string Message):base(Data,Message,true)
        {

        }
        public SuccessDataResult(T Data) : base(Data, true)
        {

        }
    }
}
