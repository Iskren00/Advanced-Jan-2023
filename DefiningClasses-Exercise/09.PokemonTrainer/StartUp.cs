using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace DefiningClasses;

public class StartUp
{
    private static void Main(string[] args)
    {
        List<Trainer> trainers = new();

        string command = string.Empty;

        while ((command = Console.ReadLine()) != "Tournament")
        {
            string[] cmdArg = command
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Trainer trainer = trainers.SingleOrDefault(t => t.Name == cmdArg[0]);

            if (trainer == null)
            {
                trainer = new(cmdArg[0]);
                trainer.Pokemons.Add(new(cmdArg[1], cmdArg[2], int.Parse(cmdArg[3])));
                trainers.Add(trainer);
            }
            else
            {
                trainer.Pokemons.Add(new(cmdArg[1], cmdArg[2], int.Parse(cmdArg[3])));
            }

        }

        command = string.Empty;

        while ((command = Console.ReadLine()) != "End")
        {

            foreach (var trainer in trainers)
            {
                trainer.CheckPokemon(command);
            }
        }

        foreach (var trainer in trainers.OrderByDescending(t => t.Badges))
        {
            Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count}");
        }
    }
}