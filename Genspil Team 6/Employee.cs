using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil_Team_6
{
    public class Employee
    {
        public string Name { get; set; }
        public string UserID { get; set; }
        public int AccessLevel { get; set; }

        public Employee(string name, string userID)
        {
            Name = name;
            UserID = userID;
        }
        public Employee(string name, string userID, int accessLevel)
        {
            Name = name;
            UserID = userID;
            AccessLevel = accessLevel;
        }
        public override string ToString()
        {
            return $"Name: {Name}, UserID: {UserID}, AccessLevel: {AccessLevel}";
        }
    }
}
