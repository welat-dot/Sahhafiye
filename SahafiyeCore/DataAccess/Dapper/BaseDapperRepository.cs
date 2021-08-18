using MySql.Data.MySqlClient;
using SahafiyeCore.Entities.Abstract;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Data;
using Dapper;
using System.Linq;
using SahafiyeCore.DataAccess.Query.MySQL.MySQLQuery;
using System.Linq.Expressions;
using System;
using System.Reflection;
using Dapper.Contrib.Extensions;
using Z.Dapper.Plus;

namespace SahafiyeCore.DataAccess.Dapper
{


    public class BaseDapperRepository<T> : IDapperRepository<T> where T : class, IEntity, new()
    {
        private IConfiguration configuration { get; }
        //public BaseDapperRepository()
        //{
        //    DefaultTypeMap.MatchNamesWithUnderscores = true;
        //}
          
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

        #region sync
        public int  insert(T entity,string tablename)
        {
           
            QueryWrite<T> query = new QueryWrite<T>();
            string sq = query.insertQuery(entity,tablename);
            using (var con = CreateDbConn())
             {
                var a = con.Query<T>(sq, entity);
                //return true;
                return 1;
            }

        }

        public bool update(T entity, string tablename,int id,Func<T,object> ppp)
        {
            QueryWrite<T> query = new QueryWrite<T>();
            string sq = query.updatQuery(entity, tablename, id);
            using (var con = CreateDbConn())
            {

                var a = con.Query<T>(sq, entity);
                return true;
            }

        }
        public void  delete( string tablename, int id)
        {

            string sq = "DELETE FROM " + tablename + " WHERE id = " + id.ToString();
            using (var con = CreateDbConn())
            {
                 con.Execute(sq);
            }

        }
        public T SelectByFilter(string tableName,string  filter)
        {
            QueryWrite<T> query = new QueryWrite<T>();

            using (var con = CreateDbConn())
            {
                try
                {
             
                    string sq = "";
                    sq = query.selectBySingleTable(tableName, filter);
                    List<T> listT = con.Query<T>(sq).ToList();
                    if (listT.Count == 0)
                        return new T();
                    return listT.FirstOrDefault<T>();                    
                }
                catch (Exception e)
                {
                    return  null;
                }
            }
          
        }
        public IQueryable<T> Syncfunctions(string sql, object parametre, T entity)
        {
            QueryWrite<T> queryWrite = new QueryWrite<T>();
            string  ad = queryWrite.insertQuery(entity,"user");

            using (var con = CreateDbConn())
            {
                var a = con.Execute(ad);
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

        #region async
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

        //public async Task<List<T>> AsyncSelectByFilter(string tableName, Expression<System.Func<T, bool>> filter=null)
        //{
        //    using (var con = CreateDbConn())
        //    {
        //        //DefaultTypeMap.MatchNamesWithUnderscores = true;
        //        QueryWrite<T> query = new QueryWrite<T>();
        //        string sq = query.selectBySingleTable(tableName, filter);
        //        //var b =.Wait();
        //        //return (ts.Count == 0) ? new List<T>() : (List<T>)ts;
        //        //return new List<T>();
        //        //    //(List<T>)await con.QueryAsync<T>(sq); 
        //        var a = await con.QueryAsync<T>(sq);
        //        var b = a.ToList();
        //        return b;
        //    }
        //}

       
        #endregion
    }
}
