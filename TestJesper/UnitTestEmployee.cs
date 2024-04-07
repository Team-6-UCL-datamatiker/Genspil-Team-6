using Genspil_Team_6;
using System.Security.Cryptography.X509Certificates;

namespace TestEmployee
{
    [TestClass]
    public class UnitTestEmployee
    {
        private Employee employee;

        [TestInitialize]
        public void Init()
        {
            employee = new Employee("Jesper", "001", 1) ;
        }

        [TestMethod]
        public void EmployeeExists()
        {
            Assert.IsNotNull(employee);
        }
        [TestMethod]
        public void EmployeeNamePositive()
        {
            Assert.AreEqual("Jesper", employee.Name);
        }
        [TestMethod]
        public void EmployeeNameNegative()
        {
            Assert.AreNotEqual("", employee.Name);
        }
        [TestMethod]
        public void EmployeeIDisString()
        {
            if (employee.UserID is not string)
            { 
                Assert.Fail();
            }
                        
        }

    }
}