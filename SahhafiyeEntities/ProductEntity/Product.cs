using SahafiyeCore.Entities.Abstract;
using SahhafiyeEntities.UsersEntity;

namespace SahhafiyeEntities.ProductEntity
{
    public class Product:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool New { get; set; }
        public double Price { get; set; }
        public int Stok { get; set; }
        public int Condition { get; set; }
        public int CategoryId { get; set; }
        public int CurencyId { get; set; }
        public int StoreId { get; set; }
        public string PhotoPath { get; set; }
        public string Description { get; set; }
    }
}
