﻿using Genspil_Team_6;
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


        //Persistence
        public void SaveInventoryToFile()
        {
            try
            {
                List<string> lines = new List<string>();

                foreach (BoardGame game in games)
                {
                    lines.Add($"{game.GameName};{game.Genre};{game.NoOfPlayers};{game.Available};{game.GameID};{game.Price};{game.Condition}");
                }

                File.WriteAllLines(gameDatabasePath, lines);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error! Inventory could not be saved: {ex.Message}");
            }
        }
        public void LoadInventoryFromFile()
        {
            try
            {
                this.games.Clear(); // Clear existing inventory before loading from file
                string[] lines = File.ReadAllLines(gameDatabasePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(';');

                    // Create BoardGame object
                    string gameName = parts[0];
                    string genre = parts[1];
                    int noOfPlayers;
                    if (!int.TryParse(parts[2], out noOfPlayers))
                    {
                        Console.WriteLine($"Invalid format in:\n{gameDatabasePath}\nNumber of players must be a number!");
                        Console.ReadLine();
                        return;
                    }
                    bool available;
                    if (!bool.TryParse(parts[3], out available))
                    {
                        Console.WriteLine($"Invalid format in:\n{gameDatabasePath}\nAvailable must be either True of False!");
                        Console.ReadLine();
                        return;
                    }
                    int gameID;
                    if (!int.TryParse(parts[4], out gameID))
                    {
                        Console.WriteLine($"Invalid format in:\n{gameDatabasePath}\nGame ID must be a number!");
                        Console.ReadLine();
                        return;
                    }
                    double price;
                    if (!double.TryParse(parts[5], out price))
                    {
                        Console.WriteLine($"Invalid format in:\n{gameDatabasePath}\nPrice must be a number!");
                        Console.ReadLine();
                        return;
                    }
                    string condition = parts[6];

                    BoardGame game = new BoardGame(gameName, genre, condition, gameID, noOfPlayers, price, available);
                    this.games.Add(game);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Error! Game datebase file not found!");
            }

        }

        public void SaveRequestsToFile()
        {
            try
            {
                List<string> lines = new List<string>();

                foreach (Request request in this.requests)
                {
                    lines.Add($"{request.GameName};{request.RequestID};{request.CustomerName};{request.CustomerPhone}");
                }

                File.WriteAllLines(requestDatabasePath, lines);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error! Requests could not be saved: {ex.Message}");
            }
        }
        public void LoadRequestsFromFile()
        {
            try
            {
                this.requests.Clear(); // Clear existing inventory before loading from file
                string[] lines = File.ReadAllLines(requestDatabasePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(';');

                    //create Request object
                    string gameName = parts[0];
                    int requestID;
                    if (!int.TryParse(parts[1], out requestID))
                    {
                        Console.WriteLine($"Invalid format in:\n{requestDatabasePath}\nPrice must be a number!");
                        Console.ReadLine();
                        //Environment.Exit(1); Should program shutdown here?
                        return;
                    }
                    string customerName = parts[2];
                    string customerPhone = parts[3];

                    Request request = new Request(gameName, requestID, customerName, customerPhone);
                    this.requests.Add(request);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Error! Request datebase file not found!");
            }
        }



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

