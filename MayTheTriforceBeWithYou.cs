using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Solution
    {
        public static string GetTriforceLine(int lineIdx, int size)
        {
            var strbuild = new StringBuilder();
            strbuild.Append(' ', lineIdx - 1);
            strbuild.Append('*', 2 * (size - lineIdx) + 1);
            return strbuild.ToString();
        }
        public static string DisplayTriforce(int size)
        {
            var strbuild = new StringBuilder();
            for (var line = size; line > 0; line--)
            {
                strbuild.Append(' ', size);
                strbuild.Append(' ', line - 1);
                strbuild.Append('*', 2 * (size - line) + 1);
                strbuild.Append('\n', 1);
            }
            var offsetSize = size;
            for (var line = size; line > 0; line--)
            {
                strbuild.Append(' ', line - 1);
                strbuild.Append('*', 2 * (size - line) + 1);
                strbuild.Append(' ', offsetSize);
                strbuild.Append(' ', line - 1);
                strbuild.Append('*', 2 * (size - line) + 1);
                strbuild.Append('\n', 1);
                offsetSize--;
            }
            var output = "." + strbuild.ToString().Substring(1);
            output = output.Substring(0, output.Length-1);
            return output;
        }

        static void Main(string[] args)
        {
            var input = int.Parse(Console.ReadLine());
            Console.WriteLine(DisplayTriforce(input));
        }
    }
}