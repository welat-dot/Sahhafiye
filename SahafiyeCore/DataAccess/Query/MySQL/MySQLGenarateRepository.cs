using System;
using System.Collections.Generic;
using System.Text;

namespace SahafiyeCore.DataAccess.Query.MySQL
{
    public class MySQLGenarateRepository : IMySQLGenarateRepository
    {
        public string BaseQuery(MysqlQueryLists mysqlQueryLists)
        {
            string Que = "SELECT ";
            for (int i = 0; i < mysqlQueryLists.SelectList.Count; i++)
                Que += mysqlQueryLists.SelectList[i];
            if(mysqlQueryLists.FromList.Count!=0)
            {
                Que += "FROM ";
                for (int i = 0; i < mysqlQueryLists.FromList.Count; i++)
                    Que += mysqlQueryLists.FromList[i];
            }


            return Que;
        }
        public string InnerQuery(string Que,List<string> InnerLİst)
        {
            for (int i = 0; i < InnerLİst.Count; i++)
                Que += " INNER JOİN " + InnerLİst[i];
            return Que;
        }      
        public string LeftQuery(string Que, List<string> LeftList)
        {
            for (int i = 0; i < LeftList.Count; i++)
                Que += " LEFT OUTER JOIN  " + LeftList[i];
            return Que;
        }        
        public string RigtQuery(string Que, List<string> RightList)
        {
            for (int i = 0; i < RightList.Count; i++)
                Que += " RIGHT OUTER JOIN  " + RightList[i];
            return Que;
        } 
        public string WhereQuery(string Que,List<string> WhereList)
        {
            Que += " WHERE ";
            for (int i = 0; i < WhereList.Count; i++)
                Que += WhereList[i];
            return Que;
        }
        
    }
}
