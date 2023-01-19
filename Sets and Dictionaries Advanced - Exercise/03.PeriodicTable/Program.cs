using System;
using System.Collections.Generic;

SortedSet<string> set = new();

int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
	string[] input = Console.ReadLine()
		.Split(' ', StringSplitOptions.RemoveEmptyEntries);

	for (int j = 0; j < input.Length; j++)
	{
		set.Add(input[j]);
	}
}

Console.WriteLine(string.Join(' ', set));