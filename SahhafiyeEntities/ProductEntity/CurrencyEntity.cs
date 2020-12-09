using SahafiyeCore.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace SahhafiyeEntities.ProductEntity
{
    public class CurrencyEntity:IEntity
    {
        public int Id { get; set; }
        public string Name  { get; set; }
        public string Symbol { get; set; }
    }
}
