using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Basic_Stack_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int n = input[0];
            int s = input[1];
            int x = input[2];

            Queue<int> stack = new Queue<int>();

            int[] ints = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < n; i++)
            {
                stack.Enqueue(ints[i]);
            }

            for (int i = 0; i < s; i++)
            {
                if (stack.Any())
                {
                    stack.Dequeue();
                }

            }

            if (stack.Contains(x))
            {
                Console.WriteLine("true");
            }
            else if (!stack.Contains(x) && stack.Any())
            {
                Console.WriteLine(stack.Min());
            }
            else if (!stack.Any())
            {
                Console.WriteLine("0");
            }
        }
    }
}
