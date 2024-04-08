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
        private string userDatabasePath = @"C:\Users\Jeppe Lynge\Documents\Datamatiker\Projekt 3 - Genspil\Genspil-Team-6\Genspil Team 6\UserDatabase.txt";

        public UserManager()
        {
            this.employees.Add(new Employee("admin", "1", 2));
        }

        public Employee Login()
        {
            while (true)
            {
                Console.Write("Username: ");
                string username = Console.ReadLine();

                foreach (Employee employee in employees)
                {
                    if (employee.Name == username)
                    {
                        return employee;
                    }
                }
                Console.WriteLine("Invalid username. Please try again");
                Console.ReadLine();
                Console.Clear();
            }
        }

        public void AddUser()
        {
            Console.Clear();

            Console.Write("Enter Username: ");
            string username = Console.ReadLine();

            employees.Add(new Employee(username, "1", 1));
            SaveUsersToFile();
            Console.WriteLine($"{username} added to the system!");
            Console.ReadLine();
        }

        public void SaveUsersToFile()
        {
            List<string> lines = new List<string>();

           foreach(Employee employee in employees)
            {
                lines.Add(employee.Name);
            }
            File.WriteAllLines(userDatabasePath, lines);
        }

        //public void LoadUsersToFile()
        //{
        //    this.employees.Clear();

        //}
    }


}
