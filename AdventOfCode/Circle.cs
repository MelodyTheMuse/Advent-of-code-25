using System.Runtime.InteropServices;

namespace AdventOfCode;

public class Circle
{
    public static Circle _Instance;
    private int maxNumber = 99;
    private int minNumber = 0;
    private int steps = 0;
    private bool isNewNumber = false;
    public static int clickers;
    private string docPath = "output.txt";


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
        List<string> lines = new List<string>();
        StreamWriter sw = File.CreateText(docPath);
        int CurrentNumber = 50;
        int clicks = 0;
        foreach (var item in input)
        {
            isNewNumber = true;
            clicks = getClickers(item, clicks,CurrentNumber,out CurrentNumber);
            steps++;
            Console.WriteLine(clicks + " clicks");
            Console.WriteLine(steps + " steps");
            Console.WriteLine(CurrentNumber + " current number");
            string[] line = { $"{clicks} clicks", $"{steps} steps", $"{CurrentNumber} dial" };
           
        }
        using (sw)
        {
            foreach (var line in lines)
            {
                sw.WriteLine(line);
            }
           
        }
        
        return clicks;

    }
    
    public int RunFromParameter(List<string> input)
    {
        
        List<string> lines = new List<string>();
        StreamWriter sw = File.CreateText(docPath);
        int CurrentNumber = 50;
        int clicks = 0;
        foreach (var item in input)
        {
            isNewNumber = true;
            clicks = getClickers(item, clicks,CurrentNumber,out CurrentNumber);
            steps++;
            Console.WriteLine(clicks + " clicks");
            Console.WriteLine(steps + " steps");
            Console.WriteLine(CurrentNumber + " current number");
            string line = $"{clicks} clicks {steps} steps {CurrentNumber} dial {item} Input";
            lines.Add(line);
          
        }
        using (sw)
        {
            foreach (var line in lines)
            {
                sw.WriteLine(line);
            }
           
        }
        return clicks;

    }

  //  private void GetClick(string input)
 //   {
   //     var output = splitStringInt(input);
 //       CurrentNumber = CalculateNewNumber(currentNumber: CurrentNumber, input: output, isLeft: direction(input));
  //      if (CurrentNumber == 0)
  //      {
   //         clicks++;
   //     }
   //     string sAppPath = Environment.CurrentDirectory;
  //     Console.WriteLine(sAppPath);
 //   }

 public int getClickers(string input,  int clicks,int CurrentNumber, out int  outputNumber)
 {
     var output = splitStringInt(input);
     var old = CurrentNumber;
     int x = 0;
     CurrentNumber = calcnewNumber(dail: CurrentNumber, input: output, isLeft: direction(input));
     x = CurrentNumber / 100;
     x = Math.Abs(x);
     
     int y = CurrentNumber % 100;
     if ( y < 0)
     {
         y += 100;
     }

     if (old > 0 && CurrentNumber <= 0)
     {
         x++;
     }
     clicks += x;
     outputNumber = y;
     return clicks;
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
             //  clicks++;
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
            //clicks++;
            difference = input- (maxNumber - currentNumber) -1   ;
            var newNumber = checkNewNumber(difference, isLeft);
            return newNumber;
        }

        if (calculation != maxNumber || calculation < maxNumber) return calculation;
        if(currentNumber == maxNumber ){ return maxNumber;}
      
       return calculation;
    }
    
    private int splitStringInt(string input) => int.Parse(input.Substring(1));
    
    
    private List<string> input = File.ReadAllLines("input.txt").ToList();

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