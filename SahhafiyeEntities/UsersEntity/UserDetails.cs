using SahafiyeCore.Entities.Abstract;

namespace SahhafiyeEntities.UsersEntity
{
    public class UsersDetail:IEntity
	{
        public int Id { get; set; }
        public string  FirstName { get; set; }
        public string LastName { get; set; }
    }
}
