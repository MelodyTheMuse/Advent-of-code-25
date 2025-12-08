using AdventOfCode;

namespace TestingAdventOfCode;

public class CircleTests
{
    [SetUp]
    public void Setup()
    {
    }
    [Test]
    public void checkNewNumber()
    {
        Circle circle = new Circle();
        Assert.That(circle.checkNewNumber((-12), true), Is.EqualTo(87));
    }


    [Test]
    public void testCalcNewNumber()
    {
        Circle circle = new Circle();
        Assert.That(circle.CalculateNewNumber(0, 99, true), Is.EqualTo(1));
    }
    
    [Test]
    public void testCalc2NewNumber()
    {
        Circle circle = new Circle();
        Assert.That(circle.CalculateNewNumber(0, 200, false), Is.EqualTo(0));
    }
    
    [Test]
    public void testRunWParameter() 
    {
        List<string> input = File.ReadAllLines("/home/kiana/Documents/Repo/Coding Projects/Advent-of-code-25/test_input.txt").ToList(); 
        Circle circle = new Circle();
        Assert.That(circle.RunFromParameter(input), Is.EqualTo(6));
    }
    
    [Test]
    public void testRunRParameter() 
    {
        List<string> input = File.ReadAllLines("/home/kiana/Documents/Repo/Coding Projects/Advent-of-code-25/test_r_input.txt").ToList(); 
        Circle circle = new Circle();
        Assert.That(circle.RunFromParameter(input), Is.EqualTo(15));
    }
    
    
    public void testRun() 
    {
        Circle circle = new Circle();
        Assert.That(circle.Run(), Is.EqualTo(3961));
    }
}