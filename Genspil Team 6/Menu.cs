namespace Genspil_Team_6
{
    internal class Menu
    {
        public static void DisplayMenu(int accessLevel, string userID)
        {
            string s = "";
            while (s != "q")
            {
                Console.Clear();
                Console.WriteLine("Veeeeeeelkommen til fars fede lagersystem!\n");
                Console.WriteLine("1: Spil");
                Console.WriteLine("2: Anmodninger");
                if (accessLevel < 2)
                {
                    Console.WriteLine("3: Brugere");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("3: Brugere");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                Console.WriteLine("\nq: Afslut\n");
                s = TakeMenuInput(accessLevel, userID);
            }
        }
        public static string TakeMenuInput(int accessLevel, string userID)
        {
            string s = "";
            switch (Console.ReadLine())
            {
                case "1":
                    Inventory.DisplayGameInventory(Inventory.LoadInventoryFile("Inventory.txt"));
                    Console.WriteLine("\n1    : Tilføj spil");
                    Console.WriteLine("2    : Søg (og rediger)");
                    Console.WriteLine("\nEnter: Hovedmenu\n");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            Console.Clear();
                            Console.Write("Navn: ");
                            Inventory.AddGame(Tester.StringTest("Navnet"));
                            break;
                        case "2":
                            s = Inventory.InitiateGameSearch(Inventory.LoadInventoryFile("Inventory.txt"));
                            break;
                        default:
                            break;
                    }
                    break;
                case "2":
                    Inventory.DisplayRequestInventory(Inventory.LoadInventoryFile("Requests.txt"));
                    Console.WriteLine("\n1    : Tilføj anmodning");
                    Console.WriteLine("2    : Søg (og rediger)");
                    Console.WriteLine("\nEnter: Hovedmenu\n");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            Console.Clear();
                            Inventory.AddRequest(userID);
                            break;
                        case "2":
                            s = Inventory.InitiateRequestSearch(Inventory.LoadInventoryFile("Requests.txt"));
                            break;
                        default:
                            break;
                    }
                    break;
                case "3":
                    if (accessLevel < 2)
                    {
                        Inventory.DisplayUserInventory(Inventory.LoadInventoryFile("Users.txt"));
                        Console.WriteLine("\n1    : Tilføj bruger");
                        Console.WriteLine("2    : Slet bruger");
                        Console.WriteLine("\nEnter: Hovedmenu\n");
                        switch (Console.ReadLine())
                        {
                            case "1":
                                Inventory.AddUser(2);
                                break;
                            case "2":
                                Console.Write("\nIndtast bruger ID'et på den bruger, du vil slette: ");
                                string[] inventory = Inventory.LoadInventoryFile("Users.txt");
                                for (int i = 0; i < inventory.Length - 1; i++)
                                {
                                    string[] userAttributes = inventory[i].Split(';');
                                    if (userAttributes[0].ToLower() == Tester.StringTest("ID'et").ToLower())
                                    {
                                        Console.WriteLine(userAttributes[1] + "'s bruger er blevet slettet. Tryk på enter for at returnere til hovedmenuen.");
                                        Console.ReadLine();
                                        Inventory.DeleteInventoryItem(userAttributes[0].ToLower(), inventory, "Users.txt", "UsersTemp.txt");
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Du har ikke adgang til denne menu. Tryk enter for at vende tilbage til hovedmenuen.");
                        Console.ReadLine();
                    }
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
