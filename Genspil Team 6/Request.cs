﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil_Team_6
{
    public class Request(string gameName, int requestID, string customerName, string customerPhone)
    {
        public string GameName { get; set; } = gameName;
        public int RequestID { get; set; } = requestID;
        public string CustomerName { get; set; } = customerName;
        public string CustomerPhone { get; set; } = customerPhone;
    }
}
