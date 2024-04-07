using Genspil_Team_6;
using System;
using System.Runtime.CompilerServices;

namespace Genspil_Team_6
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }

        //Display methods
        static void DisplayMainMenu()
        {
            Console.WriteLine("Welcome to the Genspil Database System!\n");
            Console.WriteLine("------------------------");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("1. Display Inventory");
            Console.WriteLine("2. Search Games");
            Console.WriteLine("3. Add Game");
            Console.WriteLine("4. Remove Game");
            Console.ResetColor();
            Console.WriteLine("------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("5. Display Requests");
            Console.WriteLine("6. Add Request");
            Console.WriteLine("7. Remove Request");
            Console.ResetColor();
            Console.WriteLine("------------------------");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("8. Exit");
            Console.ResetColor();
            Console.WriteLine("------------------------");
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
