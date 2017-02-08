namespace CardsCasttle
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
    public class Solution
    {
        public static List<string> Casttle;
        public static int _H;

        static void EchoCasttle()
        {
            foreach (var l in Casttle)
            {
                Console.Error.WriteLine(l);
            }
        }

        public static bool IsCardStable(int line, int col)
        {
            var cCard = Casttle[line][col];

            if (cCard == '.')
                return true;

            if (cCard == '/')
            {
                if (col == _H * 2 - 1)
                    return false;
                if (Casttle[line][col + 1] != '\\')
                    return false;
                if (line != _H - 1 && Casttle[line + 1][col] != '\\')
                    return false;
            }
            else/*  card == '\'   */
            {
                if ((col == 0)
                  || (Casttle[line][col - 1] != '/')
                  || (line != _H - 1 && Casttle[line + 1][col] != '/'))
                    return false;
            }
            return true;
        }

        public static string DoIt()
        {
            for (var l = 0; l < _H; l++)
                for (var c = 0; c < _H * 2; c++)
                    if (!IsCardStable(l, c))
                    {
                        Console.Error.WriteLine("Unstable: {0} {1}", l, c);
                        return "UNSTABLE";
                    }

            return "STABLE";
        }

        static string StableOrNot(int h, string[] level)
        {
            _H = h;
            Casttle = new List<string>();
            for (int i = 0; i < _H; i++)
            {
                Casttle.Add(level[i]);
            }
            EchoCasttle();
            return DoIt();
        }
    }
}