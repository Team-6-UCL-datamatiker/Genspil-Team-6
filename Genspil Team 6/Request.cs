using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil_Team_6
{
    internal class Request(string gameName, int requestID, string customerName, int customerPhoneNumber)
    {
        public string GameName { get; set; } = gameName;
        public int RequestID { get; set; } = requestID;
        public string CustomerName { get; set; } = customerName;
        public int CustomerPhoneNumber { get; set; } = customerPhoneNumber;
    }
}
