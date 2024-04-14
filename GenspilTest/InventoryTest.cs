using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Genspil_Team_6;

namespace GenspilTest
{
    [TestClass]
    public class InventoryTest
    {

        [TestMethod]
        public void CheckifGameDatabaseFileExists()
        {
            Inventory inventory = new Inventory();

            //Program.CreateDatabaseFiles();

            string currentDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string filePath = Path.Combine(currentDirectory, "GameDatabase.txt");

            Assert.IsTrue(File.Exists(filePath), "File does not exist");
        }

        [TestMethod]
        public void CheckIFGameAddedToDatabase()
        {
            Inventory inventory = new Inventory();

            string gameName = "Ludo";
            string genre = "Family";
            string condition = "good";
            int gameId = 123;
            int noOfPlayers = 4;
            double price = 50;
            string available = "y";

            using (StringReader stringReader = new StringReader($"{gameName}\n{genre}\n{condition}\n{gameId}\n{noOfPlayers}\n{price}\n{available}\n"))
            {
                Console.SetIn(stringReader);

                inventory.AddGame();
                inventory.SaveInventoryToFile();
            }

            string currentDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string filePath = Path.Combine(currentDirectory, "GameDatabase.txt");

            Assert.IsTrue(File.Exists(filePath), "File does not exist");

            string[] lines = File.ReadAllLines(filePath);
            string lastLine = lines[lines.Length - 1];

            Assert.IsTrue(lastLine.Contains("Ludo"), "New game was not added");
        }
    }
}
