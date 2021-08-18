using SahafiyeCore.Entities.Abstract;
using System;
using System.Collections.Generic;

namespace SahhafiyeEntities.UsersEntity
{
    public class users:IEntity
	{
        public int Id { get; set; }
        public string EmailAdress { get; set; }
        public string UserName { get; set; }
        public string TelNumber { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        //public int  UserDetailId { get; set; }
        public DateTime RecordDate { get; set; }
        public DateTime UpdateDate { get; set; }
        //public List<string> lst { get; set; }
        //public List<UsersDetail> lst1 { get; set; }




    }
}
