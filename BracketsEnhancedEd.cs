using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketsEnhancedEd
{
    public class Solution
    {
        static Stack<char> Possible;

        public static string CleanUp(string str)
        {
            string output = "";
            foreach (var c in str)
            {
                switch (c)
                {
                    case '(':
                    case ')':
                        output += "a";
                        break;
                    case '[':
                    case ']':
                        output += "b";
                        break;
                    case '{':
                    case '}':
                        output += "c";
                        break;
                    case '<':
                    case '>':
                        output += "d";
                        break;
                }
            }
            return output;
        }

        public static bool DoIt(string expression)
        {
            if (expression == null || expression == "")
                return true;
            var str = CleanUp(expression);

            var idx = 0;
            Possible = new Stack<char>();
            while(idx < str.Length)
            {
                if (Possible.Count != 0 && Possible.Peek() == str[idx])
                    Possible.Pop();
                else
                    Possible.Push(str[idx]);
                idx++;
            }
            return (Possible.Count == 0);
        }
    }
}