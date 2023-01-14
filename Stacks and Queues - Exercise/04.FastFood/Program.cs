using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FastFood
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());

            Queue<int> queue = new Queue<int>(
                Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                );

            Console.WriteLine(queue.Max());

            while (queue.Any())
            {
                quantity -= queue.Peek();

                if (quantity < 0)
                {
                    break;
                }
                else
                {
                    queue.Dequeue();
                }


            }

            if (!queue.Any())
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ", queue)}");
            }
        }
    }
}
