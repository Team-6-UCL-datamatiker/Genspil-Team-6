namespace Genspil_Team_6
{
    public class Employee
    {
        public string Name { get; set; }
        public string UserId { get; set; }
        public int AccessLevel { get; set; }

        public Employee(string name, string userId)
        {
            Name = name;
            UserId = userId;
        }
        public Employee(string name, string userId, int accessLevel)
        {
            Name = name;
            UserId = userId;
            AccessLevel = accessLevel;
        }
        public override string ToString()
        {
            return $"Name: {Name}, UserID: {UserId}, AccessLevel: {AccessLevel}";
        }
    }
}
