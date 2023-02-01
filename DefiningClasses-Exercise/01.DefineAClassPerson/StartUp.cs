using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses;

public class StartUp
{
    private static void Main(string[] args)
    {
        Family family = new();

        int count = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            string[] personArg = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Person person = new(personArg[0], int.Parse(personArg[1]));

            family.AddMember(person);              
        }

        //Person oldestPerson = family.GetOldestMember();

        //Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");

        List<Person> result = family.GetAllOver30(family.People);

        result = result.OrderBy(p => p.Name)
            .ToList();

        foreach (var item in result)
        {
            Console.WriteLine($"{item.Name} - {item.Age}");
        }
    }
}