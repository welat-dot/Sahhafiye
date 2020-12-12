using SahafiyeCore.Entities.Abstract;
using System;

namespace SahhafiyeEntities.UsersEntity
{
    public class Users:IEntity
	{
        public int Id { get; set; }
        public string EmailAdress { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PaswordSalt { get; set; }
        public int UserDetailId { get; set; }
        public DateTime? RecordTime { get; set; }
        public DateTime? UpdateTime { get; set; }
       

    }
}
