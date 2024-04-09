using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Genspil_Team_6
{
    internal class Game 
    {
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Condition { get; set; }
        public int GameID { get; set; }
        public int NoOfPlayers { get; set; }
        public double Price { get; set; }
        public bool Available { get; set; }

        public Game(string name, int gameID, bool available) 
        {
            Name = name;
            GameID = gameID;
            Available = available;
        }
        public Game(string name, string genre, string condition, int gameID) 
        {
            Name = name;
            Genre = genre;
            Condition = condition;
            GameID = gameID;
        }
        public Game(string name, string genre, string condition, int gameID, int noOfPlayers) 
        {
            Name = name;
            Genre = genre;
            Condition = condition;
            GameID = gameID;
            NoOfPlayers = noOfPlayers;
        }
        public Game(string name, string genre, string condition, int gameID, int noOfPlayers, double price) 
        { 
            Name = name;
            Genre = genre;
            Condition = condition;
            GameID = gameID;
            NoOfPlayers = noOfPlayers;
            Price = price;
        }
        public Game(string name,string genre, string condition, int gameID, int noOfPlayers, double price, bool available) 
        { 
            Name = name;
            Genre = genre;
            Condition = condition;
            GameID = gameID;
            NoOfPlayers = noOfPlayers;
            Price = price;
            Available = available;
        }
        public override string ToString()
        {
            return $"Name: {Name}, Genre: {Genre}, Condition: {Condition}, GameID {GameID}, Number of players: {NoOfPlayers}, Price: {Price}, Available: {Available}";
        }

    }

}
