using SahafiyeCore.Entities.Abstract;

namespace SahhafiyeEntities.ProductEntity
{
    public class Categorys:IEntity
    {
        public int Id { get; set; }
        public int ParrentId { get; set; }
        public string Name { get; set; }
    }
}
