using System;
using System.Linq;
using System.Collections.Generic;

namespace MagicStones
{
    public class Solution
    {
        static Dictionary<int, int> Stones;
        public static int WorkYourMagic(int N, string input)
        {
            Stones = new Dictionary<int, int>();
            string[] inputs = input.Split(' ');
            for (int i = 0; i < N; i++)
            {
                int level = int.Parse(inputs[i]);
                if (Stones.ContainsKey(level))
                    Stones[level]++;
                else
                    Stones.Add(level, 1);
            }

            var count = 0;
            var OStones = Stones.OrderBy(st => st.Key);
            var stone = OStones.FirstOrDefault();
            while (stone.Key != 0)
            {
                Console.Error.WriteLine("Value: {0} Count: {1}", stone.Key, stone.Value);
                var created = stone.Value / 2;
                count += stone.Value % 2;
                if (created != 0)
                {
                    if (Stones.ContainsKey(stone.Key + 1))
                        Stones[stone.Key + 1] += created;
                    else
                        Stones.Add(stone.Key + 1, created);
                }
                Stones.Remove(stone.Key);
                OStones = Stones.OrderBy(st => st.Key);
                stone = OStones.FirstOrDefault();
            }
            return count;
        }
    }
}