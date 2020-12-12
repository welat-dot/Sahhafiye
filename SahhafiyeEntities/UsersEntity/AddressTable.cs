using SahafiyeCore.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace SahhafiyeEntities.UsersEntity
{
    public class AddressTable:IEntity
    {
        public int Id { get; set; }
        public int ParrentId { get; set; }
        public string Name { get; set; }
    }
}
