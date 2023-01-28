
using System;
using System.Reflection;

string title = "Sir";
string[] names = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

Action<string[], string> print = (n, s) =>
{
	foreach (var name in names)
	{
	Console.WriteLine($"{title} {name}");
	}
};

print(names, title);