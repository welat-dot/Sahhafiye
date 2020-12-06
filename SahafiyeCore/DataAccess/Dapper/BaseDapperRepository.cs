using SahafiyeCore.Entities.Abstract;
using System;
using System.Linq.Expressions;

namespace SahafiyeCore.DataAccess.Dapper
{
    public class BaseDapperRepository<T> : IDapperRepository<T> where T : class, IEntity, new()
    {
        #region Sync Functions
        public T Add(T Data)
        {
            throw new NotImplementedException();
        }
        public T Delete(int Id)
        {
            throw new NotImplementedException();
        }
        public T Get(Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }
        public T Update(T Data)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Async Functions
        //public async Task<bool> AddRange(List<T> Data)
        //{
        //    throw new NotImplementedException();
        //}
        //public async Task<bool> DeleteRange(List<T> Data)
        //{
        //    throw new NotImplementedException();
        //}
        //public async Task<List<T>> GetAll(Expression<Func<T, bool>> filter = null)
        //{
        //    throw new NotImplementedException();
        //}
        //public async Task<bool> UpdateRange(List<T> Data)
        //{
        //    throw new NotImplementedException();
        //}
        #endregion
    }
}
