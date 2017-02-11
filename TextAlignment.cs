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
            return line.Trim();
        }

        static string AlignRight(string line, int lineSize)
        {
            var output = new StringBuilder();
            if (lineSize != line.Length)
                output.Append(' ', lineSize - line.Length);
            output.Append(line);
            return output.ToString();
        }

        static string Center(string line, int lineSize)
        {
            var output = new StringBuilder();
            if (lineSize != line.Length)
                output.Append(' ', (lineSize - line.Length) / 2);
            output.Append(line);
            return output.ToString();
        }

        static string Justify(string line, int lineSize)
        {
            var output = new StringBuilder();
            var spaceCount = 0;
            var words = line.Split(' ');
            if (lineSize != line.Length)
                spaceCount = lineSize - (line.Length - words.Length -1);
            else
                return line;
            spaceCount = spaceCount / (words.Length-1);
            foreach (var w in words)
            {
                output.Append(w);
                output.Append(' ', spaceCount);
            }
            return output.ToString().Trim();
        }

        static string DoIt(string alignment, string line, int lineSize)
        {
            switch(alignment)
            {
                case "LEFT": return AlignLeft(line);
                case "RIGHT": return AlignRight(line, lineSize);
                case "CENTER": return Center(line, lineSize);
                case "JUSTIFY": return Justify(line, lineSize);
            }
            return line;
        }

        static void Main(string[] args)
        {
            string alignment = Console.ReadLine();
            int N = int.Parse(Console.ReadLine());
            var lines = new List<string>();
            var maxLineSize = 0;
            for (int i = 0; i < N; i++)
            {
                var line = Console.ReadLine();
                lines.Add(line);
                maxLineSize = (line.Length > maxLineSize) ? line.Length : maxLineSize;
            }

            foreach (var line in lines)
            {
                Console.WriteLine(DoIt(alignment, line, maxLineSize));
            }
        }
    }
}