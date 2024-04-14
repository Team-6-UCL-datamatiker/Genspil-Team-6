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
            Menu menu = new Menu();
            while (true)
            {
                Console.Clear();
                //Logo
                menu.DisplayLogo();

                //Main Menu
                if (currentUser.AccessLevel == 2)
                {
                    menu.DisplayAdminMenu();
                }
                else
                {
                    menu.DisplayMainMenu(currentUser);
                }
                string choice = Console.ReadLine();

                //Handle choice
                switch (choice)
                {
                    case "0":
                        if (currentUser.AccessLevel == 2)
                        {
                            menu.DisplayUserHandlingMenu();
                        }
                        break;
                    case "1":
                        inventory.DisplayInventory();
                        Console.ReadLine();
                        break;
                    case "2":
                        menu.InventorySearchMenu(inventory);
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
                        menu.RequestSearchMenu(inventory);
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


    }
}


