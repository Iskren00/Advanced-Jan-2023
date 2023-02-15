using System;
using System.Collections.Generic;
using System.Linq;

int[] foodPortions = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int[] staminaArray = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

Stack<int> food = new Stack<int>(foodPortions);
Queue<int> stamina = new Queue<int>(staminaArray);

Dictionary<string, int> peeksToClimb = new Dictionary<string, int>();
List<string> peeksClimbed = new();

peeksToClimb.Add("Vihren", 80);
peeksToClimb.Add("Kutelo", 90);
peeksToClimb.Add("Banski Suhodol", 100);
peeksToClimb.Add("Polezhan", 60);
peeksToClimb.Add("Kamenitza", 70);

while (food.Count > 0 && peeksToClimb.Count > 0)
{
    int currFood = food.Pop();
    int currStamina = stamina.Dequeue();

    int sum = currFood + currStamina;
    
    if (sum >= peeksToClimb.First().Value)
    {
        peeksClimbed.Add(peeksToClimb.First().Key);
        peeksToClimb.Remove(peeksClimbed.Last());
    }
}

if (peeksToClimb.Count == 0)
{
    Console.WriteLine("Alex did it! He climbed all top five Pirin peaks in one week -> @FIVEinAWEEK");
}
else
{
    Console.WriteLine("Alex failed! He has to organize his journey better next time -> @PIRINWINS");
}

if (peeksClimbed.Any())
{
    Console.WriteLine("Conquered peaks:");
    Console.WriteLine(String.Join(Environment.NewLine, peeksClimbed));
}