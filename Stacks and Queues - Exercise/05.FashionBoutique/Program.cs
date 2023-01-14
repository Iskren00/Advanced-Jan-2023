using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FashionBoutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> clothes = new Stack<int>(
                Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                );

            int capacityOfRack = int.Parse(Console.ReadLine());

            int currentCapacity = capacityOfRack;
            int rackCounter = 1;

            while (clothes.Any())
            {
                currentCapacity -= clothes.Peek();

                if (currentCapacity < 0)
                {
                    currentCapacity = capacityOfRack;
                    rackCounter++;
                }
                else
                {
                    clothes.Pop();
                }
            }

            Console.WriteLine(rackCounter);
        }
    }
}
