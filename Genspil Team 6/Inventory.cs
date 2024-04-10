using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil_Team_6
{
    internal class Inventory
    {           
        private List<Game> Games { get; set; } = new List<Game>();
        private List<Request> Requests { get; set; } = new List<Request>();

        public void Search(string gameName)
        {
            foreach (var item in Games)
            {
                if (item.Name.Contains(gameName) == true)
                {
                    Console.WriteLine(item.Name);
                }
            }
        }

        public void AddGame(Game game)
        {
            Games.Add(game);
        }
        public void RemoveGame(Game game) 
        { 
            Games.Remove(game);
        }
        
        public void AddRequest(Request request)
        {
            Requests.Add(request);
        }

        public void RemoveRequest(Request request)
        {
            Requests.Remove(request);
        }
        public void SaveDatabase()
        {
            string directory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string databasePath = Path.Combine(directory, "Database.txt");

            using (StreamWriter sw = new StreamWriter(databasePath))
            {
                foreach (var game in Games)
                {
                    sw.WriteLine($"{game.Name},{game.Genre},{game.Condition},{game.GameID},{game.NoOfPlayers},{game.Price},{game.Available}");
                }
            }
        }
        public void LoadDatabase() 
        {

            string directory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string databasePath = Path.Combine(directory, "Database.txt");
            StreamReader sr = new StreamReader(databasePath);
            string line = sr.ReadLine();

            while (line != null) 
            { 
                string[] parts = line.Split(',');
                _ = new Game(parts[0], parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), double.Parse(parts[5]), bool.Parse(parts[6]));
            
                line = sr.ReadLine();
            }
            sr.Close();

        }
        public void RequestToGame(Game game,Request request)
        {
            
        }
    }
}
