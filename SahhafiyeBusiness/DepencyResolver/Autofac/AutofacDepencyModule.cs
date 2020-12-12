using Autofac;
using SahafiyeDataAccess.Abstract;
using SahafiyeDataAccess.Concreate;
using SahhafiyeBusiness.Abstract;
using SahhafiyeBusiness.Concreate;

namespace SahhafiyeBusiness.DepencyResolver.Autofac
{
    public class AutofacDepencyModule:Module
	{
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductRepo>().As<IProductRepo>();
            builder.RegisterType<ProductManager>().As<IProductManager>();
            builder.RegisterType<ProductService>().As<IProductService>();
        }

    }
}
