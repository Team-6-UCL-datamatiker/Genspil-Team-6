using Genspil_Team_6;
using Microsoft.VisualStudio.TestPlatform.Common;

namespace GenspilTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckRequestConstructor()
        {
            //ARRANGE
            string gameName = "Jeppe's spil";
            int requestID = 1;
            string customerName = "Jens Hansen";
            string customerPhone = "88888888";

            //ACT
            Request request = new Request(gameName, requestID, customerName, customerPhone);

            //ASSERT
            Assert.AreEqual(gameName, request.GameName);
            Assert.AreEqual(requestID, request.RequestID);
            Assert.AreEqual(customerName, request.CustomerName);
            Assert.AreEqual(customerPhone, request.CustomerPhone);
        }

        [TestMethod]
        public void CheckEmployeeConstructor()
        {
            //ARRANGE
            string name = "Anders Andersen";
            string userID = "4";
            int accessLevel = 2;

            //ACT
            Employee employee = new Employee(name, userID, accessLevel);

            //ASSERT
            Assert.AreEqual(name, employee.Name);
            Assert.AreEqual(userID, employee.UserID);
            Assert.AreEqual(accessLevel, employee.AccessLevel);
        }

        [TestMethod]
        public void CheckBoardGameConstructor()
        {
            //ARRANGE
            string gameName = "Stratego";
            string genre = "Strategy";
            string condition = "GOOD";
            int gameID = 23;
            int noOfPlayers = 2;
            double price = 120;
            bool available = true;

            //ACT
            BoardGame game = new BoardGame(gameName, genre, condition, gameID, noOfPlayers, price, available);

            //ASSERT
            Assert.AreEqual(gameName, game.GameName);
            Assert.AreEqual(genre, game.Genre);
            Assert.AreEqual(condition, game.Condition);
            Assert.AreEqual(gameID, game.GameID);
            Assert.AreEqual(noOfPlayers, game.NoOfPlayers);
            Assert.AreEqual(price, game.Price);
            Assert.AreEqual(available, game.Available);      
        }

    }
}