using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil_Team_6
{
    internal class Employee(string name, string userID, int accessLevel)
    {
        public string Name { get; set; } = name;
        public string UserID { get; set; } = userID;
        public int AccessLevel { get; set; } = accessLevel;
    }
}
