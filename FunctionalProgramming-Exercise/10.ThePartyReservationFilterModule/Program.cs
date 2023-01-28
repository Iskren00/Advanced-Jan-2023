using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

Dictionary<string, Predicate<string>> keyValuePairs = new();

List<string> names = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .ToList();

string command;

while ((command = Console.ReadLine()) != "Print")
{
    Predicate<string> predicate = null;
    string[] cmdArg = command
        .Split(";", StringSplitOptions.RemoveEmptyEntries);

    string cmdType = cmdArg[0];
    string cmd = cmdArg[1];
    string value = cmdArg[2];

    if (cmdType == "Add filter")
    {
        keyValuePairs.Add(cmd + value, WhatToDo(cmdArg[1], value, predicate));     
    }
    else
    {
        keyValuePairs.Remove(cmd + value);
    }
}

List<string> result = new(names);


foreach (var name in names)
{
    foreach (var item in keyValuePairs)
    {
        if (item.Value(name))
        {
            result.Remove(name);
        }
    }
}

Console.WriteLine(string.Join(" ", result));

Predicate<string> WhatToDo(string command, string value, Predicate<string> predicate)
{
    switch (command)
    {
        case "Starts with": return s => s.StartsWith(value);
        case "Ends with": return s => s.EndsWith(value);
        case "Length": return s => s.Length == int.Parse(value);
        case "Contains": return s => s.Contains(value);
        default:
            return null;
    }
}