using SahafiyeDataAccess.Abstract;
using SahhafiyeEntities.ProductEntity;
using System.Linq;
using System.Threading.Tasks;
using SahafiyeCore.DataAccess.Query.MySQL;
using System.Collections.Generic;

namespace SahafiyeDataAccess.Concreate
{
    public class ProductRepo:IProductRepo
    {
        private IProductManager productManager;
        private IMySQLGenarateRepository mySQLGenarate;
        public ProductRepo  (IProductManager productManager,IMySQLGenarateRepository mySQLGenarate )
        {
           this.productManager = productManager;
           this.mySQLGenarate = mySQLGenarate;
        }

        public async Task<IQueryable<Product>> ProductGetAll()
        {
            MysqlQueryLists queryLists = new MysqlQueryLists();
            queryLists.SelectList.Add("*");
            queryLists.FromList.Add("product as urun");
            queryLists.WhereList.Add(" urun.Condition < 20");
            string que = mySQLGenarate.BaseQuery(queryLists);            
            string que2 = "";
            queryLists.LeftList.Add(" storeInfo as store ON store.Id = urun.StoreId");
            que2 = mySQLGenarate.LeftQuery(que, queryLists.LeftList);
            que2 = mySQLGenarate.WhereQuery(que2, queryLists.WhereList);
            var x = await productManager.AsyncFunctions(que2);
            que = mySQLGenarate.WhereQuery(que, queryLists.WhereList);
            return await   productManager.AsyncFunctions(que);
        }
        //public async Task<IQueryable<Product>> ProductAdd()
        //{
           

        //}

    }
}
