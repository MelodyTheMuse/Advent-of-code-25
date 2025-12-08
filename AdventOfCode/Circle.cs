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
            getClickers(item);
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
            getClickers(item);
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
        CurrentNumber = CalculateNewNumber(currentNumber: CurrentNumber, input: output, isLeft: direction(input));
        if (CurrentNumber == 0)
        {
            clicks++;
        }
    }

    public void getClickers(string input)
    {   //First I went to get the input from the list of strings
        //Then I want to calculate currentNumber by using calcnewNumber
        //Then I want to check while it is below 0
        //While below 0 add 100 untill greater or equal to 0
        //Then I want to check while it is above 100
        //While above 100 remove 100 untill below or equal to 100
        var output = splitStringInt(input);
        var old = CurrentNumber;
        CurrentNumber = calcnewNumber(dail: CurrentNumber, input: output, isLeft: direction(input));
     if (CurrentNumber == 0)
     {
         clicks++;
         return;
     }
        if (CurrentNumber < minNumber)
        { do
            {
               if(old != 0){ clicks++;}
                CurrentNumber += 100;
                
            } while (CurrentNumber < minNumber);
            if (CurrentNumber == 0)
            {
                clicks++;
            }
        }
        if (CurrentNumber > maxNumber)
        {
            do
            {
                clicks++;
                CurrentNumber -= 100;
               
            } while (CurrentNumber >= 100);
           
        }
    }

    public int calcnewNumber(int dail, int input, bool isLeft)
    {
        //first I want  to check if we are left or not
        //Then I  want to the dail minus the input
        //Finally if we aren't left add input to the dail
        if (isLeft)
        {
           return dail - input;
        }
        return dail + input;
    }
    public int CalculateNewNumber(int currentNumber, int input, bool isLeft,bool isnewNumber = true)
    {
        int difference;
        int calculation;
        if (isLeft)
        {
            calculation = currentNumber - input;
            if (calculation < minNumber)
            {
               clicks++;
               if (currentNumber == minNumber)
               {
                   difference = (currentNumber +1) - input ;
               }
               else
               {
                   difference = input - (currentNumber +1);
               }

               var newNumber = checkNewNumber(difference, isLeft);
                return newNumber;
            }

            if (calculation != minNumber || calculation > minNumber && calculation < maxNumber) return calculation;
            if (currentNumber == minNumber)
            {
                return minNumber;
            }
            
        }
        calculation = currentNumber + input;
        if (calculation > maxNumber)
        {
            clicks++;
            difference = input- (maxNumber - currentNumber) -1   ;
            var newNumber = checkNewNumber(difference, isLeft);
            return newNumber;
        }

        if (calculation != maxNumber || calculation < maxNumber) return calculation;
        if(currentNumber == maxNumber ){ return maxNumber;}
      
       return calculation;
    }
    
    private int splitStringInt(string input) => int.Parse(input.Substring(1));
    
    
    private List<string> input = File.ReadAllLines("/home/kiana/Documents/Repo/Coding Projects/Advent-of-code-25/input.txt").ToList();

    public int checkNewNumber(int newNumber, bool isLeft)
    { int difference;
        if (newNumber == minNumber )
        {
            return newNumber;
        }
        if (newNumber > maxNumber)
        {
            return CalculateNewNumber(minNumber, newNumber, isLeft);
        }
        if (newNumber < minNumber)
        {
            newNumber *= -1;
            return CalculateNewNumber(maxNumber, newNumber, isLeft);
        } 
        return newNumber;
    }
}