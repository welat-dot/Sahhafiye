using SahafiyeCore.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace SahafiyeCore.DataAccess.Query.MySQL.MySQLQuery
{
    public interface IQueryWrite<T> where T : class,IEntity,new()
    {
        string insertQuery(T entity, string tableName);
        string updatQuery(T entity, string tableName,int id);

    }
}
