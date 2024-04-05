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
                Console.WriteLine("Tast 1 for se lagerbeholdningen.");
                Console.WriteLine("Tast 2 for tilføje et nyt spil.");
                Console.WriteLine("Tast 3 for fjerne et spil.");
                Console.WriteLine("Tast 4 for at søge efter et spil");
                Console.WriteLine("Tast q to exit application.\n");
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
                    Inventory.DisplayInventory();
                    break;

                case "2":
                    Console.Clear();
                    Inventory.AddGame();
                    Console.WriteLine("Spillet er tilføjet. Tryk på en vilkårlig knap for at vende retur til menuen.");
                    Console.ReadLine();
                    break;

                case "3":
                    Console.WriteLine("fedt");
                    break;

                case "4":
                    Console.WriteLine("fedt");
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
