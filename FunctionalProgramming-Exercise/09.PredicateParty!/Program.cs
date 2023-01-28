using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

Predicate<string> predicate = null;

List<string> names = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .ToList();

string command;

while ((command = Console.ReadLine()) != "Party!")
{
    string[] cmdArg = command
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string cmdType = cmdArg[0];
    string value = cmdArg[2];

    if (cmdType == "Remove")
    {
        predicate = WhatToDo(cmdArg[1], value, predicate);

        names.RemoveAll(predicate);

    }
    else
    {
        predicate = WhatToDo(cmdArg[1], value, predicate);
        
        List<string> nameToAdd = names.FindAll(predicate);


        foreach (string name in nameToAdd)
        {
            int index = names.IndexOf(name);

            names.Insert(index, name);
        }
    }
}

if (names.Any())
{
    Console.WriteLine($"{string.Join(", ", names)} are going to the party!");
}
else
{
    Console.WriteLine("Nobody is going to the party!");
}


Predicate<string> WhatToDo(string command, string value, Predicate<string> predicate)
{
    switch (command)
    {
        case "StartsWith": return s => s.StartsWith(value);
        case "EndsWith": return s => s.EndsWith(value);
        case "Length": return s => s.Length == int.Parse(value);
        default:
            return null;
    }
}