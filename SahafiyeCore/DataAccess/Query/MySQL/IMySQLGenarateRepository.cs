using System;
using System.Collections.Generic;
using System.Text;

namespace SahafiyeCore.DataAccess.Query.MySQL
{
   public  interface IMySQLGenarateRepository
    {
        string selectAll(string tableName);
        string selectByFiltred(string tableName, string filtre);
        string selectByFiltred(string tableName,List<string> filtre);
        string selectByJoin(string tableNme, List<JoinParametre> joinList);
        string selectByJoinByLeftFiltred(string tableNme, List<JoinParametre> joinList, string filtre);
        string selectByJoinByLeftFiltred(string tableNme, List<JoinParametre> joinList,List <string>filtre);
    }
}
