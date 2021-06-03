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
            for (int i = 0; i<models.Variable.Count;i++)
            {
                insertQue += helper.getSqlQue(
                    VariableHelper.variableDictionary[models.VariableType[i]],
                    models.Variable[i]
                    );
            }
            insertQue = insertQue.Substring(0, insertQue.Length - 1) + " );";
            insertQue += " SELECT last_insert_id(), max(Id) from "+tableNme+";";
            return insertQue;
        }
        private string updateWrite(ClassVariableModel models, string tableNme,int id)
        {
            VariableHelper helper = new VariableHelper();
            string updateQue = "UPDATE " + tableNme + " set ";
            for(int i = 0;i<models.Variable.Count;i++)
            {
                updateQue += models.VariableName + " =  ";
                updateQue += helper.getSqlQue(
                    VariableHelper.variableDictionary[models.VariableType[i]],
                    models.Variable[i]
                    ); 
            }
            updateQue = updateQue.Substring(0, updateQue.Length - 1);
            updateQue += " WHERE Id = " + id.ToString();
            return updateQue;
        }
        private ClassVariableModel modelMake(T entity)
        {
            ClassVariableModel variableModels = new ClassVariableModel();
            foreach (PropertyInfo info in entity.GetType().GetProperties())
            {
                variableModels.VariableName.Add(info.Name);
                variableModels.VariableType.Add(info.PropertyType.FullName.Split(".")[1]);
                if (info.PropertyType.FullName.Split(".")[1] == "Byte[]")
                    variableModels.Variable.Add(Encoding.UTF8.GetString((byte[])info.GetValue(entity)));
                else
                    variableModels.Variable.Add(info.GetValue(entity).ToString());

            }
            return variableModels;
        }

    }
}
