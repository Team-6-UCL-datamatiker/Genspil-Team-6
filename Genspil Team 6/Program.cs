using Genspil_Team_6;
using System;
using System.Runtime.CompilerServices;

namespace Genspil_Team_6
{
    internal class Program
    {
        private static UserManager userManager;

        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();
            userManager = new UserManager();

            //Load data
            inventory.LoadInventoryFromFile();
            inventory.LoadRequestsFromFile();
            userManager.LoadUsersFromFile();

            //Handle Login
            Employee currentUser = userManager.Login();

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
                    DisplayMainMenu(currentUser);
                }
                string choice = Console.ReadLine();

                //Handle choice
                switch (choice)
                {
                    case "0":
                        if (currentUser.AccessLevel == 2)
                        {
                            DisplayUserHandlingMenu();
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
                        inventory.AddGame();
                        break;
                    case "4":
                        inventory.RemoveGame();
                        break;
                    case "5":
                        inventory.EditGame();
                        break;
                    case "6":
                        inventory.DisplayRequests();
                        Console.ReadLine();
                        break;
                    case "7":
                        RequestSearchMenu(inventory);
                        break;
                    case "8":
                        inventory.AddRequest();
                        break;
                    case "9":
                        inventory.RemoveRequest();
                        break;
                    case "10":
                        inventory.EditRequest();
                        break;
                    case "c":
                        inventory.RequestToGame();
                        break;
                    case "l":
                        currentUser = userManager.Logout(currentUser);
                        break;
                    case "q":
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
                        filteredInventory = filteredInventory.InventorySearch();
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
        static void RequestSearchMenu(Inventory inventory)
        {
            Console.Clear();

            bool continueFiltering = true;
            Inventory filteredInventory = inventory;

            while (continueFiltering)
            {
                // Display inventory
                filteredInventory.DisplayRequests();
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
                        filteredInventory.DisplayRequests();
                        filteredInventory = filteredInventory.RequestSearch();
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
        static void DisplayMainMenu(Employee currentUser)
        {
            Console.WriteLine($"Welcome {currentUser.Name}! To the Genspil Database System!\n");
            Console.WriteLine("-----------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("1. Display Inventory");
            Console.WriteLine("2. Search Games");
            Console.WriteLine("3. Add Game");
            Console.WriteLine("4. Remove Game");
            Console.WriteLine("5. Edit Game");
            Console.ResetColor();
            Console.WriteLine("-----------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("6. Display Requests");
            Console.WriteLine("7. Search Requests");
            Console.WriteLine("8. Add Request");
            Console.WriteLine("9. Remove Request");
            Console.WriteLine("10. Edit Request");
            Console.ResetColor();
            Console.WriteLine("-----------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("[c] Change Request into Game");
            Console.ResetColor();
            Console.WriteLine("-----------------------------------------------------");     
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[l] Logout");
            Console.WriteLine("[q] Exit");
            Console.ResetColor();
            Console.WriteLine("-----------------------------------------------------");
            Console.Write("Enter your choice: ");
        }
        static void DisplayAdminMenu()
        {
            Console.WriteLine("Welcome Admin! To the Genspil Database System!\n");
            Console.WriteLine("-----------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("0. Add/Remove User");
            Console.ResetColor();

            Console.WriteLine("-----------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("1. Display Inventory");
            Console.WriteLine("2. Search Games");
            Console.WriteLine("3. Add Game");
            Console.WriteLine("4. Remove Game");
            Console.WriteLine("5. Edit Game");
            Console.ResetColor();
            Console.WriteLine("-----------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("6. Display Requests");
            Console.WriteLine("7. Search Requests");
            Console.WriteLine("8. Add Request");
            Console.WriteLine("9. Remove Request");
            Console.WriteLine("10. Edit Request");
            Console.ResetColor();
            Console.WriteLine("-----------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("[c] Change Request into Game");
            Console.ResetColor();
            Console.WriteLine("-----------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[l] Logout");
            Console.WriteLine("[q] Exit");
            Console.ResetColor();
            Console.WriteLine("-----------------------------------------------------");
            Console.Write("Enter your choice: ");
        }
        static void DisplayUserHandlingMenu() //Call it somehting else? (not only displaying)
        {
            Console.Clear();
            DisplayLogo();
            Console.WriteLine("Choose an option!\n");
            Console.WriteLine("-----------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("1. Add User");
            Console.WriteLine("2. Remove User");
            Console.WriteLine("3. Back to Main Menu");

            Console.ResetColor();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
            string input = Console.ReadLine();

            switch (input)
            {

                case "1":
                    userManager.AddUser();
                    break;
                case "2":
                    userManager.RemoveUser();
                    break;
                case "3":
                    return;

            }
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


