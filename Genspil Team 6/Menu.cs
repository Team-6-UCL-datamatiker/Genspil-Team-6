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
                Console.WriteLine("1: Vis lagerbeholdning");
                Console.WriteLine("2: Søg");
                Console.WriteLine("3: Tilføj spil");
                Console.WriteLine("4: Vis anmodninger");
                Console.WriteLine("5: Søg anmodninger");
                Console.WriteLine("6: Tilføj anmodning");
                Console.WriteLine("q: Afslut\n");
                s = TakeMenuInput();
            }
        }
        public static string TakeMenuInput()
        {
            string s = "";
            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    Inventory.DisplayGameInventory(Inventory.LoadInventoryFile("Inventory.txt"));
                    Console.WriteLine("\nTryk på en vilkårlig knap, for at vende tilbage til menuen.");
                    Console.ReadLine();
                    break;

                case "2":
                    s = Inventory.InitiateSearch(Inventory.LoadInventoryFile("Inventory.txt"));
                    break;

                case "3":
                    Console.Clear();
                    Inventory.AddGame();
                    break;

                case "4":
                    Console.Clear();
                    Inventory.DisplayRequestInventory(Inventory.LoadInventoryFile("Requests.txt"));
                    Console.WriteLine("\nTryk på en vilkårlig knap, for at vende tilbage til menuen.");
                    Console.ReadLine();
                    break;

                case "5":
                    s = Inventory.InitiateRequestSearch(Inventory.LoadInventoryFile("Requests.txt"));
                    break;
                
                case "6":
                    Console.Clear();
                    Inventory.AddRequest();
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
