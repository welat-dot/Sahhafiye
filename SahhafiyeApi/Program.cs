using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using SahhafiyeBusiness.DepencyResolver.Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac;

namespace SahhafiyeApi
{
    public class Program
	{
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureContainer<ContainerBuilder>(builder=>
                {
                    builder.RegisterModule(new AutofacDepencyModule());


                })
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
	}
}
