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

        //Add methods
        public void AddGameFromUserInput()
        {
            Console.Write("Name of the game: ");
            string name = Console.ReadLine();
            Console.Write("What is the genre: ");
            string genre = Console.ReadLine();
            int amountOfPlayers;
            do
            {
                Console.Write("Amount of players: ");
            } while (!int.TryParse(Console.ReadLine(), out amountOfPlayers));

            Console.Write("Condition: ");
            string condition = Console.ReadLine().ToUpper();
            double price;
            do
            {
                Console.Write("Price: ");
            } while (!double.TryParse(Console.ReadLine(), out price));
            Console.Write("In stock? (y/n)");
            bool available = Console.ReadLine().ToLower() == "y";
            int gameID = -1;

            BoardGame game = new BoardGame(name, genre, condition, -1, amountOfPlayers, price, available); // Check gameID

            Console.Clear();
            Console.WriteLine($"You are adding this Game\nID: #{game.GameID}\nGame: {game.GameName}\nPrice: {game.Price}\nGenre: {game.Genre}\nNumber of Players: {game.NoOfPlayers}\nCondition: {game.Condition}\nAvailable: {(game.Available ? "Yes" : "No")}");
            Console.ReadLine();

            //Add game
            this.games.Add(game);
            //Save to database
            SaveInventoryToFile();
        }
        public void AddRequestFromUserInput()
        {
            Console.Write("Name of the customer: ");
            string customerName = Console.ReadLine();
            Console.Write("Name of the game: ");
            string gameName = Console.ReadLine();
            Console.Write("Number of the customer: ");
            string customerNumber = Console.ReadLine();
            int requestID = -1;

            Request request = new Request(gameName, requestID, customerName, customerNumber); // Check gameID
            Console.Clear();
            Console.WriteLine($"You are adding this Request\nID: #{request.RequestID}\nGame: {request.GameName}\nCustomer Name: {request.CustomerName}\nPhone Number: {request.CustomerPhone}\n");
            Console.ReadLine();
            //Add request
            this.requests.Add(request);
            //Save to database
            SaveRequestsToFile();
        }


        //Remove methods
        public void RemoveGame()
        {
            Console.Write("Enter ID of Game to remove: ");
            int ID;

            //Handle wrong inputs
            if (!int.TryParse(Console.ReadLine(), out ID))
            {
                Console.WriteLine("Invalid input. Must be an integer!");
                Console.ReadLine();
                return;
            }

            BoardGame gameToRemove = null;

            foreach (BoardGame game in this.games)
            {
                if (game.GameID == ID)
                {
                    gameToRemove = game;
                    break;
                }
            }

            if (gameToRemove != null)
            {
                this.games.Remove(gameToRemove);
                SaveInventoryToFile();
                Console.WriteLine("Game was successfully removed!");
            }
            else
            {
                Console.WriteLine("Game not found!");
            }
            Console.ReadLine();
        }
        public void RemoveRequest()
        {
            Console.Write("Enter ID of Request to remove: ");
            int ID;

            //Handle wrong inputs
            if (!int.TryParse(Console.ReadLine(), out ID))
            {
                Console.WriteLine("Invalid input. Must be an integer!");
                Console.ReadLine();
                return;
            }

            Request requestToRemove = null;

            foreach (Request request in this.requests)
            {
                if (request.RequestID == ID)
                {
                    requestToRemove = request;
                    break;
                }
            }

            if (requestToRemove != null)
            {
                this.requests.Remove(requestToRemove);
                SaveRequestsToFile();
                Console.WriteLine("Request was successfully removed!");
            }
            else
            {
                Console.WriteLine("Request not found!");
            }
            Console.ReadLine();
        }

        //Search
        public Inventory Search()
        {
            Inventory filteredInventory = new Inventory();

            Console.WriteLine("What do you want to filter by?\n");

            Console.WriteLine("Press \"1\" to filter by name");
            Console.WriteLine("Press \"2\" to filter by genre");
            Console.WriteLine("Press \"3\" to filter by number of players");
            Console.WriteLine("Press \"4\" to filter by availability");
            Console.WriteLine("Press \"5\" to filter by game ID");
            Console.WriteLine("Press \"6\" to filter by price");
            Console.WriteLine("Press \"7\" to filter by condition");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    FilterByName(filteredInventory);
                    break;
                case "2":
                    FilterByGenre(filteredInventory);
                    break;
                case "3":
                    FilterByPlayers(filteredInventory);
                    break;
                case "4":
                    FilterByAvailability(filteredInventory);
                    break;
                case "5":
                    FilterByGameID(filteredInventory);
                    break;
                case "6":
                    FilterByPrice(filteredInventory);
                    break;
                case "7":
                    FilterByCondition(filteredInventory);
                    break;
                default:
                    Console.WriteLine("Invalid input. Please try again");
                    Console.ReadLine();
                    break;

            }
            return filteredInventory;
        }

        //Display inventories
        public void DisplayInventory()
        {
            Console.Clear();

            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("{0,-10}{1,-15}{2,-20}{3,-18}{4,-18}{5,-15}{6,-15}",
                              "ID", "Name", "Genre", "Price", "Condition", "Players", "Available");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");

            foreach (BoardGame game in games)
            {
                Console.WriteLine("{0,-10}{1,-15}{2,-20}{3,-20}{4,-19}{5,-15}{6,-15}",
                                              "#" + game.GameID, game.GameName, game.Genre, game.Price.ToString("C"),
                                              game.Condition, game.NoOfPlayers, game.Available ? "Yes" : "No");
            }

            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
        }
        public void DisplayRequests()
        {
            Console.Clear();

            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("{0,-25}{1,-25}{2,-25}{3,-25}",
                              "ID", "Game", "Customer Name", "Phone Number");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");

            foreach (Request request in this.requests)
            {
                Console.WriteLine("{0,-25}{1,-25}{2,-25}{3,-25}",
                                              "#" + request.RequestID, request.GameName, request.CustomerName, request.CustomerPhone);
            }

            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.ReadLine();
        }

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

