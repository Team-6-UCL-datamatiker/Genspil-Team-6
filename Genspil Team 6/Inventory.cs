using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil_Team_6
{
    internal class Inventory
    {
        //public static void SaveDatabase(Game[] games)
        //{
        //    try
        //    {
        //        using StreamWriter sw = new("Inventory.txt");
        //        for (int i = 0; i < games.Length; i++)
        //        {
        //            sw.WriteLine(games[i].CreateInventoryElement());
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("Exception: " + e.Message);
        //    }
        //}

        //public static void LoadDatabase()
        //{

        //}

        public static string AddGameStringTest(string identifier)
        {
            string input;
            while (string.IsNullOrEmpty(input = Console.ReadLine()))
            {
                Console.Clear();
                Console.Write($"{identifier} skal bestå af mindst ét tegn: ");
            }
            Console.Clear();
            return input;
        }
        public static int AddGameIntTest(string identifier)
        {
            int input;
            while (int.TryParse(Console.ReadLine(), out input) == false)
            {
                Console.Clear();
                Console.WriteLine($"{identifier} skal være et tal: ");
            }
            Console.Clear();
            return input;
        }
        public static void AddGame()
        {
            Console.Write("Navn: ");
            string name = AddGameStringTest("Navnet");

            Console.Write("Genre: ");
            string genre = AddGameStringTest("Genren");

            Console.Write("Tilstand: ");
            string condition = AddGameStringTest("Tilstanden");

            Console.Write("Spil ID: ");
            int gameID = AddGameIntTest("ID'et");

            Console.Write("Min antal spillere: ");
            int minNoOfPlayers = AddGameIntTest("Min antal spillere");

            Console.Write("Max antal spillere: ");
            int maxNoOfPlayers = AddGameIntTest("Max antal spillere");

            Console.Write("Pris: ");
            double dInput;
            while (double.TryParse(Console.ReadLine(), out dInput) == false)
            {
                Console.Clear();
                Console.WriteLine("Prisen skal være et tal.");
            }
            Console.Clear();
            double price = dInput;

            Console.Write("Er det tilgængeligt?: ");
            string sInput = Console.ReadLine();
            while (string.IsNullOrEmpty(sInput) || !(sInput.ToLower() == "ja" || sInput.ToLower() == "nej"))
            {
                Console.Clear();
                Console.WriteLine("Tilgængelighed beskrives som ja/nej.");
                sInput = Console.ReadLine();
            }
            Console.Clear();
            bool available = false;
            if (sInput == "ja") { available = true; }

            Game game = new(name, genre, condition, gameID, minNoOfPlayers, maxNoOfPlayers, price, available);

            try
            {
                using StreamWriter sw = new("Inventory.txt", true);
                sw.WriteLine(game.CreateInventoryItem());
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        public static void EditGame(Game game)
        {

        }

        public static void DisplayInventory()
        {
            try
            {
                using StreamReader sr = new("Inventory.txt");
                string[] lines = sr.ReadToEnd().Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                for (int i = 0; i < lines.Length - 1; i++)
                {
                    string[] gameAttributes = lines[i].Split(';');
                    foreach (string gameAttribute in gameAttributes)
                    {
                        Console.Write(gameAttribute + " ");
                    }
                    Console.Write("\n");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            Console.WriteLine("\nTryk på en vilkårlig knap, for at vende tilbage til menuen");
            Console.ReadLine();
        }
    }
}
