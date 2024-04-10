namespace Genspil_Team_6
{
    internal class Inventory
    {
        public static string[] LoadInventoryFile(string fileName)
        {
            Tester.FileTest(fileName);
            using StreamReader sr = new(fileName);
            string[] lines = sr.ReadToEnd().Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            for (int i = 0; i < lines.Length - 1; i++)
            {
                string[] gameAttributes = lines[i].Split(';');
                if (fileName == "Inventory.txt")
                {
                    gameAttributes[^2] = gameAttributes[^2] == "True" ? "Ja" : "Nej";
                }
                lines[i] = string.Join(";", gameAttributes);
            }
            return lines;
        }
        public static void DisplayGameInventory(string[] inventory)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("{0,-40}{1,-48}", "", "SPIL");
            Console.WriteLine("{0,-88}", "");
            Console.WriteLine("{0,-5}{1,-20}{2,-20}{3,-12}{4,-12}{5,-9}{6,-10}",
                  "ID", "Navn", "Genre", "Tilstand", "Spillere", "Stock", "Pris");
            Console.BackgroundColor = ConsoleColor.Black;
            try
            {
                for (int i = 0; i < inventory.Length - 1; i++)
                {
                    string[] gameAttributes = inventory[i].Split(';');
                    Console.BackgroundColor = i % 2 == 0 ? ConsoleColor.Blue : ConsoleColor.DarkBlue;
                    Console.WriteLine("{0,-5}{1,-20}{2,-20}{3,-12}{4,-12}{5,-9}{6,10}", gameAttributes[0], gameAttributes[1], gameAttributes[2], gameAttributes[3], gameAttributes[4] + "-" + gameAttributes[5], gameAttributes[6], double.Parse(gameAttributes[7]).ToString("C"));
                    Console.BackgroundColor = ConsoleColor.Black;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public static void DisplayRequestInventory(string[] inventory)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("{0,-30}{1,-40}", "", "ANMODNINGER");
            Console.WriteLine("{0,-70}", "");
            Console.WriteLine("{0,-5}{1,-20}{2,-20}{3,-15}{4,-10}",
                  "ID", "Spil", "Kunde", "Tlf.", "Medarb. ID");
            Console.BackgroundColor = ConsoleColor.Black;
            try
            {
                for (int i = 0; i < inventory.Length - 1; i++)
                {
                    string[] requestAttributes = inventory[i].Split(';');
                    Console.BackgroundColor = i % 2 == 0 ? ConsoleColor.Blue : ConsoleColor.DarkBlue;
                    Console.WriteLine("{0,-5}{1,-20}{2,-20}{3,-15}{4,-10}", requestAttributes[0], requestAttributes[1], requestAttributes[2], requestAttributes[3], requestAttributes[4]);
                    Console.BackgroundColor = ConsoleColor.Black;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public static void DisplayUserInventory(string[] inventory)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("{0,-10}{1,-16}", "", "BRUGERE");
            Console.WriteLine("{0,-26}", "");
            Console.WriteLine("{0,-5}{1,-15}{2,-6}",
                  "ID", "Navn", "Adgang");
            Console.BackgroundColor = ConsoleColor.Black;
            try
            {
                for (int i = 0; i < inventory.Length - 1; i++)
                {
                    string[] requestAttributes = inventory[i].Split(';');
                    Console.BackgroundColor = i % 2 == 0 ? ConsoleColor.Blue : ConsoleColor.DarkBlue;
                    Console.WriteLine("{0,-5}{1,-15}{2,-6}", requestAttributes[0], requestAttributes[1], requestAttributes[3]);
                    Console.BackgroundColor = ConsoleColor.Black;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public static void AddUser(int accesslevel)
        {
            Console.WriteLine();
            string userID = Tester.IDIterateTest(LoadInventoryFile("Users.txt"));
            Console.Clear();
            Console.Write("Brugernavn: ");
            string name = Tester.StringTest("Brugernavnet");
            Console.Write("Password: ");
            string password = Tester.StringTest("Password");
            Employee employee = new(userID, name, password, accesslevel);
            try
            {
                using StreamWriter sw = new("Users.txt", true);
                sw.WriteLine(employee.CreateInventoryItem());
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

        }
        public static void AddGame(string gameName)
        {
            string name = gameName;
            Tester.FileTest("Inventory.txt");
            string gameID = Tester.IDIterateTest(LoadInventoryFile("Inventory.txt"));
            Console.Write("Genre: ");
            string genre = Tester.StringTest("Genren");
            Console.Write("Tilstand: ");
            string condition = Tester.StringTest("Tilstanden");
            Console.Write("Min antal spillere: ");
            int minNoOfPlayers = Tester.IntTest("Min antal spillere");
            Console.Write("Max antal spillere: ");
            int maxNoOfPlayers = Tester.MaxIntTest("Min antal spillere", minNoOfPlayers);
            Console.Write("Pris: ");
            double dInput;
            while (double.TryParse(Console.ReadLine(), out dInput) == false)
            {
                Console.Clear();
                Console.Write("Prisen skal være et tal: ");
            }
            Console.Clear();
            double price = dInput;
            Console.Write("Er det tilgængeligt?: ");
            string sInput = Console.ReadLine();
            while (string.IsNullOrEmpty(sInput) || !(sInput.ToLower() == "ja" || sInput.ToLower() == "nej"))
            {
                Console.Clear();
                Console.Write("Tilgængelighed beskrives som ja/nej: ");
                sInput = Console.ReadLine();
            }
            Console.Clear();
            bool available = false;
            if (sInput == "ja") { available = true; }
            Game game = new(gameID, name, genre, condition, minNoOfPlayers, maxNoOfPlayers, available, price);
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
        public static void AddRequest(string userID)
        {
            Tester.FileTest("Requests.txt");
            string requestID = Tester.IDIterateTest(LoadInventoryFile("Requests.txt"));
            Console.Write("Navn på spil: ");
            string gameName = Tester.StringTest("Navnet");
            Console.Write("Kundes fulde navn: ");
            string customerName = Tester.StringTest("Kundens navn");
            Console.Write("Kundens telefonnummer: ");
            int customerPhoneNumber;
            while ((int.TryParse(Console.ReadLine(), out customerPhoneNumber) == false) || customerPhoneNumber < 10000000 || customerPhoneNumber > 99999999)
            {
                Console.Clear();
                Console.Write("Telefonnummeret skal være et 8-cifret tal: ");
            }
            Console.Clear();
            Request request = new(requestID, gameName, customerName, customerPhoneNumber, userID);
            try
            {
                using StreamWriter sw = new("Requests.txt", true);
                sw.WriteLine(request.CreateInventoryItem());
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            Console.WriteLine("Anmodningen er tilføjet. Tryk på en vilkårlig knap for at vende retur til menuen.");
            Console.ReadLine();
        }
        public static string EditGame(string id, int minSpillere)
        {
            string[] inventory = LoadInventoryFile("Inventory.txt");
            if (Tester.IDMatchTest(id, inventory) == false)
            {
                return "ID'et kan ikke genkendes. Tryk på en vilkårlig tast for at vende tilbage til menuen. ";
            }

            int attributeIdentifier;
            Console.WriteLine("\nHvad vil du redigere?\n");
            Console.WriteLine("1: Navn\n2: Genre\n3: Tilstand\n4: Min spillere\n5: Max spillere\n6: Tilgængelighed\n7: Pris\n8: Slet spillet\n");
            while (int.TryParse(Console.ReadLine(), out attributeIdentifier) == false || (attributeIdentifier < 1 || attributeIdentifier > 8))
            {
                Console.Clear();
                Console.WriteLine("Indtast venligst et tal mellem 1 og 8.\n");
                Console.WriteLine("1: Navn\n2: Genre\n3: Tilstand\n4: Min spillere\n5: Max spillere\n6: Tilgængelighed\n7: Pris\n8: Slet spillet\n");
            }

            string identifier;
            switch (attributeIdentifier)
            {
                case 1:
                    identifier = "Navnet på spillet";
                    Console.Write("\nHvad skal navnet på spillet ændres til? ");
                    return EditAttribute(id, inventory, attributeIdentifier + 1, identifier, Tester.StringTest(identifier), "Inventory.txt", "IventoryTemp.txt");
                case 2:
                    identifier = "Spillets genre";
                    Console.Write("\nHvad skal spillets genre ændres til? ");
                    return EditAttribute(id, inventory, attributeIdentifier + 1, identifier, Tester.StringTest(identifier), "Inventory.txt", "IventoryTemp.txt");
                case 3:
                    identifier = "Spillets tilstand";
                    Console.Write("\nHvad skal spillets tilstand ændres til? ");
                    return EditAttribute(id, inventory, attributeIdentifier + 1, identifier, Tester.StringTest(identifier), "Inventory.txt", "IventoryTemp.txt");
                case 4:
                    identifier = "Minimum antal spillere";
                    Console.Write("\nHvad skal minimum antal spillere ændres til? ");
                    return EditAttribute(id, inventory, attributeIdentifier + 1, identifier, Tester.IntTest(identifier).ToString(), "Inventory.txt", "IventoryTemp.txt");
                case 5:
                    identifier = "Maximum antal spillere";
                    Console.Write("\nHvad skal maximum antal spillere ændres til? ");
                    return EditAttribute(id, inventory, attributeIdentifier + 1, identifier, Tester.MaxIntTest(identifier, minSpillere).ToString(), "Inventory.txt", "IventoryTemp.txt");
                case 6:
                    identifier = "Spillets tilgængelighed";
                    Console.Write("\nHvad skal tilgængeligheden ændres til? ");
                    return EditAttribute(id, inventory, attributeIdentifier + 1, identifier, Tester.BoolTest(identifier).ToString(), "Inventory.txt", "IventoryTemp.txt");
                case 7:
                    identifier = "Spillets Pris";
                    Console.Write("\nHvad skal prisen ændres til? ");
                    return EditAttribute(id, inventory, attributeIdentifier + 1, identifier, Tester.DoubleTest(identifier).ToString(), "Inventory.txt", "IventoryTemp.txt");
                case 8:
                    DeleteInventoryItem(id, inventory, "Inventory.txt", "InventoryTemp.txt");
                    return "Spillet er blevet slettet. Tryk på en vilkårlig tast for at vende tilbage til menuen.";
                default:
                    return "n";
            }
        }
        public static string EditRequest(string id)
        {
            string[] inventory = LoadInventoryFile("Requests.txt");
            if (Tester.IDMatchTest(id, inventory) == false)
            {
                return "ID'et kan ikke genkendes. Tryk på en vilkårlig tast for at vende tilbage til menuen. ";
            }

            int attributeIdentifier;
            Console.WriteLine("\nHvad vil du redigere?\n");
            Console.WriteLine("1: Spil\n2: Kunde\n3: Telefonnummer\n4: Slet anmodningen\n5: Transformer til spil\n");
            while (int.TryParse(Console.ReadLine(), out attributeIdentifier) == false || (attributeIdentifier < 1 || attributeIdentifier > 5))
            {
                Console.Clear();
                Console.WriteLine("Indtast venligst et tal mellem 1 og 5.\n");
                Console.WriteLine("1: Spil\n2: Kunde\n3: Telefonnummer\n4: Slet anmodningen\n5: Transformer til spil\n");
            }

            string identifier;
            switch (attributeIdentifier)
            {
                case 1:
                    identifier = "Navnet på spillet";
                    Console.Write("\nHvad skal navnet på spillet ændres til? ");
                    return EditAttribute(id, inventory, attributeIdentifier + 1, identifier, Tester.StringTest(identifier), "Requests.txt", "RequestsTemp.txt");
                case 2:
                    identifier = "Kundens navn";
                    Console.Write("\nHvad skal kundens navn ændres til? ");
                    return EditAttribute(id, inventory, attributeIdentifier + 1, identifier, Tester.StringTest(identifier), "Requests.txt", "RequestsTemp.txt");
                case 3:
                    identifier = "Kundens telefonnummer";
                    Console.Write("\nHvad skal kundens telefonnummer ændres til? ");
                    int customerPhoneNumber;
                    while ((int.TryParse(Console.ReadLine(), out customerPhoneNumber) == false) || customerPhoneNumber < 10000000 || customerPhoneNumber > 99999999)
                    {
                        Console.Clear();
                        Console.Write("Telefonnummeret skal være et 8-cifret tal: ");
                    }
                    return EditAttribute(id, inventory, attributeIdentifier + 1, identifier, customerPhoneNumber.ToString(), "Requests.txt", "RequestsTemp.txt");
                case 4:
                    DeleteInventoryItem(id, inventory, "Requests.txt", "RequestsTemp.txt");
                    return "Anmodningen er blevet slettet. Tryk på en vilkårlig tast for at vende tilbage til menuen.";
                case 5:
                    Console.Clear();
                    string[] requestAttributes;
                    for (int i = 0; i < inventory.Length - 1; i++)
                    {

                        if (inventory[i].Substring(0, 3) == id)
                        {
                            requestAttributes = inventory[i].Split(';');
                            AddGame(requestAttributes[1]);
                            inventory[i] = "";
                            break;
                        }
                    }
                    StreamWriter swriter = new("RequestsTemp.txt");
                    for (int i = 0; i < inventory.Length - 1; i++)
                    {
                        if (inventory[i] != "")
                        {
                            swriter.WriteLine(inventory[i]);
                        }
                    }
                    swriter.Close();
                    File.Delete("Requests.txt");
                    File.Move("RequestsTemp.txt", "Requests.txt");
                    return "Anmodningen er blevet transformeret til et spil. Tryk på en vilkårlig tast for at vende tilbage til menuen.";
                default:
                    return "n";
            }
        }
        public static string EditAttribute(string id, string[] inventory, int attributeIdentifier, string identifier, string testMethod, string file, string tempFile)
        {
            StreamReader sr = new(file);
            StreamWriter sw = new(tempFile);
            string newValue = "";
            for (int i = 0; i < inventory.Length - 1; i++)
            {
                if (inventory[i].Substring(0, 3) == id)
                {
                    string[] attributes = inventory[i].Split(';');
                    attributes[attributeIdentifier - 1] = testMethod;
                    newValue = attributes[attributeIdentifier - 1];
                    if (newValue == "True")
                    {
                        newValue = "ja";
                    }
                    else if ( newValue == "False" )
                    {
                        newValue = "nej";
                    }
                    inventory[i] = string.Join(";", attributes);
                    break;
                }
            }
            for (int i = 0; i < inventory.Length - 1; i++)
            {
                sw.WriteLine(inventory[i]);
            }
            sr.Close();
            sw.Close();
            File.Delete(file);
            File.Move(tempFile, file);
            return $"{identifier} blev ændret til {newValue}. Tryk på en vilkårlig tast for at vende tilbage til menuen.";
        }
        public static void DeleteInventoryItem(string id, string[] inventory, string fileName, string tempFileName)
        {
            for (int i = 0; i < inventory.Length - 1; i++)
            {
                if (inventory[i].Substring(0, 3) == id)
                {
                    inventory[i] = "";
                    break;
                }
            }
            StreamWriter sw = new(tempFileName);
            for (int i = 0; i < inventory.Length - 1; i++)
            {
                if (inventory[i] != "")
                {
                    sw.WriteLine(inventory[i]);
                }
            }
            sw.Close();
            File.Delete(fileName);
            File.Move(tempFileName, fileName);
        }
        public static string InitiateGameSearch(string[] lines)
        {
            string sInput = "";
            while (sInput != "n")
            {
                int iInput;
                Console.Clear();
                Console.WriteLine("Hvad vil du sortere efter?\n");
                Console.WriteLine("1: ID\n2: Navn\n3: Genre\n4: Tilstand\n5: Min spillere\n6: Max spillere\n7: Tilgængelighed\n8: Max pris\n");
                while (int.TryParse(Console.ReadLine(), out iInput) == false || (iInput < 1 || iInput > 8))
                {
                    Console.Clear();
                    Console.WriteLine("Attributindentifikatoren skal være et tal mellem 1 og 8.\n");
                    Console.WriteLine("1: ID\n2: Navn\n3: Genre\n4: Tilstand\n5: Min spillere\n6: Max spillere\n7: Tilgængelighed\n8: Max pris\n");
                }
                Console.Clear();
                Console.Write("Hvad vil du søge efter? :");
                sInput = GameSearch(iInput, Console.ReadLine(), lines);
            }
            return "n";
        }
        public static string GameSearch(int attributeIdentifier, string search, string[] inventory)
        {
            Console.Clear();
            List<string> searchedInventory = new List<string>();
            string sInput;
            for (int i = 0; i < inventory.Length - 1; i++)
            {
                if (attributeIdentifier == 8)
                {
                    if (double.Parse(inventory[i].Split(';')[attributeIdentifier - 1]) > double.Parse(search))
                    {
                        searchedInventory.Add(inventory[i]);
                    }
                }
                else if (inventory[i].Split(';')[attributeIdentifier - 1].ToLower().Contains(search.ToLower()))
                {
                    searchedInventory.Add(inventory[i]);
                }
            }
            searchedInventory.Add("");
            if (searchedInventory.Count == 1)
            {
                Console.Write("Der blev ikke fundet noget. Vil du starte en ny søgning? (y/n): ");
                while ((sInput = Console.ReadLine().ToLower()) != "y" && sInput != "n")
                {
                    Console.Clear();
                    Console.Write("Vil du starte en ny søgning? (y/n): ");
                }
                Console.Clear();
                return sInput;
            }
            else if (searchedInventory.Count == 2)
            {
                string[] searchedInventoryArray = searchedInventory.ToArray();
                DisplayGameInventory(searchedInventoryArray);
                Console.Write("\nVil du redigere dette spil? (y/n): ");
                while ((sInput = Console.ReadLine().ToLower()) != "y" && sInput != "n")
                {
                    Console.Clear();
                    Console.Write("Vil du redigere dette spil? (y/n): ");
                }

                if (sInput == "y")
                {
                    Console.WriteLine(EditGame(searchedInventory[0].Split(';')[0], int.Parse(searchedInventory[0].Split(';')[4])));
                    Console.ReadLine();
                }
                sInput = "n"; 
                return sInput;
            }
            else
            {
                string[] searchedInventoryArray = searchedInventory.ToArray();
                DisplayGameInventory(searchedInventoryArray);
                Console.Write("\nVil du fortsætte søgningen? (y/n): ");
                while ((sInput = Console.ReadLine().ToLower()) != "y" && sInput != "n")
                {
                    Console.Clear();
                    Console.Write("Vil du fortsætte søgningen? (y/n): ");
                }
                if (sInput.ToLower() == "y")
                {
                    sInput = InitiateGameSearch(searchedInventoryArray);
                }
            }
            return sInput;
        }
        public static string InitiateRequestSearch(string[] lines)
        {
            string sInput = "";
            while (sInput != "n")
            {
                int iInput;
                Console.Clear();
                Console.WriteLine("Hvad vil du sortere efter?\n");
                Console.WriteLine("1: ID\n2: Spil\n3: Kunde\n4: Telefonnummer\n");
                while (int.TryParse(Console.ReadLine(), out iInput) == false || (iInput < 1 || iInput > 4))
                {
                    Console.Clear();
                    Console.Write("Attributindentifikatoren skal være et tal mellem 1 og 4: ");
                }
                Console.Clear();
                Console.Write("Hvad vil du søge efter? :");
                sInput = RequestSearch(iInput, Console.ReadLine(), lines);
            }
            return "n";
        }
        public static string RequestSearch(int attributeIdentifier, string search, string[] inventory)
        {
            Console.Clear();
            List<string> searchedInventory = new List<string>();
            string sInput;
            for (int i = 0; i < inventory.Length - 1; i++)
            {
                if (inventory[i].Split(';')[attributeIdentifier - 1].ToLower().Contains(search.ToLower()))
                {
                    searchedInventory.Add(inventory[i]);
                }
            }
            searchedInventory.Add("");
            if (searchedInventory.Count == 1)
            {
                Console.Write("Der blev ikke fundet noget. Vil du starte en ny søgning? (y/n): ");
                while ((sInput = Console.ReadLine().ToLower()) != "y" && sInput != "n")
                {
                    Console.Clear();
                    Console.Write("Vil du starte en ny søgning? (y/n): ");
                }
                Console.Clear();
                return sInput;
            }
            else if (searchedInventory.Count == 2)
            {
                string[] searchedInventoryArray = searchedInventory.ToArray();
                DisplayRequestInventory(searchedInventoryArray);
                Console.Write("\nVil du redigere denne anmodning? (y/n): ");
                while ((sInput = Console.ReadLine().ToLower()) != "y" && sInput != "n")
                {
                    Console.Clear();
                    Console.Write("Vil du redigere denne anmodning? (y/n): ");
                }

                if (sInput == "y")
                {
                    Console.WriteLine(EditRequest(searchedInventory[0].Split(';')[0]));
                    Console.ReadLine();
                }
                sInput = "n";
                return sInput;
            }
            else
            {
                string[] searchedInventoryArray = searchedInventory.ToArray();
                DisplayRequestInventory(searchedInventoryArray);
                Console.Write("\nVil du fortsætte søgningen? (y/n): ");
                while ((sInput = Console.ReadLine().ToLower()) != "y" && sInput != "n")
                {
                    Console.Clear();
                    Console.Write("Vil du fortsætte søgningen? (y/n): ");
                }
                if (sInput.ToLower() == "y")
                {
                    sInput = InitiateRequestSearch(searchedInventoryArray);
                }
            }
            return sInput;
        }
    }
}