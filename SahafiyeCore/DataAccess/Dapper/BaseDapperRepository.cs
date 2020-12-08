using MySql.Data.MySqlClient;
using SahafiyeCore.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Data;
using Dapper;
using System.Linq;

namespace SahafiyeCore.DataAccess.Dapper
{
    

    public class BaseDapperRepository<T> : IDapperRepository<T> where T : class, IEntity, new()
    {
        private IConfiguration configuration { get; }
        private MySqlConnection connection()
        {
            return new MySqlConnection(configuration.GetSection("DefaultConn").Get<string>());
        }
       private IDbConnection CreateDbConn ()
        {
            var conn = connection();
            conn.Open();
            return conn;
        }
        public BaseDapperRepository(string _tableName)
        {

        }

        public IQueryable<T> Syncfunctions(string sql, object parametre)
        {
            using(var con =CreateDbConn())
            {
                return con.Query<T>(sql, parametre).AsQueryable<T>();
            }
        }

        public async Task<IQueryable<T>> AsyncFunctions(string sql, object parametre)
        {
            using(var con =CreateDbConn())
            {
                IEnumerable< T> data =await  con.QueryAsync<T>(sql, parametre);
               
                return data.AsQueryable<T>();
            }
        }

       
      
    
    }
}
