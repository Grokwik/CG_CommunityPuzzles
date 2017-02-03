using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Solution
    {
        static public long SumOfDiv(int n)
        {
            var sum = 0L;
            for (var i = 1; i <= n; i++)
            {
                sum += i * (int)(n / i);
            }
            return sum;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Which number ?");
            var input = int.Parse(Console.ReadLine());
            Console.WriteLine("Solution:{0}", SumOfDiv(input));
        }
    }
}