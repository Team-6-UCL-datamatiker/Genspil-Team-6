﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil_Team_6
{
    public class Game(string gameName, string genre, string condition, int gameID, int noOfPlayers, double price, bool available)
    {
        public string GameName { get; set; } = gameName;
        public string Genre { get; set; } = genre;
        public string Condition { get; set; } = condition;
        public int GameID { get; set; } = gameID;
        public int NoOfPlayers { get; set; } = noOfPlayers;
        public double Price { get; set; } = price;
        public bool Available { get; set; } = available;

        public override string ToString()
        {
            return $"ID: #{GameID}\nGame: {GameName}\nPrice: {Price}\nGenre: {Genre}\nNumber of Players: {NoOfPlayers}\nCondition: {Condition}\nAvailable: {(Available ? "Yes" : "No")}";
        }
    }


}
