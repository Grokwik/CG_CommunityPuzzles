/*
Objectif
Find the safe combination. The only thing you find lying next to the safe is a note with a message that looks like gibberish.
Oh yeah, if you try to open the safe with the wrong combination, all your files on your computer will be deleted! (not really)
Good luck!

Entrée
Line 1:An encrypted message.

Sortie
A single line containing the decrypted safe combination in numeral format.

Exemple
Entrée
Aol zhml jvtipuhapvu pz: zpe-mvby-zpe-mvby-aoyll
Sortie
64643
*/

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
class Solution
{
    static Dictionary<char, char> Alphabet;
    
    static void FillAlphabet(string input)
    {
        Alphabet = new Dictionary<char, char>();
//                1         2 
//      0    5    0    5    0  2 
//      Aol zhml jvtipuhapvu pz: zpe-mvby-zpe-mvby-aoyll
//      The safe combination is

        var chars = input.ToCharArray();
        Alphabet.Add(chars[5], 'A');
        Alphabet.Add(chars[12], 'B');
        Alphabet.Add(chars[9], 'C');
        Alphabet.Add(chars[2], 'E');
        Alphabet.Add(chars[6], 'F');
        Alphabet.Add(chars[1], 'H');
        Alphabet.Add(chars[13], 'I');
        Alphabet.Add(chars[11], 'M');
        Alphabet.Add(chars[14], 'N');
        Alphabet.Add(chars[10], 'O');
        Alphabet.Add(chars[4], 'S');
        Alphabet.Add(chars[0], 'T');
    }
    
    static string ConvertMsg(string input)
    {
        var output = input;
        foreach(var letter in Alphabet)
        {
            output = output.Replace(letter.Key, letter.Value);
        }
        for (var i=0 ; i<output.Length ; i++)
        {
            if (char.IsLower(output[i]))
                output = output.Replace(output[i], '*');
        }
        return output;
    }
    
    static string GetCode(string input)
    {
        var strDigits = input.Substring(25).Split('-');
        var digits = new StringBuilder();
        for(var i=0 ; i<strDigits.Length ; i++)
        {
            switch(strDigits[i])
            {
                case "*E*O":
                    digits.Append("0");
                    break;
                case "ONE":
                    digits.Append("1");
                    break;
                case "T*O":
                    digits.Append("2");
                    break;
                case "TH*EE":
                    digits.Append("3");
                    break;
                case "FO**":
                    digits.Append("4");
                    break;
                case "FI*E":
                    digits.Append("5");
                    break;
                case "SI*":
                    digits.Append("6");
                    break;
                case "SE*EN":    
                    digits.Append("7");
                    break;
                case "EI*HT":
                    digits.Append("8");
                    break;
                case "NINE":
                    digits.Append("9");
                    break;
            }
        }
        return digits.ToString();
    }

    static void Main(string[] args)
    {
        var msg = Console.ReadLine().ToLower();

        FillAlphabet(msg);
        msg = ConvertMsg(msg);
        Console.WriteLine(GetCode(msg));
    }
}
