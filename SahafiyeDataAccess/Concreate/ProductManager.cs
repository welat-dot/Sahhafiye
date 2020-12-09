using SahafiyeCore.DataAccess.Dapper;
using SahafiyeDataAccess.Abstract;
using SahhafiyeEntities.ProductEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SahafiyeDataAccess.Concreate
{
    public class ProductManager : BaseDapperRepository<Product>,IProductManager 
    {


    }
}
