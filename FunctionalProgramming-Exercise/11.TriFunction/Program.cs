using System;

Func<string[], int, bool> equalOrLarger = (names, n) =>
{
	bool isLarger = false;

	foreach (var name in names)
	{
		int sum = 0;

		foreach (var ch in name)
		{
			sum += (int)ch;
		}


		if (sum >= n)
		{
			Console.WriteLine(name);
			return true;
		}
	}

	return false;
};

int n = int.Parse(Console.ReadLine());

string[] names = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

equalOrLarger(names, n);