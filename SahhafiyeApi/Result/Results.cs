using SahhafiyeEntities.ProductEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SahhafiyeApi.Result
{
    public class Results
    {
        public int Durum { get; set; } = 1;
        public string mesaj { get; set; } = "heyyy";
        public List<Product> data { get; set; }
    }
}
