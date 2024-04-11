using Genspil_Team_6;

namespace TestJesper;

[TestClass]
public class UnitTestEmployee(Employee employee)
{
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
        if (employee.UserId is not not null)
        { 
            Assert.Fail();
        }       
    }
    [TestMethod]
    public void TestToString()
    {
        Assert.AreEqual("Name: Jesper, UserID: 001, AccessLevel: 1", employee.ToString());
    }

}