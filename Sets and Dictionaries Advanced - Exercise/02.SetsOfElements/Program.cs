using System;
using System.Collections.Generic;
using System.Linq;

int[] elements = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

HashSet<int> firstSet = new();
HashSet<int> secondSet = new();

for (int i = 0; i < elements[0]; i++)
{
    firstSet.Add(int.Parse(Console.ReadLine()));
}

for (int i = 0; i < elements[1]; i++)
{
    secondSet.Add(int.Parse(Console.ReadLine()));
}

firstSet.IntersectWith(secondSet);

Console.WriteLine(String.Join(' ', firstSet));