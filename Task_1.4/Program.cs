using System;
using System.Collections.Generic;

namespace Task_1._4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Name program: Check the parity of the brackets.");
            Console.WriteLine("Author's name: Halych Ivan.");
            Console.WriteLine("The user enters the expression containing the parentheses" +
                " - the program must check the correctness " +
                "of the expression (correct parentheses).");
            string input;
            while (true) 
            {
                Console.WriteLine("Enter line:");
                input = Console.ReadLine();
                if(input != "")
                {
                    if (input.Length >= 100)
                    {
                        Console.WriteLine("Input line must be less than 100");
                    }
                    else
                    {
                        break;
                    }
                }

            }
            List<char> array = new List<char>(input.ToCharArray());
            Stack<char> stack = new Stack<char>();
            List<(char, char)> arraubrackets = new List<(char, char)>();
            arraubrackets.Add(('<', '>'));
            arraubrackets.Add(('(', ')'));
            arraubrackets.Add(('[', ']'));
            arraubrackets.Add(('{', '}'));
            int i = 0;
            array.ForEach(item =>
            {
               
               var pair = arraubrackets.Find(p => p.Item1 == item || p.Item2 == item);
                if (pair.Item1 == item)
                {
                    stack.Push(item);
                }
                else if (pair.Item2 == item)
                {
                    if(stack.Count == 0)
                    {
                        ErrorBeginWrite(item, i, input);
                    }
                    else if(pair.Item1 == stack.Peek())
                    {
                        stack.Pop();
                    }
                    else
                    {
                        ErrorBeginWrite(item, i, input);
                    }
                }
                i++;
            });
            if(stack.Count != 0)
            {
                ErrorEndWrite(stack.Peek(),input.LastIndexOf(stack.Peek()), input);
            }
            Console.WriteLine("The string has not errors");
        }
        static void ErrorBeginWrite(char item, int position, string input)
        {
            Console.WriteLine($"{input} - error in position “{position}” - no opening parenthesis for \"{item}\".");
            Environment.Exit(0);
        }
        static void ErrorEndWrite(char item, int position, string input)
        {
            Console.WriteLine($"{input} - error in position “{position}” - bracket \"{item}\" has no closed pair");
            Environment.Exit(0);
        }


    }
}
