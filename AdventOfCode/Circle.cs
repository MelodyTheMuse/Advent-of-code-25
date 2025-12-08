using System.Runtime.InteropServices;

namespace AdventOfCode;

public class Circle
{
    public static Circle _Instance;
    private int CurrentNumber = 50;
    private int maxNumber = 99;
    private int minNumber = 0;
    private int clicks = 0;
    private int steps = 0;
    private bool isNewNumber = false;
    public static int clickers;


    private bool direction(string input)
    {
        if (input.Contains("L"))
        {
            return true;
        }
        return false;
    }

    private static void Main()
    {
      DoRun();
      
    }

    public static void DoRun()
    { 
        clickers  = GetInstance().Run();
    }

    public static Circle GetInstance()
    {
        if (_Instance == null)
            _Instance = new Circle();
        return _Instance;
    }

    public int Run()
    {
        foreach (var item in input)
        {
            isNewNumber = true;
            GetClick(item);
            steps++;
            Console.WriteLine(clicks + " clicks");
            Console.WriteLine(steps + " steps");
            Console.WriteLine(CurrentNumber + " current number");
        }

        return clicks;

    }
    
    public int RunFromParameter(List<string> input)
    {
        foreach (var item in input)
        {
            isNewNumber = true;
            GetClick(item);
            steps++;
            Console.WriteLine(clicks + " clicks");
            Console.WriteLine(steps + " steps");
            Console.WriteLine(CurrentNumber + " current number");
        }

        return clicks;

    }

    private void GetClick(string input)
    {
        var output = splitStringInt(input);
        CurrentNumber = CalculateNewNumber(currentNumber: CurrentNumber, input: output, direction: direction(input));
        if (CurrentNumber == 0)
        {
            clicks++;
        }
    }
    public int CalculateNewNumber(int currentNumber, int input, bool direction,bool isnewNumber = true)
    {
        int difference;
        if (direction)
        {
            if ((currentNumber - input) < minNumber)
            {
               clicks++;
               if (currentNumber == minNumber)
               {
                   difference = (currentNumber ) - input +1;
               }
               else
               {
                   difference = input - (currentNumber) +1;
               }

               var newNumber = checkNewNumber(difference, direction);
                return newNumber;
            }

            if (currentNumber - input != minNumber || currentNumber - input > minNumber && currentNumber - input < maxNumber) return currentNumber - input;
            if (currentNumber == minNumber)
            {
                return minNumber;
            }
            
        }
        if ((currentNumber + input) > maxNumber)
        {
            clicks++;
            difference = input- (maxNumber - currentNumber) -1   ;
            var newNumber = checkNewNumber(difference, direction);
            return newNumber;
        }

        if (currentNumber + input != maxNumber || currentNumber + input < maxNumber) return currentNumber + input;
        if(currentNumber == maxNumber ){ return maxNumber;}
      
       return currentNumber;
    }
    
    private int splitStringInt(string input) => int.Parse(input.Substring(1));
    
    
    private List<string> input = File.ReadAllLines("D:\\Repo\\My own Projects\\Advent-of-code-25\\input.txt").ToList();

    public int checkNewNumber(int newNumber, bool direction)
    { int difference;
        if (newNumber == minNumber )
        {
            return newNumber;
        }
        if (newNumber > maxNumber)
        {
            return CalculateNewNumber(minNumber, newNumber, direction);
        }
        if (newNumber < minNumber)
        {
            newNumber *= -1;
            return CalculateNewNumber(maxNumber, newNumber, direction);
        } 
        return newNumber;
    }
}