using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil_Team_6
{

    internal class Request 
    { 
        public string GameName { get; set; }
        public int RequestID { get; set; }
        public string CustomerName { get; set; }
        public int CustomerPhoneNumber { get; set; }


        public Request(string gameName, int requestID) 
        { 
            GameName = gameName;
            RequestID = requestID;
        }
        public Request(string gameName, int requestID, string customerName) 
        { 
            GameName = gameName;
            RequestID = requestID;
            CustomerName = customerName;
        }
        public Request(string gameName, int requestID, string customerName, int customerPhoneNumber) 
        {
            GameName = gameName;
            RequestID = requestID;
            CustomerName = customerName;
            CustomerPhoneNumber = customerPhoneNumber;
        }
        public override string ToString()
        {
            return base.ToString();
        }

    } 

}
