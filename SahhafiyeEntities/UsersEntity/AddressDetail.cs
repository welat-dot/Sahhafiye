using SahafiyeCore.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace SahhafiyeEntities.UsersEntity
{
    public class AddressDetail:IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string  Adress { get; set; }
        public int UserId { get; set; }
    }
}
