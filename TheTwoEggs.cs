using System;

namespace TheTwoEggs
{
    public class Solution
    {
        public static int MinTries(int NbFloors)
        {
            var tries = 1;
            while (true)
            {
                if (tries * (tries + 1) / 2 >= NbFloors)
                {
                    return (tries);
                }
                tries++;
            }
        }
    }
}