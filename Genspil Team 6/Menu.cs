using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil_Team_6
{
    public class Menu
    {

        private UserManager userManager = new UserManager();


        public void InventorySearchMenu(Inventory inventory)
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
        public void RequestSearchMenu(Inventory inventory)
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
        public void DisplayMainMenu(Employee currentUser)
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
        public void DisplayAdminMenu()
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
        public void DisplayUserHandlingMenu()
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
        public void DisplaySearchMenu()
        {
            Console.WriteLine("Filter Options:\n");
            Console.WriteLine("1. Add Filter");
            Console.WriteLine("2. Clear Filters");
            Console.WriteLine("3. Return to Main Menu");
            Console.Write("Enter your choice: ");
        }
        public void DisplayLogo()
        {
            // Logo
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("  ________                                 .__ .__   \r\n /  _____/   ____    ____    ____________  |__||  |  \r\n/   \\  ___ _/ __ \\  /    \\  /  ___/\\____ \\ |  ||  |  \r\n\\    \\_\\  \\\\  ___/ |   |  \\ \\___ \\ |  |_> >|  ||  |__\r\n \\______  / \\___  >|___|  //____  >|   __/ |__||____/\r\n        \\/      \\/      \\/      \\/ |__|              \n");
            Console.ResetColor();
        }
    }
}
