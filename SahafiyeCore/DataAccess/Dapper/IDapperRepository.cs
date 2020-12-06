using SahafiyeCore.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SahafiyeCore.DataAccess.Dapper
{
    public interface IDapperRepository<T> where T : class, IEntity
    {
        #region Senkron fonksiyonlar
        T Add(T Data);
        T Update(T Data);
        T Delete(int Id);
        T Get(Expression<Func<T, bool>> filter);
        #endregion
        #region Async Fonksiyonlar
         //Task<bool> AddRangeAsync(List<T> Data);
         //Task<bool> UpdateRangeAsync(List<T> Data);
         //Task<bool> DeleteRangeAsync(List<T> Data);
         //Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null);
        #endregion
    }
}
