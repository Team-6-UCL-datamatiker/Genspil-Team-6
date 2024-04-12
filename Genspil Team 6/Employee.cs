using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil_Team_6
{
    public class Employee(string name, string password, int accessLevel)
    {
        public string Name { get; set; } = name;
        public string Password { get; set; } = password;
        public int AccessLevel { get; set; } = accessLevel;
    }
}
