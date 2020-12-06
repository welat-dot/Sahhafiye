using SahafiyeCore.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace SahafiyeCore.Entities.Concreate
{
    class UserInfo:IEntity
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = "Unknown";
        public string Role { get; set; } = "Unknown";        
        public List<string> Authority{ get; set; }

    }
}
