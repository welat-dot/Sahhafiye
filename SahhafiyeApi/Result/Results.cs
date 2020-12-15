using SahhafiyeEntities.ProductEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SahhafiyeApi.Result
{
    public class Results<T>
    {
        public bool isSuccess { get; set; } = false;
        public int kod { get; set; } = 1;
        public string mesaj { get; set; } = "heyyy";
        public T data { get; set; }
        
    }
}
