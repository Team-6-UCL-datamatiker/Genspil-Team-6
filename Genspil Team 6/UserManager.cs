using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil_Team_6
{
    internal class UserManager
    {
        private List<Employee> employees = new List<Employee>();
        private string solutionDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        private string userDatabasePath;

        public UserManager()
        {
            userDatabasePath = Path.Combine(solutionDirectory, "UserDatabase.txt");
        }

        public Employee Login()
        {
            while (true)
            {
                Console.Write("Username: ");
                string username = Console.ReadLine();
                Console.Write("\nPassword: ");
                string password = Console.ReadLine();

                foreach (Employee employee in this.employees)
                {
                    if (employee.Name == username && employee.Password == password)
                    {
                        return employee;
                    }
                }
                Console.WriteLine("Invalid username or password. Please try again");
                Console.ReadLine();
                Console.Clear();
            }
        }

        public void AddUser()
        {
            Console.Clear();

            Console.Write("Enter Username: ");
            string username = Console.ReadLine();
            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            this.employees.Add(new Employee(username, password, 1));
            SaveUsersToFile();
            Console.WriteLine($"{username} added to the system!");
            Console.ReadLine();
        }

        public void RemoveUser()
        {
            Console.Write("Enter Username of user to remove: ");
            string username = Console.ReadLine();

            Employee employeeToRemove = null;

            foreach (Employee employee in this.employees)
            {
                if (employee.Name == username)
                {
                    employeeToRemove = employee;
                    break;
                }
            }

            if (employeeToRemove != null)
            {
                this.employees.Remove(employeeToRemove);
                SaveUsersToFile();
                Console.WriteLine($"{username} was successfully removed!");
            }
            else
            {
                Console.WriteLine("User not found!");
            }
            Console.ReadLine();
        }

        public void SaveUsersToFile()
        {
            try
            {
                List<string> lines = new List<string>();

                foreach (Employee employee in employees)
                {
                    lines.Add($"{employee.Name};{employee.Password};{employee.AccessLevel}");
                }
                File.WriteAllLines(userDatabasePath, lines);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error! User could not be saved: {ex.Message}");
            }
        }

        public void LoadUsersFromFile()
        {
            try
            {
                this.employees.Clear();
                string[] lines = File.ReadAllLines(userDatabasePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(';');

                    //create Request object
                    string username = parts[0];
                    string password = parts[1];
                    int accessLevel;

                    if (!int.TryParse(parts[2], out accessLevel))
                    {
                        Console.WriteLine($"Error! Invalid format in\n{userDatabasePath}\nFor user: {username}\nSetting access level to default: 1");
                        accessLevel = 1;
                    }

                    Employee employee = new Employee(username, password, accessLevel);
                    this.employees.Add(employee);

                }
                //Check if admin user already exist
                bool adminExists = false;
                foreach (Employee employee in this.employees)
                {
                    if (employee.Name == "admin" && employee.AccessLevel == 2)
                    {
                        adminExists = true;
                        break;
                    }
                }
                //Add admin if doesnt exist
                if (!adminExists)
                {
                    this.employees.Add(new Employee("admin", "admin", 2));
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Error! User database file not found");
            }
        }

    }
}



