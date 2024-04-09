using System.Diagnostics;

namespace Genspil_Team_6
{
    internal class Employee(string userID, string name, string password, int accessLevel)
    {
        public string UserID { get; set; } = userID;
        public string Name { get; set; } = name;
        public string Password { get; set; } = password;
        public int AccessLevel { get; set; } = accessLevel;
        public string CreateInventoryItem()
        {
            return $"{UserID};{Name};{Password};{AccessLevel}";
        }
    }
}
