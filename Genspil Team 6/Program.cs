using System.Runtime.Intrinsics.X86;

namespace Genspil_Team_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();
            inventory.LoadDatabase();

            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Seach for game");
            Console.WriteLine("2. Save Database");
            Console.WriteLine("3. Load Database");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Please write the name of the game you'd like to search for:");
                    inventory.Search(Console.ReadLine());
                    break;
            }
        }
    }
}
