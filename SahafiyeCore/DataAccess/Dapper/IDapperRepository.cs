using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SahafiyeCore.DataAccess.Dapper
{
    public interface IDapperRepository<T>
    {
        #region Senkron fonksiyonlar
        T Add(T Data);
        T Update(T Data);
        T Delete(T Data);
        T Get(Expression<Func<T, bool>> filter);
        #endregion
        #region Async Fonksiyonlar
         //Task<bool> AddRange(List<T> Data);
         //Task<bool> UpdateRange(List<T> Data);
         //Task<bool> DeleteRange(List<T> Data);
         //Task<List<T>> GetAll(Expression<Func<T, bool>> filter = null);
        #endregion
    }
}
