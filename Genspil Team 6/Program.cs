using System.Security.Cryptography;
using System.Text;

namespace Genspil_Team_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            if (!File.Exists("Users.txt") || Inventory.LoadInventoryFile("Users.txt").Length == 1)
            {
                Console.WriteLine("Tryk Enter for at oprette administrator.");
                Console.ReadLine();
                Inventory.AddUser(1);
                Console.WriteLine("Administrator oprettet. Tryk Enter for at fortsætte.");
                Console.ReadLine();
            }
            string input = "";
            while (input != "q")
            {
                string[] inventory = Inventory.LoadInventoryFile("Users.txt");
                Console.Clear();
                Console.WriteLine("LOGIN\n");
                Console.Write("Indtast brugernavn: ");
                input = Tester.StringTest("Brugernavnet").ToLower();
                for (int i = 0; i < inventory.Length - 1; i++)
                {
                    string[] userAttributes = inventory[i].Split(';');
                    if (userAttributes[1].ToLower() == input)
                    {
                        Console.WriteLine("LOGIN\n");
                        Console.Write("Indtast password: ");
                        if (userAttributes[2].ToLower() == Tester.StringTest("Password").ToLower())
                        {
                            Menu.DisplayMenu(int.Parse(userAttributes[3]), userAttributes[0]);
                            Environment.Exit(0);
                        }
                    }
                }
                Console.WriteLine("LOGIN\n");
                Console.WriteLine("Fejl ved login. Tast q for at afslutte eller enter for at prøve igen.");
                input = Console.ReadLine();
            }
        }
    }
}
