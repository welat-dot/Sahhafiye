using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SahafiyeCore.DataAccess.Query.MySQL.MySQLQuery;
using SahafiyeDataAccess.Migrations;
using System.Collections.Generic;
using System.Globalization;
//using SahhafiyeApi.socketDeneme;

namespace SahhafiyeApi
{
    public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			
			services.AddControllers();
			services.AddSwaggerDocument();
           
           
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
            //var supportedCultures = new List<CultureInfo> { };
            var gb = new CultureInfo(CultureInfo.CurrentCulture.Name);
            gb = CultureInfo.CurrentCulture;
			//gb.DateTimeFormat.LongDatePattern = "yyyy-MM-dd HH:mm:ss tt";
			//gb.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd";
			//supportedCultures.Add(gb);
			var culture = CultureInfo.CreateSpecificCulture("tr-TR");
			culture.DateTimeFormat.LongDatePattern = "yyyy-MM-dd HH:mm:ss tt";
			culture.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd";
            CultureInfo.DefaultThreadCurrentCulture = culture;
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			app.UseOpenApi();
			app.UseSwaggerUi3();
			app.UseHttpsRedirection();
			
			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
			VariableHelper variableHelper = new VariableHelper();
			variableHelper.dictFill();

			Database.Migrate("server = localhost; user = root; password = welat.123; database = sys;", "sahhafiye_db");
            Database.RunMigrations();
        }
	}
}
