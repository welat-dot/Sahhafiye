using SahafiyeCore.Entities.Abstract;

namespace SahhafiyeEntities.Dto
{
    public abstract class DtoAbstract:IDTO
    {
        public string EmailAdress { get; set; }
        public string Password { get; set; }
    }
}
