using DefiningClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses;

public class StartUp
{
    private static void Main(string[] args)
    {
        List<Car> cars = new();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] carArg = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Car car = new(carArg[0], int.Parse(carArg[1]), int.Parse(carArg[2]),
                int.Parse(carArg[3]), carArg[4], double.Parse(carArg[5]),
                int.Parse(carArg[6]), double.Parse(carArg[7]), int.Parse(carArg[8]),
                double.Parse(carArg[9]), int.Parse(carArg[10]),
                double.Parse(carArg[11]), int.Parse(carArg[12]));

            cars.Add(car);
        }

        string command = Console.ReadLine();
        List<string> filter = new();

        foreach (var car in cars)
        {
            if (car.Cargo.Type == command && car.Tires.Any(t => t.Pressure < 1))
            {
                filter.Add(car.Model);
            }
            else if (car.Cargo.Type == command && car.Engine.Power > 250)
            {
                filter.Add(car.Model);
            }
        }

        Console.WriteLine(string.Join(Environment.NewLine, filter));
    }
}