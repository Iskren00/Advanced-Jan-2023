using System;
using System.Collections.Generic;
using System.Linq;

Action<int, List<string>> function = (lenght, names) =>
{

    foreach (var name in names)
    {
        if (name.Length <= lenght)
        {
            Console.WriteLine(name);
        }
    }
};

int lenght = int.Parse(Console.ReadLine());

List<string> names = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .ToList();

function(lenght, names);