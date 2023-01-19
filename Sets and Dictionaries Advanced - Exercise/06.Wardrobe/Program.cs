using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

Dictionary<string, Dictionary<string, int>> clothsByColor = new();

int n = int.Parse(Console.ReadLine());

//"{color} -> {item1},{item2},{item3}…"

for (int i = 0; i < n; i++)
{
    string[] input = Console.ReadLine()
        .Split(new string[] {" -> ", "," } , StringSplitOptions.RemoveEmptyEntries);

    string color = input[0];

    if (!clothsByColor.ContainsKey(color))
    {
        clothsByColor.Add(color, new Dictionary<string, int>());
    }

    for (int j = 1; j < input.Length; j++)
    {
        if (!clothsByColor[color].ContainsKey(input[j]))
        {
            clothsByColor[color].Add(input[j], 0);
        }

        clothsByColor[color][input[j]]++;
    }
}

string[] clothToSearch = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

string name = clothToSearch[0];
string cloth = clothToSearch[1];

foreach (var item in clothsByColor)
{
    Console.WriteLine($"{item.Key} clothes:");

    foreach (var cloths in item.Value)
    {
        string print = $"* {cloths.Key} - {cloths.Value}";

        if (cloths.Key == cloth && item.Key == name)
        {
            print += " (found!)";
        }

        Console.WriteLine(print);
    } 
}


