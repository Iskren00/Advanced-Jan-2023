using System;

Action<string[]> print = n => Console.WriteLine(string.Join(Environment.NewLine, n));

string[] names = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

print(names);