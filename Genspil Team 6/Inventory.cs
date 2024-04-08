using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Genspil_Team_6
{
    internal class Inventory
    {
        public static string[] LoadInventoryFile(string fileName)
        {
            using StreamReader sr = new(fileName);
            string[] lines = sr.ReadToEnd().Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            for (int i = 0; i < lines.Length - 1; i++)
            {
                string[] gameAttributes = lines[i].Split(';');
                if (fileName == "Inventory.txt")
                {
                    gameAttributes[^1] = gameAttributes[^1] == "True" ? "Ja" : "Nej";
                }
                lines[i] = string.Join(";", gameAttributes);
            }
            return lines;
        }
        public static void DisplayGameInventory(string[] lines)
        {
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("{0,-5}{1,-15}{2,-15}{3,-15}{4,-10}{5,-14}{6,-10}",
                  "ID", "Navn", "Genre", "Tilstand", "Spillere", "Tilgængeligt", "Pris");

            Console.WriteLine();
            DisplayGameInventoryLines(lines);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public static void DisplayRequestInventory(string[] lines)
        {
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("{0,-5}{1,-15}{2,-20}{3,-8}",
                  "ID", "Spil", "Kunde", "Telefon");

            Console.WriteLine();
            DisplayRequestInventoryLines(lines);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public static void DisplayGameInventoryLines(string[] lines)
        {
            try
            {
                for (int i = 0; i < lines.Length - 1; i++)
                {
                    string[] gameAttributes = lines[i].Split(';');
                    if (i % 2 == 0)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }
                    else { Console.BackgroundColor = ConsoleColor.DarkBlue; }
                    Console.WriteLine("{0,-5}{1,-15}{2,-15}{3,-15}{4,-10}{5,-14}{6,6}{7,-4}", gameAttributes[3], gameAttributes[0], gameAttributes[1], gameAttributes[2], gameAttributes[4] + "-" + gameAttributes[5], gameAttributes[7], gameAttributes[6], " kr.");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
        public static void DisplayRequestInventoryLines(string[] lines)
        {
            try
            {
                for (int i = 0; i < lines.Length - 1; i++)
                {
                    string[] requestAttributes = lines[i].Split(';');
                    if (i % 2 == 0)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }
                    else { Console.BackgroundColor = ConsoleColor.DarkBlue; }
                    Console.WriteLine("{0,-5}{1,-15}{2,-20}{3,-8}", requestAttributes[0], requestAttributes[1], requestAttributes[2], requestAttributes[3]);
                    Console.BackgroundColor = ConsoleColor.Black;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
        public static void AddGame()
        {
            Console.Write("Navn: ");
            string name = StringTest("Navnet");

            Console.Write("Genre: ");
            string genre = StringTest("Genren");

            Console.Write("Tilstand: ");
            string condition = StringTest("Tilstanden");

            Console.Write("Spil ID: ");
            int gameID = IntTest("ID'et");

            Console.Write("Min antal spillere: ");
            int minNoOfPlayers = IntTest("Min antal spillere");

            Console.Write("Max antal spillere: ");
            int maxNoOfPlayers = IntTest("Max antal spillere");

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

            Game game = new(name, genre, condition, gameID, minNoOfPlayers, maxNoOfPlayers, price, available);

            try
            {
                using StreamWriter sw = new("Inventory.txt", true);
                sw.WriteLine(game.CreateInventoryItem());
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            Console.WriteLine("Spillet er tilføjet. Tryk på en vilkårlig knap for at vende retur til menuen.");
            Console.ReadLine();
        }
        public static void AddGame(string gameName)
        {
            Console.Clear();
            Console.WriteLine($"Navnet på spillet er {gameName}.\n");
            string name = gameName;

            Console.Write("Genre: ");
            string genre = StringTest("Genren");

            Console.Write("Tilstand: ");
            string condition = StringTest("Tilstanden");

            Console.Write("Spil ID: ");
            int gameID = IntTest("ID'et");

            Console.Write("Min antal spillere: ");
            int minNoOfPlayers = IntTest("Min antal spillere");

            Console.Write("Max antal spillere: ");
            int maxNoOfPlayers = IntTest("Max antal spillere");

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

            Game game = new(name, genre, condition, gameID, minNoOfPlayers, maxNoOfPlayers, price, available);

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
        public static void AddRequest()
        {
            Console.Write("Anmodning ID: ");
            int requestID = IntTest("ID'et");

            Console.Write("Navn på spil: ");
            string gameName = StringTest("Navnet");

            Console.Write("Kundes fulde navn: ");
            string customerName = StringTest("Kundens navn");

            Console.Write("Kundens telefonnummer: ");
            int dInput;
            while ((int.TryParse(Console.ReadLine(), out dInput) == false) || dInput < 10000000 || dInput > 99999999)
            {
                Console.Clear();
                Console.Write("Telefonnummeret skal være et 8-cifret tal: ");
            }
            Console.Clear();
            int customerPhoneNumber = dInput;

            Console.Clear();
            Request request = new(requestID, gameName, customerName, customerPhoneNumber);

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
        public static string StringTest(string identifier)
        {
            string input;
            while (string.IsNullOrEmpty(input = Console.ReadLine()))
            {
                Console.Clear();
                Console.Write($"{identifier} skal bestå af mindst ét tegn: ");
            }
            Console.Clear();
            return input.Substring(0, 1).ToUpper() + input.Substring(1).ToLower();
        }
        public static int IntTest(string identifier)
        {
            int input;
            while (int.TryParse(Console.ReadLine(), out input) == false)
            {
                Console.Clear();
                Console.WriteLine($"{identifier} skal være et tal: ");
            }
            Console.Clear();
            return input;
        }
        public static double DoubleTest(string identifier)
        {
            double input;
            while (double.TryParse(Console.ReadLine(), out input) == false)
            {
                Console.Clear();
                Console.WriteLine($"{identifier} skal være et tal: ");
            }
            Console.Clear();
            return input;
        }
        public static bool BoolTest(string identifier)
        {
            bool input;
            while (bool.TryParse(Console.ReadLine(), out input) == false)
            {
                Console.Clear();
                Console.WriteLine($"{identifier} skal sættes til true/false: ");
            }
            Console.Clear();
            return input;
        }
        public static bool IDTest(string id, string[] inventory)
        {
            bool bID = false;
            foreach (string line in inventory)
            {
                if (line.Contains(id))
                {
                    bID = true;
                    break;
                }
            }
            return bID;
        }
        public static string EditGame(string id)
        {
            string[] inventory = LoadInventoryFile("Inventory.txt");
            if (IDTest(id, inventory) == false)
            {
                return "ID'et kan ikke genkendes. Tryk på en vilkårlig tast for at vende tilbage til menuen. ";
            }

            int attributeIdentifier;
            Console.WriteLine("\nHvad vil du redigere?\n");
            Console.WriteLine("1: Navn\n2: Genre\n3: Tilstand\n4: ID\n5: Min spillere\n6: Max spillere\n7: Max pris\n8: Tilgængelighed\n9: Slet spillet\n");
            while (int.TryParse(Console.ReadLine(), out attributeIdentifier) == false || (attributeIdentifier < 1 || attributeIdentifier > 9))
            {
                Console.Clear();
                Console.WriteLine("Indtast venligst et tal mellem 1 og 9.\n");
                Console.WriteLine("1: Navn\n2: Genre\n3: Tilstand\n4: ID\n5: Min spillere\n6: Max spillere\n7: Max pris\n8: Tilgængelighed\n9: Slet spillet\n");
            }

            string identifier;
            switch (attributeIdentifier)
            {
                case 1:
                    identifier = "Navnet";
                    Console.Write("\nHvad skal variablen ændres til? ");
                    return EditGameAttribute(id, inventory, attributeIdentifier, identifier, StringTest(identifier));
                case 2:
                    identifier = "Genren";
                    Console.Write("\nHvad skal variablen ændres til? ");
                    return EditGameAttribute(id, inventory, attributeIdentifier, identifier, StringTest(identifier));
                case 3:
                    identifier = "Tilstanden";
                    Console.Write("\nHvad skal variablen ændres til? ");
                    return EditGameAttribute(id, inventory, attributeIdentifier, identifier, StringTest(identifier));
                case 4:
                    identifier = "ID'et";
                    Console.Write("\nHvad skal variablen ændres til? ");
                    return EditGameAttribute(id, inventory, attributeIdentifier, identifier, IntTest(identifier).ToString());
                case 5:
                    identifier = "Min spillere";
                    Console.Write("\nHvad skal variablen ændres til? ");
                    return EditGameAttribute(id, inventory, attributeIdentifier, identifier, IntTest(identifier).ToString());
                case 6:
                    identifier = "Max spillere";
                    Console.Write("\nHvad skal variablen ændres til? ");
                    return EditGameAttribute(id, inventory, attributeIdentifier, identifier, IntTest(identifier).ToString());
                case 7:
                    identifier = "Prisen";
                    Console.Write("\nHvad skal variablen ændres til? ");
                    return EditGameAttribute(id, inventory, attributeIdentifier, identifier, DoubleTest(identifier).ToString());
                case 8:
                    identifier = "Prisen";
                    Console.Write("\nHvad skal variablen ændres til? ");
                    return EditGameAttribute(id, inventory, attributeIdentifier, identifier, BoolTest(identifier).ToString());
                case 9:
                    for (int i = 0; i < inventory.Length - 1; i++)
                    {
                        if (inventory[i].Contains(id))
                        {
                            inventory[i] = "";
                            break;
                        }
                    }
                    StreamWriter sw = new("InventoryTemp.txt");
                    for (int i = 0; i < inventory.Length - 1; i++)
                    {
                        if (inventory[i] != "")
                        {
                            sw.WriteLine(inventory[i]);
                        }
                    }
                    sw.Close();
                    File.Delete("Inventory.txt");
                    File.Move("InventoryTemp.txt", "Inventory.txt");
                    return "Spillet er blevet slettet. Tryk på en vilkårlig tast for at vende tilbage til menuen.";
                default:
                    return "n";
            }
        }
        public static string EditRequest(string id)
        {
            string[] inventory = LoadInventoryFile("Requests.txt");
            if (IDTest(id, inventory) == false)
            {
                return "ID'et kan ikke genkendes. Tryk på en vilkårlig tast for at vende tilbage til menuen. ";
            }

            int attributeIdentifier;
            Console.WriteLine("\nHvad vil du redigere?\n");
            Console.WriteLine("1: ID\n2: Spil\n3: Kunde\n4: Telefonnummer\n5: Slet anmodningen\n6: Transformer til spil\n");
            while (int.TryParse(Console.ReadLine(), out attributeIdentifier) == false || (attributeIdentifier < 1 || attributeIdentifier > 6))
            {
                Console.Clear();
                Console.WriteLine("Indtast venligst et tal mellem 1 og 6.\n");
                Console.WriteLine("1: ID\n2: Spil\n3: Kunde\n4: Telefonnummer\n5: Slet anmodningen\n6: Transformer til spil\n");
            }

            string identifier;
            switch (attributeIdentifier)
            {
                case 1:
                    identifier = "ID'et";
                    Console.Write("\nHvad skal variablen ændres til? ");
                    return EditRequestAttribute(id, inventory, attributeIdentifier, identifier, IntTest(identifier).ToString());
                case 2:
                    identifier = "Spillet";
                    Console.Write("\nHvad skal variablen ændres til? ");
                    return EditRequestAttribute(id, inventory, attributeIdentifier, identifier, StringTest(identifier));
                case 3:
                    identifier = "Kunden";
                    Console.Write("\nHvad skal variablen ændres til? ");
                    return EditRequestAttribute(id, inventory, attributeIdentifier, identifier, StringTest(identifier));
                case 4:
                    identifier = "Telefonnummeret";
                    Console.Write("\nHvad skal variablen ændres til? ");
                    return EditRequestAttribute(id, inventory, attributeIdentifier, identifier, IntTest(identifier).ToString());
                case 5:
                    for (int i = 0; i < inventory.Length - 1; i++)
                    {
                        if (inventory[i].Contains(id))
                        {
                            inventory[i] = "";
                            break;
                        }
                    }
                    StreamWriter sw = new("RequestsTemp.txt");
                    for (int i = 0; i < inventory.Length - 1; i++)
                    {
                        if (inventory[i] != "")
                        {
                            sw.WriteLine(inventory[i]);
                        }
                    }
                    sw.Close();
                    File.Delete("Requests.txt");
                    File.Move("RequestsTemp.txt", "Requests.txt");
                    return "Anmodningen er blevet slettet. Tryk på en vilkårlig tast for at vende tilbage til menuen.";
                case 6:
                    string[] requestAttributes = new string[3];
                    for (int i = 0; i < inventory.Length - 1; i++)
                    {
                        
                        if (inventory[i].Contains(id))
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
        public static string EditGameAttribute(string id, string[] inventory, int attributeIdentifier, string identifier, string testMethod)
        {
            StreamReader sr = new("Inventory.txt");
            StreamWriter sw = new("InventoryTemp.txt");
            string newValue = "";
            for (int i = 0; i < inventory.Length - 1; i++)
            {
                if (inventory[i].Contains(id))
                {
                    string[] gameAttributes = inventory[i].Split(';');
                    gameAttributes[attributeIdentifier - 1] = testMethod;
                    newValue = gameAttributes[attributeIdentifier - 1];
                    inventory[i] = string.Join(";", gameAttributes);
                    break;
                }
            }
            for (int i = 0; i < inventory.Length - 1; i++)
            {
                sw.WriteLine(inventory[i]);
            }
            sr.Close();
            sw.Close();
            File.Delete("Inventory.txt");
            File.Move("InventoryTemp.txt", "Inventory.txt");
            return $"Værdien for {identifier} blev ændret til {newValue}. Tryk på en vilkårlig tast for at vende tilbage til menuen.";
        }
        public static string EditRequestAttribute(string id, string[] inventory, int attributeIdentifier, string identifier, string testMethod)
        {
            StreamReader sr = new("Requests.txt");
            StreamWriter sw = new("RequestsTemp.txt");
            string newValue = "";
            for (int i = 0; i < inventory.Length - 1; i++)
            {
                if (inventory[i].Contains(id))
                {
                    string[] requestAttributes = inventory[i].Split(';');
                    requestAttributes[attributeIdentifier - 1] = testMethod;
                    newValue = requestAttributes[attributeIdentifier - 1];
                    inventory[i] = string.Join(";", requestAttributes);
                    break;
                }
            }
            for (int i = 0; i < inventory.Length - 1; i++)
            {
                sw.WriteLine(inventory[i]);
            }
            sr.Close();
            sw.Close();
            File.Delete("Requests.txt");
            File.Move("RequestsTemp.txt", "Requests.txt");
            return $"Værdien for {identifier} blev ændret til {newValue}. Tryk på en vilkårlig tast for at vende tilbage til menuen.";
        }
        public static string InitiateSearch(string[] lines)
        {
            string sInput = "";
            while (sInput != "n")
            {
                int iInput;
                Console.Clear();
                Console.WriteLine("Hvad vil du sortere efter?\n");
                Console.WriteLine("1: Navn\n2: Genre\n3: Tilstand\n4: ID\n5: Min spillere\n6: Max spillere\n7: Max pris\n8: Tilgængelighed\n");
                while (int.TryParse(Console.ReadLine(), out iInput) == false || (iInput < 1 || iInput > 8))
                {
                    Console.Clear();
                    Console.Write("Attributindentifikatoren skal være et tal mellem 1 og 8: ");
                }
                Console.Clear();
                Console.Write("Hvad vil du søge efter? :");
                sInput = Search(iInput, Console.ReadLine(), lines);
            }
            return "n";
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
                while (int.TryParse(Console.ReadLine(), out iInput) == false || (iInput < 1 || iInput > 8))
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
        public static string Search(int attributeIdentifier, string search, string[] inventory)
        {
            Console.Clear();
            List<string> searchedInventory = new List<string>();
            string sInput;
            for (int i = 0; i < inventory.Length - 1; i++)
            {
                if (attributeIdentifier == 7)
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
                Console.Write("\nDer blev ikke fundet noget. Vil du starte en ny søgning? (y/n): ");
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
                    Console.WriteLine(EditGame(searchedInventory[0].Split(';')[3]));
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
                    sInput = InitiateSearch(searchedInventoryArray);
                }
            }
            return sInput;
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
                Console.Write("\nDer blev ikke fundet noget. Vil du starte en ny søgning? (y/n): ");
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
                    Console.WriteLine(EditRequest(searchedInventory[0].Split(';')[3]));
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
