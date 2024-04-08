using Genspil_Team_6;
using System;
using System.Runtime.CompilerServices;

namespace Genspil_Team_6
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();
            UserManager userManager = new UserManager();
            Employee currentUser = userManager.Login();

            //Load data
            inventory.LoadInventoryFromFile();
            inventory.LoadRequestsFromFile();

            //Start UI
            StartUI(inventory, userManager, currentUser);
        }

        static void StartUI(Inventory inventory, UserManager userManager, Employee currentUser)
        {
            while (true)
            {
                Console.Clear();
                //Logo
                DisplayLogo();
                //Main Menu
                if (currentUser.AccessLevel == 2)
                {
                    DisplayAdminMenu();
                }
                else
                {
                    DisplayMainMenu();
                }
                string choice = Console.ReadLine();

                //Handle choice
                switch (choice)
                {
                    case "0":
                        if (currentUser.AccessLevel == 2)
                        {
                            userManager.AddUser();
                        }
                        break;
                    case "1":
                        inventory.DisplayInventory();
                        Console.ReadLine();
                        break;
                    case "2":
                        InventorySearchMenu(inventory);
                        break;
                    case "3":
                        inventory.AddGameFromUserInput();
                        break;
                    case "4":
                        inventory.RemoveGame();
                        break;
                    case "5":
                        inventory.DisplayRequests();
                        break;
                    case "6":
                        inventory.AddRequestFromUserInput();
                        break;
                    case "7":
                        inventory.RemoveRequest();
                        break;
                    case "8":
                        return; //Exit
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void InventorySearchMenu(Inventory inventory)
        {
            Console.Clear();

            bool continueFiltering = true;
            Inventory filteredInventory = inventory;

            while (continueFiltering)
            {
                // Display inventory
                filteredInventory.DisplayInventory();
                Console.WriteLine();

                // Search menu
                DisplaySearchMenu();
                string choice = Console.ReadLine();

                // Handle choice
                switch (choice)
                {
                    //Add filter
                    case "1":
                        Console.Clear();
                        filteredInventory.DisplayInventory();
                        filteredInventory = filteredInventory.Search();
                        break;
                    //Clear filters
                    case "2":
                        filteredInventory = inventory;
                        break;
                    //Return to main menu
                    case "3":
                        continueFiltering = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        //Display methods
        static void DisplayMainMenu()
        {
            Console.WriteLine("Welcome to the Genspil Database System!\n");
            Console.WriteLine("-----------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("1. Display Inventory");
            Console.WriteLine("2. Search Games");
            Console.WriteLine("3. Add Game");
            Console.WriteLine("4. Remove Game");
            Console.ResetColor();
            Console.WriteLine("-----------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("5. Display Requests");
            Console.WriteLine("6. Add Request");
            Console.WriteLine("7. Remove Request");
            Console.ResetColor();
            Console.WriteLine("-----------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("8. Exit");
            Console.ResetColor();
            Console.WriteLine("-----------------------------------------------------");
            Console.Write("Enter your choice: ");
        }

        static void DisplayAdminMenu()
        {
            Console.WriteLine("Welcome to the Genspil Database System!\n");
            Console.WriteLine("-----------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("0. Add User");
            Console.ResetColor();

            Console.WriteLine("-----------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("1. Display Inventory");
            Console.WriteLine("2. Search Games");
            Console.WriteLine("3. Add Game");
            Console.WriteLine("4. Remove Game");
            Console.ResetColor();
            Console.WriteLine("-----------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("5. Display Requests");
            Console.WriteLine("6. Add Request");
            Console.WriteLine("7. Remove Request");
            Console.ResetColor();
            Console.WriteLine("-----------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("8. Exit");
            Console.ResetColor();
            Console.WriteLine("-----------------------------------------------------");
            Console.Write("Enter your choice: ");
        }
        static void DisplaySearchMenu()
        {
            Console.WriteLine("Filter Options:\n");
            Console.WriteLine("1. Add Filter");
            Console.WriteLine("2. Clear Filters");
            Console.WriteLine("3. Return to Main Menu");
            Console.Write("Enter your choice: ");
        }

        static void DisplayLogo()
        {
            // Logo
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("  ________                                 .__ .__   \r\n /  _____/   ____    ____    ____________  |__||  |  \r\n/   \\  ___ _/ __ \\  /    \\  /  ___/\\____ \\ |  ||  |  \r\n\\    \\_\\  \\\\  ___/ |   |  \\ \\___ \\ |  |_> >|  ||  |__\r\n \\______  / \\___  >|___|  //____  >|   __/ |__||____/\r\n        \\/      \\/      \\/      \\/ |__|              \n");
            Console.ResetColor();
        }


    }
}
