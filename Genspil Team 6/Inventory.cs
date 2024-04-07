using Genspil_Team_6;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Genspil_Team_6
{
    public class Inventory
    {
        private List<BoardGame> games = new List<BoardGame>();
        private List<Request> requests = new List<Request>();

        private string gameDatabasePath = @"C:\Users\Jeppe Lynge\Documents\Datamatiker\Projekt 3 - Genspil\Genspil-Team-6\Genspil Team 6\GameDatabase.txt";
        private string requestDatabasePath = @"C:\Users\Jeppe Lynge\Documents\Datamatiker\Projekt 3 - Genspil\Genspil-Team-6\Genspil Team 6\RequestDatabase.txt";
    }
}

