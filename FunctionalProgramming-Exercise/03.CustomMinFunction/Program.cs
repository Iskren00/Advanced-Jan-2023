using System;
using System.Linq;

Func<int[], int> minValue = i => i.Min();

int[] numbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

Console.WriteLine(minValue(numbers));