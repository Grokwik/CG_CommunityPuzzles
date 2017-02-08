namespace IlsSontFousCesRomains
{
    using System;
    using System.Linq;
    using System.IO;
    using System.Text;
    using System.Collections;
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
//                Console.Error.WriteLine("rom digit {0} = {1}", c, R2D[c]);
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

        static string DecToRom(int dec)
        {
            Console.Error.WriteLine("dec = {0}", dec);
            return "";
        }

        static string DoIt(string rom1, string rom2)
        {
            R2D = new Dictionary<char, int>();
            R2D['I'] = 1;
            R2D['V'] = 5;
            R2D['X'] = 10;
            R2D['L'] = 50;
            R2D['C'] = 100;
            R2D['D'] = 500;

            D2R = new Dictionary<int, char>();
            D2R[1] = 'I';
            D2R[5] = 'V';
            D2R[10] = 'V';
            D2R[50] = 'L';
            D2R[100] = 'C';
            D2R[500] = 'D';

            var num1 = RomToDec(rom1);
            var num2 = RomToDec(rom2);
            return DecToRom(num1 + num2);
        }
    }
}