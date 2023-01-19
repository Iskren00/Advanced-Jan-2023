using System;
using System.Collections.Generic;

int n = int.Parse(Console.ReadLine());

HashSet<string> set = new();

for (int i = 0; i < n; i++)
{
    string input = Console.ReadLine();

    set.Add(input);
}

foreach (var item in set)
{
    Console.WriteLine(item);
}