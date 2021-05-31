using SahafiyeCore.DataAccess.Query.MySQL.ClassModel;
using SahafiyeCore.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SahafiyeCore.DataAccess.Query.MySQL.MySQLQuery
{
    public class QueryWrite<T> : IQueryWrite<T> where T : class, IEntity, new()
    {
        public string insertQuery(T entity,string tableName)
        {
            
            ClassVariableModel variableModels = new  ClassVariableModel();
            foreach (PropertyInfo info in entity.GetType().GetProperties())
            {
                //ClassVariableModel classVariable = new ClassVariableModel();
                variableModels.VariableName.Add(info.Name);
                variableModels.VariableType.Add(info.PropertyType.FullName.Split(".")[1]);
                if (info.PropertyType.FullName.Split(".")[1] == "Byte[]")
                    variableModels.Variable.Add(Encoding.UTF8.GetString((byte[])info.GetValue(entity)));
                else
                    variableModels.Variable.Add(info.GetValue(entity).ToString());

            }
            return insertWrite(variableModels, tableName);
        }
        private string  insertWrite(ClassVariableModel models ,string tableNme)
        {
            List<string> strType = new List<string>();
            strType.Add("String");
            strType.Add("DateTime");
            strType.Add("Char");
            strType.Add("Byte[]");
            string insertQue = "INSERT INTO " + tableNme + "  (";
            insertQue += string.Join(",", models.VariableName) + " )";
            insertQue += " VALUES( ";
            for (int i = 0; i<models.Variable.Count;i++)
            {
                if (strType.Contains(models.VariableType[i]))
                {
                    if(models.VariableType[i] =="Byte[]")
                        insertQue += "'" + Encoding.UTF8.GetBytes(models.Variable[i]) + "',";
                    else
                    {
                        if (models.VariableType[i] == "DateTime")
                            insertQue += "str_to_date('" + models.Variable[i] + "','%d.%m.%Y %H:%i:%s'),";
                        else
                            insertQue += "'" + models.Variable[i] + "',";
                    }
                        
                        
                }
                else
                    insertQue += models.Variable[i] + ",";
            }
            insertQue = insertQue.Substring(0, insertQue.Length - 1) + " );";
            insertQue += " SELECT last_insert_id(), max(Id) from "+tableNme+";";
            return insertQue;
        }
    }
}
