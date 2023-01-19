using System;
using System.Collections.Generic;

int n = int.Parse(Console.ReadLine());

Dictionary<int, int> numbers = new();

for (int i = 0; i < n; i++)
{
    int input = int.Parse(Console.ReadLine());

	if (!numbers.ContainsKey(input))
	{
		numbers.Add(input, 0);
	}

	numbers[input]++;
}

foreach (var item in numbers)
{
	if (item.Value % 2 == 0)
	{
		Console.WriteLine(item.Key);

		return;
	}
}