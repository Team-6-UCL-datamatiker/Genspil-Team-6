namespace Genspil_Team_6
{
    internal class Tester
    {
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
        public static void FileTest(string identifier)
        {
            if (!File.Exists(identifier))
            {
                using StreamWriter sw = new(identifier);
            }
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
        public static int MaxIntTest(string identifier, int minNoOfPlayers)
        {
            int input;
            while (int.TryParse(Console.ReadLine(), out input) == false || input < minNoOfPlayers)
            {
                Console.Clear();
                Console.WriteLine($"{identifier} skal være et tal og må ikke være mindre end minimum antal spillere: ");
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
        public static bool IDMatchTest(string id, string[] inventory)
        {
            bool bID = false;
            foreach (string line in inventory)
            {
                if (line.Substring(0, 3) == id)
                {
                    bID = true;
                    break;
                }
            }
            return bID;
        }
        public static string IDIterateTest(string[] inventory)
        {
            if (inventory.Length == 1)
            {
                return "001";
            }
            else
            {
                int iID = (int.Parse(inventory[^2].Substring(0, 3))) + 1;
                string sID = iID.ToString();
                if (sID.Length < 2)
                {
                    sID = "00" + iID;
                }
                else if (sID.Length < 3)
                {
                    sID = "0" + iID;
                }
                return sID;
            }

        }

    }
}
