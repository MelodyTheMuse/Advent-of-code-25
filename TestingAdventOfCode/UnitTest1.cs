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
        int output = 0;
        circle.getClickers("L99", 0, 50, out output);
        Assert.That(output, Is.EqualTo(51));
    }

    [Test]
    public void testCalc2NewNumber()
    {
        Circle circle = new Circle();
        int output = 0;
        Assert.That(circle.getClickers("R200",0,50,out output), Is.EqualTo(2));
    }

    [Test]
    public void testRunWParameter()
    {
        List<string> input = File.ReadAllLines("test_input.txt").ToList();
        Circle circle = new Circle();
        Assert.That(circle.RunFromParameter(input), Is.EqualTo(6));
    }

    [Test]
    public void testRunGParameter()
    {
        List<string> input = File.ReadAllLines("genelle_test.txt").ToList();
        Circle circle = new Circle();
        Assert.That(circle.RunFromParameter(input), Is.EqualTo(2));
    }

    [Test]
    public void testRunRParameter()
    {
        List<string> input = File.ReadAllLines("test_r_input.txt").ToList();
        Circle circle = new Circle();
        Assert.That(circle.RunFromParameter(input), Is.EqualTo(16));
    }
    [Test]
    public void testRunGIParameter()
    {
        List<string> input = File.ReadAllLines("genell_input.txt").ToList();
        Circle circle = new Circle();
        Assert.That(circle.RunFromParameter(input), Is.EqualTo(5941));
    }


    public void testRun()
    {
        Circle circle = new Circle();
        Assert.That(circle.Run(), Is.EqualTo(3961));
    }
    [Test]
    public void Part2_Test_3()
    {
        Circle circle = new Circle();
        List<string> res = new List<string>();
        res.Add("R50");
        Assert.That(circle.RunFromParameter(res), Is.EqualTo(1));
    }

    [Test]
    public void Part2_Test_4()
    {
        Circle circle = new Circle();
        List<string> res = new List<string>();
        res.Add("R51");
        Assert.That(circle.RunFromParameter(res), Is.EqualTo(1));
    }

    [Test]
    public void Part2_Test_5()
    {
        Circle circle = new Circle();
        List<string> res = new List<string>();
        res.Add("L50");
        Assert.That(circle.RunFromParameter(res), Is.EqualTo(1));
    }

    [Test]
    public void Part2_Test_6()
    {
        Circle circle = new Circle();
        List<string> res = new List<string>();
        res.Add("L51");
        Assert.That(circle.RunFromParameter(res), Is.EqualTo(1));
    }


    [Test]
    public void Part2_Test_7()
    {
        Circle circle = new Circle();
        List<string> res = new List<string>();
        res.Add("L51");
        res.Add("R100");
        res.Add("L201");
        res.Add("R3");
        Assert.That(circle.RunFromParameter(res), Is.EqualTo(5));
    }

    [Test]
    public void Part2_Test_8()
    {
        Circle circle = new Circle();
        List<string> res = new List<string>();
        res.Add("R1000");
        Assert.That(circle.RunFromParameter(res), Is.EqualTo(10));
    }
    [Test]
    public void Part2_Test_2()
    {
        Circle circle = new Circle();
        List<string> res = new List<string>();
        res.Add("L1000");
        Assert.That(circle.RunFromParameter(res), Is.EqualTo(10));
    }

    [Test]
    public void Part2_Test_9()
    {
        Circle circle = new Circle();
        List<string> res = new List<string>();
        res.Add("R1000");
        res.Add("L1000");
        Assert.That(circle.RunFromParameter(res), Is.EqualTo(20));
    }
    

}