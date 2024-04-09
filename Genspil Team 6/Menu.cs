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
                Console.WriteLine("S: Spil");
                Console.WriteLine("A: Anmodninger");
                if (accessLevel < 2)
                {
                    Console.WriteLine("B: Brugere");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("B: Brugere");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                Console.WriteLine("\nq: Afslut\n");
                s = TakeMenuInput(accessLevel, userID);
            }
        }
        public static string TakeMenuInput(int accessLevel, string userID)
        {
            string s = "";
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            switch (keyInfo.Key)
            {
                case ConsoleKey.S:
                    Inventory.DisplayGameInventory(Inventory.LoadInventoryFile("Inventory.txt"));
                    Console.WriteLine("\nT    : Tilføj spil");
                    Console.WriteLine("S    : Søg (og rediger)");
                    Console.WriteLine("\nEnter: Hovedmenu\n");
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.T:
                            Console.Clear();
                            Console.Write("Navn: ");
                            Inventory.AddGame(Tester.StringTest("Navnet"));
                            break;
                        case ConsoleKey.S:
                            s = Inventory.InitiateGameSearch(Inventory.LoadInventoryFile("Inventory.txt"));
                            break;
                        default:
                            break;
                    }
                    break;
                case ConsoleKey.A:
                    Inventory.DisplayRequestInventory(Inventory.LoadInventoryFile("Requests.txt"));
                    Console.WriteLine("\nT    : Tilføj anmodning");
                    Console.WriteLine("S    : Søg (og rediger)");
                    Console.WriteLine("\nEnter: Hovedmenu\n");
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.T:
                            Console.Clear();
                            Inventory.AddRequest(userID);
                            break;
                        case ConsoleKey.S:
                            s = Inventory.InitiateRequestSearch(Inventory.LoadInventoryFile("Requests.txt"));
                            break;
                        default:
                            break;
                    }
                    break;
                case ConsoleKey.B:
                    if (accessLevel < 2)
                    {
                        Console.Clear();
                        Console.WriteLine("V    : Vis brugere");
                        Console.WriteLine("T    : Tilføj bruger");
                        Console.WriteLine("S    : Slet bruger");
                        Console.WriteLine("\nEnter: Hovedmenu\n");
                        switch (keyInfo.Key)
                        {
                            case ConsoleKey.V:
                                Inventory.DisplayUserInventory(Inventory.LoadInventoryFile("Users.txt"));
                                Console.ReadLine();
                                break;
                            case ConsoleKey.T:
                                Inventory.AddUser(2);
                                break;
                            case ConsoleKey.S:
                                Console.WriteLine("Indtast bruger ID'et på den bruger, du vil slette.");
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
                case ConsoleKey.Q:
                    s = "q";
                    break;
                default:
                    break;
            }
            return s;
        }
    }
}
