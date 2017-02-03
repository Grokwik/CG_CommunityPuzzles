using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Solution
    {
        static bool IsPrimeNumber(int num)
        {
            int factor = num / 2;
            for (var i = 2; i <= factor; i++)
            {
                if ((num % i) == 0)
                    return false;
            }
            return true;
        }

        static public int GetSurface(int A, int B, int C)
        {
            return A * B * 2 + A * C * 2 + B * C * 2;
        }

        static public void Decompose(int val, ref Stack<int> decompo)
        {
            var cval = val;
            while (!IsPrimeNumber(cval))
            {
                for (var pn = 2; pn < cval; pn++)
                {
                    if (IsPrimeNumber(pn))
                    {
                        var tmp = (double)cval / pn;
                        if ((tmp - (int)tmp) == 0)
                        {
                            decompo.Push(pn);
                            cval = (int)tmp;
                            break;
                        }
                    }
                }
            }
            decompo.Push(cval);
        }

        static public int Max(int N)
        {
            return GetSurface(1, 1, N);
        }

        static public int Min1(int N)
        {
            var deco = new Stack<int>();
            Decompose(N, ref deco);
            var edges = new List<int>();
            var orderedEdges = from edge in edges
                               orderby edge
                               select edge;
            edges.Add((deco.Count != 0) ? deco.Pop() : 1);
            edges.Add((deco.Count != 0) ? deco.Pop() : 1);
            edges.Add((deco.Count != 0) ? deco.Pop() : 1);
            while (deco.Count > 0)
            {
                var e = orderedEdges.ElementAt(0);
                edges.Remove(e);
                e *= deco.Pop();
                edges.Add(e);
            }
            return GetSurface(edges[0], edges[1], edges[2]);
        }

        static public int Min2(int N)
        {
            var deco = new Stack<int>();
            Decompose(N, ref deco);

            var first = (deco.Count != 0) ? deco.Pop() : 1;
            var second = (deco.Count != 0) ? deco.Pop() : 1;
            var third = (deco.Count != 0) ? deco.Pop() : 1;

            if (deco.Count == 0)
                return GetSurface(first, second, third);

            while (deco.Count >= 3)
            {
                first *= deco.Pop();
                second *= deco.Pop();
                third *= deco.Pop();
            }
            third *= (deco.Count != 0) ? deco.Pop() : 1;
            second *= (deco.Count != 0) ? deco.Pop() : 1;
            return GetSurface(first, second, third);
        }

        static public int Min(int N)
        {
            return Math.Min(Min1(N), Min2(N));
        }

        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            Console.Error.WriteLine("Bricks count={0}", N); 
            Console.WriteLine("{0} {1}", Min(N), Max(N));
        }
    }
}