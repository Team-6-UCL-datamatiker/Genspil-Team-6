using Genspil_Team_6;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Genspil_Team_6
{
    public class Inventory
    {
        private List<BoardGame> games = new List<BoardGame>();
        private List<Request> requests = new List<Request>();

        private string gameDatabasePath = @"C:\Users\Jeppe Lynge\Documents\Datamatiker\Projekt 3 - Genspil\Genspil-Team-6\Genspil Team 6\GameDatabase.txt";
        private string requestDatabasePath = @"C:\Users\Jeppe Lynge\Documents\Datamatiker\Projekt 3 - Genspil\Genspil-Team-6\Genspil Team 6\RequestDatabase.txt";

        //Helper methods for filtering
        public Inventory FilterByName(Inventory inventory)
        {
            Console.Write("Type Name: ");
            string searchWord = Console.ReadLine().ToLower();
            foreach (BoardGame game in this.games)
            {
                if (game.GameName.ToLower().Contains(searchWord))
                {
                    inventory.games.Add(game);
                }
            }
            return inventory;
        }
        public Inventory FilterByGenre(Inventory inventory)
        {
            Console.Write("Type Genre: ");
            string searchWord = Console.ReadLine().ToLower();
            foreach (BoardGame game in this.games)
            {
                if (game.Genre.ToLower().Contains(searchWord))
                {
                    inventory.games.Add(game);
                }
            }
            return inventory;
        }
        public Inventory FilterByPlayers(Inventory inventory)
        {
            int searchWord;
            //Handling wrong inputs
            while (true)
            {
                Console.Write("Type amount of players: ");
                if (!int.TryParse(Console.ReadLine(), out searchWord))
                {
                    Console.WriteLine("Invalid input! Must be a number");
                }
                else
                {
                    break;
                }
            }
            //Filter
            foreach (BoardGame game in this.games)
            {
                if (game.NoOfPlayers == searchWord)
                {
                    inventory.games.Add(game);
                }
            }
            return inventory;
        }
        public Inventory FilterByAvailability(Inventory inventory)
        {
            Console.Write("Availablility [y/n]: ");
            string searchWord = Console.ReadLine().ToLower();

            foreach (BoardGame game in this.games)
            {
                if ((searchWord == "y" && game.Available) || (searchWord == "n" && !game.Available))
                {
                    inventory.games.Add(game);
                }
            }
            return inventory;
        }
        public Inventory FilterByGameID(Inventory inventory)
        {
            int searchWord;
            //Handling wrong inputs
            while (true)
            {
                Console.Write("Type game ID: ");
                if (!int.TryParse(Console.ReadLine(), out searchWord))
                {
                    Console.WriteLine("Invalid input! Must be a number");
                }
                else
                {
                    break;
                }
            }
            //Filter
            foreach (BoardGame game in this.games)
            {
                if (game.GameID == searchWord)
                {
                    inventory.games.Add(game);
                }
            }
            return inventory;
        }
        public Inventory FilterByPrice(Inventory inventory)
        {
            double searchWord;
            //Handling wrong inputs
            while (true)
            {
                Console.Write("Type maximum price: ");
                if (!double.TryParse(Console.ReadLine(), out searchWord))
                {
                    Console.WriteLine("Invalid input! Must be a number");
                }
                else
                {
                    break;
                }
            }
            //Filter
            foreach (BoardGame game in this.games)
            {
                if (game.Price <= searchWord)
                {
                    inventory.games.Add(game);
                }
            }
            return inventory;
        }
        public Inventory FilterByCondition(Inventory inventory)
        {
            Console.Write("Type Condition: ");
            string searchWord = Console.ReadLine().ToLower();
            foreach (BoardGame game in this.games)
            {
                if (game.Condition.ToLower().Contains(searchWord))
                {
                    inventory.games.Add(game);
                }
            }
            return inventory;
        }
    }
}

