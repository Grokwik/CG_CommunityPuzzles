using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

class Solution
{
    static int T;       // Current time
    static int P;       // Player count
    static int StartTime;

    static int TimeToSeconds(string timeStamp)
    {
        var minutes = int.Parse(timeStamp.Substring(0, 1));
        var seconds = int.Parse(timeStamp.Substring(2));
        return minutes * 60 + seconds;
    }

    static string SecondsToTime(int time)
    {
        var minutes = (int)time / 60;
        var seconds = time - (minutes * 60);
        return string.Format("{0}:{1:00}", minutes, seconds);
    }

    static double GetNewTime()
    {
        var result = (T - 256 / (Math.Pow(2, P - 1)));
        return (result > 0) ? (T - 256 / (Math.Pow(2, P - 1))) : 0;
    }

    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        P = 1;
        StartTime = 0;
        for (int i = 0; i < n; i++)
        {
            string timeStamp = Console.ReadLine();
            T = TimeToSeconds(timeStamp);
            Console.Error.WriteLine("..... game start {0} (={1})", StartTime, SecondsToTime(StartTime));
            if (T < StartTime)
                break;
            StartTime = (int)GetNewTime();
            P++;
            if (P == 8)
                StartTime = T;
        }

        if (P == 1)
            Console.WriteLine("NO GAME");
        else
        {
            if (P > 8)
                Console.WriteLine("0:00");
            else
                Console.WriteLine("{0}", SecondsToTime(StartTime));
        }
    }
}