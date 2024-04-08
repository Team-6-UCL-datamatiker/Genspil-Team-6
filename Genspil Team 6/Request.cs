using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Genspil_Team_6
{
    internal class Request(string requestID, string gameName, string customerName, int customerPhoneNumber)
    {
        public string RequestID { get; set; } = requestID;
        public string GameName { get; set; } = gameName;
        public string CustomerName { get; set; } = customerName;
        public int CustomerPhoneNumber { get; set; } = customerPhoneNumber;
        public string CreateInventoryItem()
        {
            return $"{RequestID};{GameName};{CustomerName};{CustomerPhoneNumber}";
        }
    }

}
