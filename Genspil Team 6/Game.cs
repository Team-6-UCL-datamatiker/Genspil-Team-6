using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Genspil_Team_6
{
    internal class Game(string name, string genre, string condition, int gameID, int minNoOfPlayers, int maxNoOfPlayers, double price, bool available)
    {
        public string Name { get; set; } = name;
        public string Genre { get; set; } = genre;
        public string Condition { get; set; } = condition;
        public int GameID { get; set; } = gameID;
        public int MinNoOfPlayers { get; set; } = minNoOfPlayers;
        public int MaxNoOfPlayers { get; set; } = maxNoOfPlayers;
        public double Price { get; set; } = price;
        public bool Available { get; set; } = available;

        public string CreateInventoryItem()
        {
            return $"{Name};{Genre};{Condition};{GameID};{MinNoOfPlayers};{MaxNoOfPlayers};{Price};{Available}";
        }
    }
}
