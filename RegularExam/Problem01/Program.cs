using System;
using System.Collections.Generic;
using System.Linq;

int[] textiles = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int[] medicaments = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

Queue<int> textilesQueue = new(textiles);

Stack<int> medicamentsStack = new(medicaments);

Dictionary<string, int> healingItemsAndResurces = new();

healingItemsAndResurces.Add("Patch", 30);
healingItemsAndResurces.Add("Bandage", 40);
healingItemsAndResurces.Add("MedKit", 100);

Dictionary<string, int> countOfMaked = new();

while (textilesQueue.Count > 0 && medicamentsStack.Count > 0)
{
    int currTextile = textilesQueue.Dequeue();
    int currMedicament = medicamentsStack.Pop();

    int sum = currTextile + currMedicament;

    bool isSumBigger = sum > healingItemsAndResurces["MedKit"];

    if (isSumBigger)
    {
        if (!countOfMaked.ContainsKey("MedKit"))
        {
            countOfMaked.Add("MedKit", 0);
        }

        countOfMaked["MedKit"]++;

        int remaining = sum - healingItemsAndResurces["MedKit"];

        int next = medicamentsStack.Pop();

        next += remaining;

        medicamentsStack.Push(next);

        continue;
    }

    bool isMaked = false;

    foreach (var medicament in healingItemsAndResurces)
    {
        if (sum == medicament.Value)
        {
            if (!countOfMaked.ContainsKey(medicament.Key))
            {
                countOfMaked.Add(medicament.Key, 0);
            }

            countOfMaked[medicament.Key]++;
            isMaked = true;
            break;
        }
    }

    if (!isMaked)
    {
        currMedicament += 10;

        medicamentsStack.Push(currMedicament);
    }
}


if (!textilesQueue.Any() && medicamentsStack.Any())
{
    Console.WriteLine("Textiles are empty.");
}
else if (textilesQueue.Any() && !medicamentsStack.Any())
{
    Console.WriteLine("Medicaments are empty.");
}
else
{
    Console.WriteLine("Textiles and medicaments are both empty.");
}

countOfMaked = countOfMaked.OrderBy(m => m.Key).ToDictionary(m => m.Key, m => m.Value);
countOfMaked = countOfMaked.OrderByDescending(m => m.Value).ToDictionary(m => m.Key, m => m.Value);

foreach (var medicament in countOfMaked)
{
    Console.WriteLine($"{medicament.Key} - {medicament.Value}");
}

if (textilesQueue.Any())
{
    Console.WriteLine($"Textiles left: {string.Join(", ", textilesQueue)}");
}
else if (medicamentsStack.Any())
{
    Console.WriteLine($"Medicaments left: {string.Join(", ", medicamentsStack)}");
}