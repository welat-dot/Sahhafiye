using System;
using System.Collections.Generic;
using System.Text;

namespace SahafiyeCore.DataAccess.Query.MySQL.MySQLQuery
{
    public class VariableHelper
    {
        public static Dictionary<string, string> variableDictionary { get; set; } = new Dictionary<string, string>();
        public void dictFill()
        {            
            variableDictionary.Add("Char"     , "CharCastFunc");
            variableDictionary.Add("Byte"     , "ByteCastFunc");
            variableDictionary.Add("Byte[]"   , "ByteArrCastFunc");
            variableDictionary.Add("String"   , "StringCastFunc");
            variableDictionary.Add("Int16"    , "Int16CastFunc");
            variableDictionary.Add("Int32"    , "Int32CastFunc");
            variableDictionary.Add("Int64"    , "Int64CastFunc");
            variableDictionary.Add("Float"    , "FloatCastFunc");
            variableDictionary.Add("Double"   , "DoubleCastFunc");
            variableDictionary.Add("DateTime" , "DateCastFunc");
        }

        public string  getSqlQue(string func,string data)
        {
            VariableHelper helper = new VariableHelper();
            Type type = typeof(VariableHelper);
            var methd = type.GetMethod(func);
            return methd.Invoke(helper, new object[] { data }).ToString();
        }
        public string CharCastFunc(string data)
        {           
            return "'" + data + "',";
        }
        public string ByteCastFunc(string data)
        {
            return  data + "," ;
        }
        public string ByteArrCastFunc(string data)
        {
            return "'" + Encoding.UTF8.GetBytes(data) + "',";
        }
        public string StringCastFunc(string data)
        {

            return "'" + data + "',";
        }
        public string Int16CastFunc(string data)
        {
            return data + ",";
        }
        public string Int32CastFunc(string data)
        {
            return data + ",";
        }
        public string Int64CastFunc(string data)
        {

            return data + ","; 
        }
        public string FloatCastFunc(string data)
        {
            return data+",";
        }
        public string DoubleCastFunc(string data)
        {
            return data + ",";
        }
        public string DateCastFunc(string data)
        {

            return "str_to_date('" + data + "', '%d.%m.%Y %H:%i:%s'),";
        }
    }
   
}
