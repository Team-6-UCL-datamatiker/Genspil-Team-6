using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil_Team_6
{
    internal class Inventory
    {           
        public List<Game> Games { get; set; }
        public List<Request> Requests { get; set; }
        

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

        }
        public void LoadDatabase() 
        { 

        }
        public void RequestToGame(Game game,Request request)
        {
            
        }
    }
}
