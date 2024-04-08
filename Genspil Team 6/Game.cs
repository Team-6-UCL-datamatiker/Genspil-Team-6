using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Genspil_Team_6
{
    internal class Game(string gameID, string name, string genre, string condition, int minNoOfPlayers, int maxNoOfPlayers, bool available, double price)
    {
        public string GameID { get; set; } = gameID;
        public string Name { get; set; } = name;
        public string Genre { get; set; } = genre;
        public string Condition { get; set; } = condition;
        public int MinNoOfPlayers { get; set; } = minNoOfPlayers;
        public int MaxNoOfPlayers { get; set; } = maxNoOfPlayers;
        public bool Available { get; set; } = available;
        public double Price { get; set; } = price;
        public string CreateInventoryItem()
        {
            return $"{GameID};{Name};{Genre};{Condition};{MinNoOfPlayers};{MaxNoOfPlayers};{Available};{Price}";
        }
    }
}
