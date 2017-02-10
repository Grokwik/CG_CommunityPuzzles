using System;
using System.Text;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Solution
{
    static Dictionary<int, char> D2R;
    static Dictionary<char, int> R2D;

    static int RomToDec(string rom)
    {
        var chars = rom.ToCharArray();
        var prev = R2D[chars[0]];
        var result = 0;
        int part = 0;
        foreach (var c in chars)
        {
            if (R2D[c] == prev)
                part += R2D[c];
            else
            {
                if (R2D[c] < prev)
                    result += part;
                else
                    result -= part;
                part = R2D[c];
            }
            prev = R2D[c];
        }
        result += part;
        Console.Error.WriteLine("rom = {0} => {1}", rom, result);
        return result;
    }

    static string DecToRomChunk(char min, char med, char max, int input)
    {
        if (input <= 0)
        {
            return "";
        }
        var output = new StringBuilder();
        if (input <= 3)
        {
            output.Append(min, input);
            return output.ToString();
        }
        if (input == 4)
        {
            output.Append(min, 1);
            output.Append(med, 1);
            return output.ToString();
        }
        if (input == 5)
        {
            output.Append(med, 1);
            return output.ToString();
        }
        if (input < 8)
        {
            output.Append(med, 1);
            output.Append(min, input - 5);
            return output.ToString();
        }
        if (input == 9)
        {
            output.Append(min, 1);
            output.Append(max, 1);
            return output.ToString();
        }
        return "";
    }

    static string DecToRom(int dec)
    {
        var output = "";
        if (dec / 1000 != 0)
        {
            var sb = new StringBuilder();
            sb.Append('M', dec / 1000);
            output += sb.ToString();
        }
        var chunkValue = dec / 1000;
        chunkValue = dec % 1000 / 100;
        output += DecToRomChunk('C', 'D', 'M', chunkValue);

        chunkValue = dec % 100 / 10;
        output += DecToRomChunk('X', 'L', 'C', chunkValue);

        chunkValue = dec % 10;
        output += DecToRomChunk('I', 'V', 'X', chunkValue);
        return output;
    }

    static void Init()
    {
        R2D = new Dictionary<char, int>();
        R2D['I'] = 1;
        R2D['V'] = 5;
        R2D['X'] = 10;
        R2D['L'] = 50;
        R2D['C'] = 100;
        R2D['D'] = 500;
        R2D['M'] = 1000;

        D2R = new Dictionary<int, char>();
        D2R[1] = 'I';
        D2R[5] = 'V';
        D2R[10] = 'V';
        D2R[50] = 'L';
        D2R[100] = 'C';
        D2R[500] = 'D';
        D2R[1000] = 'M';
    }

    static string DoIt(string rom1, string rom2)
    {
        Init();
        var num1 = RomToDec(rom1);
        var num2 = RomToDec(rom2);
        return DecToRom(num1 + num2);
    }

    static void Main(string[] args)
    {
        string rom1 = Console.ReadLine();
        string rom2 = Console.ReadLine();
        Console.WriteLine(DoIt(rom1, rom2));
    }
}