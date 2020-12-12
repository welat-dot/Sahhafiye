using SahafiyeCore.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace SahhafiyeEntities.UsersEntity
{
    public class StoreInfo:IEntity
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public string  TaxIdN { get; set; }
        public int UserId { get; set; }
        public int AddressId { get; set; }
        public string  Adresss { get; set; }
        public DateTime? RecordTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        
    }
}
