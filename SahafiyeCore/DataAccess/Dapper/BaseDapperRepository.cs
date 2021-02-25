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

        #region connection
        private MySqlConnection connection()
        {
            return new MySqlConnection(@"server = localhost; user = root; password = welat.123; database = Sahhafiye_DB;");
        }
         private IDbConnection CreateDbConn ()
        {
            var conn = connection();
            conn.Open();
            return conn;
        }
        #endregion 

        #region syncron
        public IQueryable<T> Syncfunctions(string sql, object parametre)
        {
            using(var con =CreateDbConn())
            {
                var a = con.Execute(sql, parametre);
                return con.Query<T>(sql, parametre).AsQueryable<T>();
            }
        }
        public IQueryable<T> Syncfunctions(string sql)
        {
            using (var con = CreateDbConn())
            {
                IEnumerable<T> data = con.Query<T>(sql);

                return data.AsQueryable<T>();
            }
        }
        public T Get(string sql)
        {
            using (var con = CreateDbConn())
            {
                List<T> data = con.Query<T>(sql).ToList();

                T item = data.Count == 0 ? null : data.First();
                return item;                
            }
        }
        public bool Insert(string sql)
        {
            using (var con = CreateDbConn())
            {             

                return con.ExecuteScalar<bool>(sql);
            }
        }
        #endregion

        #region asyncron
        public async Task<IQueryable<T>> AsyncFunctions(string sql, object parametre)
        {
            using(var con =CreateDbConn())
            {
                IEnumerable<T> data =await  con.QueryAsync<T>(sql, parametre);
               
                return data.AsQueryable<T>();
            }
        }
        public async Task<IQueryable<T>> AsyncFunctions(string sql)
        {
            using (var con = CreateDbConn())
            {
                IEnumerable<T> data = await con.QueryAsync<T>(sql);

                return data.AsQueryable<T>();
            }
        }      
        #endregion
    }
}
