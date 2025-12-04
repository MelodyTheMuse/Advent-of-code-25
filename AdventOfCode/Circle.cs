using System.Runtime.InteropServices;

namespace AdventOfCode;

public class Circle
{
    private int CurrentNumber = 0;
    private int maxNumber = 99;
    private int minNumber = 0;
    private int clicks = 0;


    private bool direction(string input)
    {
        if (input.Contains("L"))
        {
            return true;
        }
        return false;
    }

    private void GetClick(string input)
    {
        var output = splitStringInt(input);
        CurrentNumber = CalculateNewNumber(currentNumber: CurrentNumber, input: output, direction: direction(input));
        Console.WriteLine(clicks);
    }
    private int CalculateNewNumber(int currentNumber, int input, bool direction)
    {
        int difference;
        if (direction)
        {
            if (currentNumber - input < minNumber)
            {
                difference =  input - currentNumber;
                CalculateNewNumber(maxNumber, difference, direction);
            }

            if (currentNumber - input != minNumber) return currentNumber - input;
            clicks++;
            return minNumber;
        }
        if (currentNumber +input > maxNumber)
        {
            difference = input - currentNumber;
            CalculateNewNumber(minNumber, difference, direction);
        }

        if (currentNumber - input != minNumber) return currentNumber + input;
        clicks++;
        return minNumber;
       
    }
    
    private int splitStringInt(string input) => int.Parse(input.Substring(1));
}