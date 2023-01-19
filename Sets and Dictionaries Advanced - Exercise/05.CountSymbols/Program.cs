using System;
using System.Collections.Generic;

string text = Console.ReadLine();

SortedDictionary<char, int> chCount = new();

foreach (char ch in text)
{
	if (!chCount.ContainsKey(ch))
	{
		chCount.Add(ch, 0);
	}

	chCount[ch]++;
}

foreach (var ch in chCount)
{
	Console.WriteLine($"{ch.Key}: {ch.Value} time/s");
}
