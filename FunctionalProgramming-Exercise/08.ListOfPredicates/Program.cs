using System;
using System.Collections.Generic;
using System.Linq;

Action<List<Predicate<int>>, List<int>> action = (predicates, numbers) =>
{
    foreach (var number in numbers)
    {
        int count = 0;

        foreach (var predicate in predicates)
        {
            if (predicate(number))
            {
                count++;
            }
            else
            {
                break;
            }

            if (count == predicates.Count)
            {
                Console.Write(number + " ");
            }
        }
    }
};

int endOfRange = int.Parse(Console.ReadLine());

List<int> numbers = new();

for (int i = 0; i < endOfRange; i++)
{
    numbers.Add(i + 1);
}

HashSet<int> dividers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToHashSet();

List<Predicate<int>> predicates = new();

foreach (int i in dividers)
{
    predicates.Add(n => n % i == 0);
}

action(predicates, numbers);