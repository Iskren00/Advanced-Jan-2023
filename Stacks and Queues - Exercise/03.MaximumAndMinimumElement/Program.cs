using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MaximumAndMinimumElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                int[] cmdArg = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int cmdType = cmdArg[0];

                switch (cmdType)
                {
                    case 1:
                        int element = cmdArg[1];
                        stack.Push(element);
                        break;
                    case 2:
                        if (stack.Any())
                        {
                        stack.Pop();
                        }
                        break;
                    case 3:
                        if (stack.Any())
                        {
                            Console.WriteLine(stack.Max());
                        }
                        break;
                    case 4:
                        if (stack.Any())
                        {
                            Console.WriteLine(stack.Min());
                        }
                        break;
                }
            }
            if (stack.Any())
            {
            Console.WriteLine(string.Join(", ", stack));

            }
        }
    }
}
