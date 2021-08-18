using Newtonsoft.Json;
using SahafiyeCore.DataAccess.Query.MySQL.ClassModel;
using SahafiyeCore.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace SahafiyeCore.DataAccess.Query.MySQL.MySQLQuery
{
    public class QueryWrite<T> : IQueryWrite<T> where T : class, IEntity, new()
    {
        public string insertQuery(T entity,string tableName)
        {           
          
            return insertWrite(modelMake(entity), tableName);
        }
        public string updatQuery(T entity, string tableName,int id)
        {
            

            return updateWrite(modelMake(entity), tableName,id);
        }
        private string  insertWrite(ClassVariableModel models ,string tableNme)
        {
           

            VariableHelper helper = new VariableHelper();
            string insertQue = "INSERT INTO " + tableNme + "  (";
            insertQue += string.Join(",", models.VariableName) + " )";
            insertQue += " VALUES( ";
            for (int i = 0; i<models.VariableName.Count;i++)
            {
                    insertQue += "@"+ models.VariableName[i]+",";                   
                
            }
            insertQue = insertQue.Substring(0, insertQue.Length - 1) + " );";
            insertQue += " SELECT last_insert_id()) from "+tableNme+";";
            return insertQue;
        }
        private string updateWrite(ClassVariableModel models, string tableNme,int id)
        {
           
            VariableHelper helper = new VariableHelper();
            string updateQue = "UPDATE " + tableNme + " set ";
            Dictionary<string, dynamic> ddd = new Dictionary<string, dynamic>();


            for (int i = 0;i<models.Variable.Count;i++)
            {
                updateQue += models.VariableName[i] + " =  @"+ models.VariableName[i]+",";
            }
            updateQue = updateQue.Substring(0, updateQue.Length - 1);
            updateQue += " WHERE Id = @Id";
            return updateQue;
        }
        private ClassVariableModel modelMake(T entity)
        {
           
            ClassVariableModel variableModels = new ClassVariableModel();
            foreach (PropertyInfo info in entity.GetType().GetProperties())
            {
               if(info.Name != "Id" && info.PropertyType.Namespace == "System")
                {
                    variableModels.VariableName.Add(info.Name);
                    //variableModels.VariableType.Add(info.PropertyType.FullName.Split(".")[1]);
                    //if (info.PropertyType.FullName.Split(".")[1] == "Byte[]")
                    //    variableModels.Variable.Add("'"+ (byte[])info.GetValue(entity) + "'");
                    //else
                    //    variableModels.Variable.Add(info.GetValue(entity).ToString());
                }

            }
            return variableModels;
        }

        public string selectBySingleTable(string tableName, string  filter ="")
        {
            string tb = tableName.Substring(0, 3);
            string sq = "select *from " + tableName ;
            if (!string.IsNullOrEmpty(filter))
                return sq += " where " + filter;          
            return sq;
        }

    }
}
