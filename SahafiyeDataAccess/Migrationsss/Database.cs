using System;
using MySql.Data.MySqlClient;
using Dapper;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using FluentMigrator.Runner;
using System.Reflection;

namespace SahafiyeDataAccess.Migrationsss
{
    public static class Database
    {
        public static void Migrate(String ConnectionString,string DBName)
        {
            using (var connection = new MySqlConnection(ConnectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("name", DBName);
                dataBaseName = DBName;
                var a = connection.Query("SELECT databasess.SCHEMA_NAME  FROM information_schema.SCHEMATA AS databasess WHERE databasess.SCHEMA_NAME = @name", parameters);
               
                if (connection.Query<string>("SELECT databasess.SCHEMA_NAME  FROM information_schema.SCHEMATA AS databasess WHERE databasess.SCHEMA_NAME = @name", parameters).AsList<string>().Count==0)
                {
                    connection.Execute($"CREATE DATABASE {DBName}");
                }

            }
           
        }
        public static void RunMigrations()
        {
            var serviceProvider = CreteServices();
            using(var scope=serviceProvider.CreateScope())
            {
                RunMigrations(scope.ServiceProvider); 
            }
        }
        private static IServiceProvider CreteServices()
        {
            return new ServiceCollection()
                .AddFluentMigratorCore()
                .ConfigureRunner(config =>
                               config.AddMySql5()
                                .WithGlobalConnectionString(conStr+" " +dataBaseName+" ;")
                                .ScanIn(typeof(Database).Assembly).For.Migrations())
                .AddLogging(config => config.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
        }
        public static void RunMigrations(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp();         


        }
        private const string conStr = "server = localhost; user = root; password = welat.123; database = ";
        private static string dataBaseName = "Demo3";
    }
}
