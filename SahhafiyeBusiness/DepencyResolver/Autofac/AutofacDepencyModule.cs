using Autofac;
using SahafiyeDataAccess.Abstract;
using SahafiyeDataAccess.Concreate;
using SahhafiyeBusiness.Abstract;
using SahhafiyeBusiness.Concreate;
using SahafiyeCore.DataAccess.Query.MySQL;
using SahafiyeCore.Utilitis.Security.JWT;

namespace SahhafiyeBusiness.DepencyResolver.Autofac
{
    public class AutofacDepencyModule:Module
	{
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductRepo>().As<IProductRepo>();
            builder.RegisterType<ProductManager>().As<IProductManager>();
            builder.RegisterType<ProductService>().As<IProductService>();
            builder.RegisterType<MySQLGenarateRepository >().As<IMySQLGenarateRepository>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();
        }

    }
}
