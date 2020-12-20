using System;
using System.Collections.Generic;
using System.Text;

namespace SahafiyeCore.DataAccess.Query.MySQL
{
    public class MysqlQueryLists
    {
        public List<string> SelectList { get; set; } = new List<string>();
        public List<string> FromList { get; set; } = new List<string>();
        public List<string> LeftList { get; set; } = new List<string>();
        public List<string> RightList { get; set; } = new List<string>();
        public List<string> InnerList { get; set; } = new List<string>();
        public List<string> WhereList { get; set; } = new List<string>();
    }
}
