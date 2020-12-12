using SahafiyeCore.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace SahhafiyeEntities.ProductEntity
{
    public class Currency:IEntity
    {
        public int Id { get; set; }
        public string Name  { get; set; }
        public string Symbol { get; set; }
    }
}
