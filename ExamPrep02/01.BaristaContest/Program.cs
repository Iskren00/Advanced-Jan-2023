using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _01.BaristaContest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] coffeeQuantities = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] milkQuantities = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> coffee = new Queue<int>(coffeeQuantities);

            Stack<int> milk = new Stack<int>(milkQuantities);

            Dictionary<string, int> drinksQuantities = new Dictionary<string, int>();

            drinksQuantities.Add("Cortado", 50);
            drinksQuantities.Add("Espresso", 75);
            drinksQuantities.Add("Capuccino", 100);
            drinksQuantities.Add("Americano", 150);
            drinksQuantities.Add("Latte", 200);

            Dictionary<string, int> drinked = new Dictionary<string, int>();

            while (coffee.Count > 0 && milk.Count > 0)
            {
                int currCoffee = coffee.Peek();
                int currMilk = milk.Peek();

                int sum = currCoffee + currMilk;

                bool isEqual = false;

                foreach (var drink in drinksQuantities)
                {
                    if (drink.Value == sum)
                    {
                        coffee.Dequeue();
                        milk.Pop();

                        if (!drinked.ContainsKey(drink.Key))
                        {
                            drinked.Add(drink.Key, 0);

                        }

                        drinked[drink.Key]++;
                        isEqual = true;
                        
                        break;
                    }
                }

                if (!isEqual)
                {
                    coffee.Dequeue();
                    int coppy = milk.Pop() - 5;
                    milk.Push(coppy);
                }


            }

            if (coffee.Count == 0 && milk.Count == 0)
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
                Console.WriteLine("Coffee left: none");
                Console.WriteLine("Milk left: none");
            }
            else
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
                if (coffee.Count == 0)
                {
                    Console.WriteLine("Coffee left: none");
                }
                else
                {
                    Console.WriteLine($"Coffee left: {string.Join(", ", coffee)}");
                }

                if (milk.Count == 0)
                {
                    Console.WriteLine("Milk left: none");
                }
                else
                {
                    Console.WriteLine($"Milk left: {string.Join(", ", milk)}");
                }
            }

            drinked = drinked.OrderByDescending(c => c.Key).ToDictionary(c => c.Key, c => c.Value);
            drinked = drinked.OrderBy(c => c.Value).ToDictionary(c => c.Key, c => c.Value);

            foreach (var drink in drinked)
            {
                Console.WriteLine($"{drink.Key}: {drink.Value}");
            }

        }
    }
}
