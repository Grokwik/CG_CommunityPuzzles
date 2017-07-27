using System;
using System.Collections;

/**
Objectif

The task is to write an interpreter for a very simplistic assembly language and print the four register values after the instructions have been processed.

Explanations:
a, b, c, d: registers containing integer values
DEST: write the operation result to this register
SRC: read operand value from this register
IMM: immediate/integer value
SRC|IMM means that the operand can be either a register or an immediate value.

Command and operands are always separated by a blank.
The program starts with the first instruction, iterates through all instructions and ends when the last instruction was processed.
Only valid input is given and there are no endless loops or over-/underflows to be taken care of.

List of defined assembly instructions:

MOV DEST SRC|IMM
copies register or immediate value to destination register
Example: MOV a 3 => a = 3

ADD DEST SRC|IMM SRC|IMM
add two register or immediate values and store the sum in destination register
Example: ADD b c d => b = c + d

SUB DEST SRC|IMM SRC|IMM
subtracts the third value from the second and stores the result in destination register
Example: SUB d d 2 => d = d - 2

JNE IMM SRC SRC|IMM
jumps to instruction number IMM (zero-based) if the other two values are not equal
Example: JNE 0 a 0 => continue execution at line 0 if a is not zero

Full example:
(line 0) MOV a 3      # a = 3
(line 1) ADD a a -1   # a = a + (-1)
(line 2) JNE 1 a 1    # jump to line 1 if a != 1
Program execution:
0: a = 3
1: a = a + (-1) = 3 + (-1) = 2
2: a != 1 -> jump to line 1
1: a = a + (-1) = 2 + (-1) = 1
2: a == 1 -> don't jump

Program finished, register a now contains value 1
Entrée
Line 1 contains the blank-separated values for the registers a, b, c, d
Line 2 contains the number n of the following instruction lines
n lines containing assembly instructions
Sortie
Line with the four blank-separated register values of a, b, c, d
Contraintes
0 < n < 16
-2^15 ≤ a, b, c, d < 2^15
Overflow and underflow behavior is unspecified (and not tested).
Exemple
Entrée
1 2 3 -4
2
MOV b 3
MOV c a
Sortie
1 3 1 -4
 **/
class Solution
{
    static Hashtable Registers;
    static String[] Instructions;
    static int Cursor;
    
    static void MOV(char reg, string value)
    {
        int ivalue;
        try
        {
            ivalue = Int32.Parse(value);
        }
        catch (FormatException)
        {
            ivalue = (int)Registers[value[0]];
        }
        Registers[reg] = ivalue;
        Cursor++;
    }

    static void ADD(char reg, string value1, string value2)
    {
        int ivalue1, ivalue2;
        try
        {
            ivalue1 = Int32.Parse(value1);
        }
        catch (FormatException)
        {
            ivalue1 = (int)Registers[value1[0]];
        }
        try
        {
            ivalue2 = Int32.Parse(value2);
        }
        catch (FormatException)
        {
            ivalue2 = (int)Registers[value2[0]];
        }
        Registers[reg] = ivalue1+ivalue2;
        Cursor++;
    }

    static void SUB(char reg, string value1, string value2)
    {
        int ivalue1, ivalue2;
        try
        {
            ivalue1 = Int32.Parse(value1);
        }
        catch (FormatException)
        {
            ivalue1 = (int)Registers[value1[0]];
        }
        try
        {
            ivalue2 = Int32.Parse(value2);
        }
        catch (FormatException)
        {
            ivalue2 = (int)Registers[value2[0]];
        }
        Registers[reg] = ivalue1-ivalue2;
        Cursor++;
    }

    static void JNE(int line, char reg1, string value2)
    {
        int ivalue2;
        try
        {
            ivalue2 = Int32.Parse(value2);
        }
        catch (FormatException)
        {
            ivalue2 = (int)Registers[value2[0]];
        }

        if (ivalue2 == (int)Registers[reg1])
        {
            Cursor++;
        }
        else
        {
            Cursor = line;
        }
    }

    static void InterpretLine(int line)
    {
        string[] operand = Instructions[line].Split();
        Console.Error.WriteLine("{0}", Instructions[line]);
        if (operand[0] == "MOV")
        {
            MOV(operand[1][0], operand[2]);
        }
        else if (operand[0] == "ADD")
        {
            ADD(operand[1][0], operand[2], operand[3]);
        }
        else if (operand[0] == "SUB")
        {
            SUB(operand[1][0], operand[2], operand[3]);
        }
        else if (operand[0] == "JNE")
        {
            JNE(int.Parse(operand[1]), operand[2][0], operand[3]);
        }
    }

    static void Main(string[] args)
    {
        string[] inputs = Console.ReadLine().Split(' ');
        Cursor = 0;
        Registers = new Hashtable();
        Registers['a'] = int.Parse(inputs[0]);
        Registers['b'] = int.Parse(inputs[1]);
        Registers['c'] = int.Parse(inputs[2]);
        Registers['d'] = int.Parse(inputs[3]);

        int n = int.Parse(Console.ReadLine());
        Instructions = new String[n];

        for (int i = 0; i < n; i++)
        {
            Instructions[i] = Console.ReadLine();
        }

        while (Cursor < n)
        {
            InterpretLine(Cursor);
        }
        Console.WriteLine("{0} {1} {2} {3}", Registers['a'], Registers['b'], Registers['c'], Registers['d']);
    }
}
