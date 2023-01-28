using System;
using System.Collections.Generic;
using System.Linq;

Func<int, List<int>, List<int>> function = (divisible, list) =>
{
    List<int> numbers = new();

	foreach (var number in list)
	{
		if (number % divisible != 0)
		{
            numbers.Add(number);
        }
	}

	return numbers;
};

List<int> numbers = Console.ReadLine()
	.Split(" ", StringSplitOptions.RemoveEmptyEntries)
	.Select(int.Parse)
	.ToList();

int divisible = int.Parse(Console.ReadLine());

numbers = function(divisible, numbers);

List<int> result = new();

for (int i = numbers.Count - 1; i >= 0; i--)
{
	result.Add(numbers[i]);
}

Console.WriteLine(string.Join(" ", result));