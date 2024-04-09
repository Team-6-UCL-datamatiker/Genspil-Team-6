namespace Genspil_Team_6
{
    internal class Request(string requestID, string gameName, string customerName, int customerPhoneNumber, string userID)
    {
        public string RequestID { get; set; } = requestID;
        public string GameName { get; set; } = gameName;
        public string CustomerName { get; set; } = customerName;
        public int CustomerPhoneNumber { get; set; } = customerPhoneNumber;
        public string UserID { get; set; } = userID;
        public string CreateInventoryItem()
        {
            return $"{RequestID};{GameName};{CustomerName};{CustomerPhoneNumber};{UserID}";
        }
    }

}
