using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace TextAlignment
{
    /**
     * Auto-generated code below aims at helping you parse
     * the standard input according to the problem statement.
     **/
    class Solution
    {
        static string AlignLeft(string line)
        {
            return line;
        }

        static string AlignRight(string line)
        {
            return line;
        }

        static string Center(string line)
        {
            return line;
        }

        static string Justify(string line)
        {
            return line;
        }

        static string DoIt(string alignment, string line)
        {
            if (alignment == "LEFT")
                return AlignLeft(line);
            if (alignment == "RIGHT")
                return AlignRight(line);
            if (alignment == "CENTER")
                return Center(line);
            if (alignment == "JUSTIFY")
                return Justify(line);
            return line;
        }
        static void Main(string[] args)
        {
            string alignment = Console.ReadLine();
            int N = int.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)
            {
                string text = Console.ReadLine();
                Console.WriteLine(DoIt(alignment, text));
            }

//            Console.WriteLine("answer");
        }
    }
}