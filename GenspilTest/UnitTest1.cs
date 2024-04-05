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
    }
}