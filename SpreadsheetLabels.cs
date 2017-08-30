using System;
using System.IO;
using System.Text;

class Solution
{
    static char[] Conv;
    static int Base;

    static long XlsToDec(string input)
    {
        long output = 0;
        for(var i=0 ; i<input.Length ; i++)
        {
            long multiplier = (long)Math.Pow(Base, input.Length-1-i);
            long letterEquivalent = ((long)input[i])-64L;
            output += multiplier * letterEquivalent;
        }
        Console.Error.WriteLine("{0} = {1}", input, output);
        return output;
    }

    static string DecToXls(long input)
    {
        Console.Error.WriteLine("Converting {0}...", input);
        var output = "";
        long remainder;
        while (input != 0)
        {
            if (input == 1)
            {
                output = Conv[0] + output;
                break;
            }
            input -= 1;
            remainder = input % Base;
            output = Conv[remainder] + output;
            input = (long)input / Base;
        }
        Console.Error.WriteLine("--> {0}", output);
        return output;
    }

    static void Main(string[] args)
    {
        #region init & inputs
        Base = 26;
        Conv = new char[26] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        var n = int.Parse(Console.ReadLine());
        var inputs = Console.ReadLine().Split(' ');
        var output = "";
        #endregion

        for (var i=0 ; i<n; i++)
        {
            string label;
            try
            {
                var input = Int64.Parse(inputs[i]);
                label = DecToXls(input);
            }
            catch (FormatException)
            {
                label = XlsToDec(inputs[i]).ToString();
            }
            output += label + " ";
        }
        Console.WriteLine(output.TrimEnd());
    }
}
