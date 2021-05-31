using SahafiyeCore.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SahafiyeCore.DataAccess.Dapper
{
    public interface IDapperRepository<T> where T : class, IEntity
    {
        #region Senkron Functions
        IQueryable<T> Syncfunctions(string sql, object parametre, T entity);
        IQueryable<T> Syncfunctions(string sql);
        T Get(string sql);
        bool Insert(string sql);
        //bool Update(string sql);
        //bool delete(string table, int Id);
        #endregion
        #region Async Functions
        Task<IQueryable<T>> AsyncFunctions(string sql, object parametre);
        Task<IQueryable<T>> AsyncFunctions(string sql);


        #endregion
    }
}
