using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil_Team_6
{
    internal class Menu
    {
        public static void DisplayMenu()
        {
            string s = "";
            while (s != "q")
            {
                Console.Clear();
                Console.WriteLine("Veeeeeeelkommen til fars fede lagersystem!\n");
                Console.WriteLine("1: Spil");
                Console.WriteLine("2: Anmodninger");
                Console.WriteLine("q: Afslut");
                s = TakeMenuInput();
            }
        }
        public static string TakeMenuInput()
        {
            string s = "";
            switch (Console.ReadLine())
            {
                case "1":
                    Inventory.DisplayGameInventory(Inventory.LoadInventoryFile("Inventory.txt"));
                    Console.WriteLine("\n1    : Tilføj spil");
                    Console.WriteLine("2    : Søg (og rediger)");
                    Console.WriteLine("Enter: Hovedmenu");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            Console.Clear();
                            Console.Write("Navn: ");
                            Inventory.AddGame(Tester.StringTest("Navnet"));
                            break;
                        case "2":
                            s = Inventory.InitiateGameSearch(Inventory.LoadInventoryFile("Inventory.txt"));
                            break;
                        default:
                            break;
                    }
                    break;
                case "2":
                    Inventory.DisplayRequestInventory(Inventory.LoadInventoryFile("Requests.txt"));
                    Console.WriteLine("\n1    : Tilføj anmodning");
                    Console.WriteLine("2    : Søg (og rediger)");
                    Console.WriteLine("Enter: Hovedmenu");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            Console.Clear();
                            Inventory.AddRequest();
                            break;
                        case "2":
                            s = Inventory.InitiateRequestSearch(Inventory.LoadInventoryFile("Requests.txt"));
                            break;
                        default:
                            break;
                    }
                    break;
                case "q":
                    s = "q";
                    break;
                default:
                    break;
            }
            return s;
        }
    }
}
