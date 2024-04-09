using System.Runtime.Intrinsics.X86;

namespace Genspil_Team_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string directory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string databasePath = Path.Combine(directory, "Database.txt");

            Console.WriteLine(databasePath.ReadToEnd());
        }
    }
}
