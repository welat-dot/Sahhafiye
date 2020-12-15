using System;
using System.Collections.Generic;
using System.Text;

namespace SahafiyeCore.Utilitis.Result.Concreate
{
    public class ErrorResult:Result
    {
        public ErrorResult(string message,string kod) : base(false, message,kod)
        {
           
        }
        public ErrorResult(string message) : base(false, message)
        {

        }
        public ErrorResult() : base(false)
        {
            
        }
        
    }
}
