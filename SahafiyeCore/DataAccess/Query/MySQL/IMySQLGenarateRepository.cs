using System;
using System.Collections.Generic;
using System.Text;

namespace SahafiyeCore.DataAccess.Query.MySQL
{
   public  interface IMySQLGenarateRepository
    {
        string BaseQuery(MysqlQueryLists mysqlQueryLists);
        string LeftQuery(string Que,List<string> LeftList);
        string RigtQuery(string Que,List<string> RightList);
        string InnerQuery(string Que,List<string> InnerLİst);
        string WhereQuery(string Que,List<string> WhereList);


    }
}
