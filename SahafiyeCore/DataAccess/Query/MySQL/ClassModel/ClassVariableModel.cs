using System;
using System.Collections.Generic;
using System.Text;

namespace SahafiyeCore.DataAccess.Query.MySQL.ClassModel
{
    public class ClassVariableModel
    {
        public List<string> VariableName { get; set; } = new List<string>();
        public List<string> VariableType { get; set; } = new List<string>();
        public List<dynamic> Variable { get; set; } = new List<dynamic>();     
    }
}
 