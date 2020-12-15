using System;
using System.Collections.Generic;
using System.Text;

namespace SahafiyeCore.DataAccess.Query.MySQL
{
    class MySQLGenarateRepository : IMySQLGenarateRepository
    {
        public string selectAll(string tableName)
        {
            return "SELECT *FROM " + tableName;
        }

        public string selectByFiltred(string tableName, string filtre)
        {
            return "SELECT *FROM " + tableName + " WHERE " + filtre;
        }

        public string selectByFiltred(string tableName, List<string> filtre)
        {
            string Que = "SELECT *FROM " + tableName + " WHERE ";
            foreach (string filt in filtre)
            {
                Que = Que + " " + filt;
            }
            return Que;
        }

        public string selectByJoin(string tableNme, List<JoinParametre> joinList)
        {
            throw new NotImplementedException();
        }

        public string selectByJoinByLeftFiltred(string tableNme, List<JoinParametre> joinList, string filtre)
        {
            string Que = "SELECT *FROM " + tableNme;
            for (int i=0;i<joinList.Count;i++)
            {
                Que = Que + " LEFT JOİN ON " +
                joinList[i].tableName + "." + joinList[i].firstParametre + " = " +
                tableNme + "." + joinList[i].secondParametre;
            }
            return Que + " WHERE " + filtre;
        }

        public string selectByJoinByLeftFiltred(string tableNme, List<JoinParametre> joinList, List<string> filtre)
        {
            string Que = "SELECT *FROM " + tableNme;
            for (int i = 0; i < joinList.Count; i++)
            {
                Que = Que + " LEFT JOİN ON " +
                joinList[i].tableName + "." + joinList[i].firstParametre + " = " +
                tableNme + "." + joinList[i].secondParametre;
            }
            Que = Que + " WHERE";
            for (int i=0;i<filtre.Count;i++)
            {
                Que = Que + " " + filtre[i];
            }
            return Que;

        }
    }
}
