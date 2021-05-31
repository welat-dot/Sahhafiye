using Autofac;
using SahafiyeDataAccess.Abstract;
using SahafiyeDataAccess.Concreate;
using SahhafiyeBusiness.Abstract;
using SahhafiyeBusiness.Concreate;
using SahafiyeCore.DataAccess.Query.MySQL;
using SahafiyeCore.DataAccess.Query.MySQL.MySQLQuery;
using SahafiyeCore.Utilitis.Security.JWT;
using SahafiyeCore.Utilitis.Result.Abstract;

namespace SahhafiyeBusiness.DepencyResolver.Autofac
{
    public class AutofacDepencyModule:Module
	{
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductRepo>().As<IProductRepo>();
            builder.RegisterType<ProductManager>().As<IProductManager>();
            builder.RegisterType<ProductService>().As<IProductService>();

            builder.RegisterType<UserRepo>().As<IUserRepo>();
            builder.RegisterType<UserManager>().As<IUserManager>();
            builder.RegisterType<AuthService>().As<IAuthService>();
            //builder.RegisterGeneric(typeof(IQueryWrite<>)).As(typeof(QueryWrite<>)).InstancePerDependency();
            builder.RegisterType<MySQLGenarateRepository>().As<IMySQLGenarateRepository>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();
        }

    }
}
