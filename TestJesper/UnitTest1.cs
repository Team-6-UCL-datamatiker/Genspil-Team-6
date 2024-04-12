using Genspil_Team_6;

namespace TestJesper;

[TestClass]
public class UnitTest1()
{
    Employee employee;
    Game game;

    [TestInitialize]
    public void Init()
    {
        employee = new Employee("Jesper", "Jesper", 1) ;
        game = new Game("DnD", "fantasy", "good", 11, 5, 123.99, true) ;
    }


    [TestMethod]
    public void ObjectsExists()
    {
        Assert.IsNotNull(employee);
        Assert.IsNotNull(game);
    }
    [TestMethod]
    public void ObjectPositive()
    {
        Assert.AreEqual("Jesper", employee.Name);
        Assert.AreEqual("DnD", game.GameName);
    }
    [TestMethod]
    public void ObjectNegative()
    {
        
    }
    [TestMethod]
    public void LimitTest()
    {
        employee.AccessLevel = 4;
        if (employee.AccessLevel > 2) 
        {
            Assert.Fail();
        }
    }
    [TestMethod]
    public void EncapsulationTestEmployee()
    {
        employee.AccessLevel = 2;
        if (employee.AccessLevel == 2)
        {
            Assert.Fail();
        }
    }
    [TestMethod]
    public void EncapsulationTestGame()
    {
        game.GameName = "Something wrong";
        if (game.GameName == "Something wrong")
        {
            Assert.Fail();
        }
    }

}