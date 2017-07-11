/*
** Objectif

Your program must decode the encoded message from the Chuck Norris encoding project.

It is strongly recommended to have done the Chuck Norris project. 
Link -> https://www.codingame.com/training/easy/chuck-norris

Here are some reminders about the Chuck Norris encoding method:
- The encoded message is unary, containing only sequences of zeroes separated by spaces.
- These sequences of zeroes always come in pairs.
- The first sequence of a pair can be either 0 or 00, which represent the binary bits 1 and 0 respectively.
- The second sequence of a pair is made of k zeroes, where k is the number of time the previous bit has to be printed in order to decode the message.

For instance, if we want to encode the character A, we first start to write down the 7-bit ASCII code for A which is 1000001 in binary. (We only use 7 bits because the first bit is always zero so it's ignored).
Then we turn the binary into unary as follows:
1000001 -> 0 0 (bit 1, one time)
1000001 -> 00 00000 (bit 0, five times)
1000001 -> 0 0 (bit 1, one time)
Therefore, the encoded message is 0 0 00 00000 0 0.

You are asked to do the reverse process, and thus print A when given the message 0 0 00 00000 0 0.
If the input is invalid, just print INVALID.

** Entrée
Line 1: The encoded message of N characters.

** Sortie
Line 1: The decoded message, or the word INVALID when the input is not valid.

** Contraintes
0 < N < 4096

** Exemple
Entrée : 0 0 00 00000 0 0
Sortie : A
*/

using System;
using System.Text;

class Solution
{
    static string EncToBinary(string bruceLeedValue)
    {
        var chunks = bruceLeedValue.Split(' ');
        var bit = 'X';

        var output = new StringBuilder();
        foreach (var chunk in chunks)
        {
            //  chunk defining the bit value
            if ('X' == bit)
            {
                if (chunk.Length > 2)
                    return "INVALID";
                bit = (chunk.Length == 2) ? '0' : '1';
                continue;
            }

            //  chunk defining the bit count
            output.Append(bit, chunk.Length);
            //Console.Error.WriteLine("bit {0}, {1} times", bit, chunk.Length);
            bit = 'X';
        }
        return output.ToString();
    }

    static char BinToChar(string binaryValue)
    {
        Console.Error.WriteLine("{0}", binaryValue);
        var pow = 6;
        var tgt = 0D;
        for(var i=0 ; i<7 ; i++)
        {
            if ('1' == binaryValue[i])
                tgt += Math.Pow(2, pow);
            pow--;
        }
        return (char)tgt;
    }

    static void Main(string[] args)
    {
        var ENCRYPT = Console.ReadLine();
        var binaryExpr = EncToBinary(ENCRYPT);

        if (("INVALID" == binaryExpr)
         || (0 != binaryExpr.Length%7))
        {
            Console.WriteLine("INVALID");
            return;
        }

        Console.Error.WriteLine("There are {0} characters", binaryExpr.Length/7);
        var output = new StringBuilder();
        for (var i=0 ; i<binaryExpr.Length/7 ; i++)
        {
            output.Append(BinToChar(binaryExpr.Substring(7*i, 7)));
        }
        Console.WriteLine("{0}", output.ToString());
    }
}
