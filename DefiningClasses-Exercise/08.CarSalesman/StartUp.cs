using System;
using System.Collections.Generic;

namespace DefiningClasses;

public class StartUp
{
    private static void Main(string[] args)
    {
        List<Engine> engines = new();

        int numberOfEngines = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfEngines; i++)
        {
            string[] engineInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Engine engine = new();

            engine.Model = engineInfo[0];
            engine.Power = int.Parse(engineInfo[1]);

            if (engineInfo.Length > 2)
            {
                int displacement;

                bool isDigit = int.TryParse(engineInfo[2], out displacement);

                if (isDigit)
                {
                    engine.Displacement = displacement;
                }
                else
                {
                    engine.Efficiency = engineInfo[2];
                }

                if (engineInfo.Length > 3)
                {
                    engine.Efficiency = engineInfo[3];
                }
            }

            engines.Add(engine);
        }

        List<Car> cars = new();

        int numberOfCars = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfCars; i++)
        {
            string[] carInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Car car = new();

            car.Model = carInfo[0];

            foreach (var engine in engines)
            {
                if (carInfo[1] == engine.Model)
                {
                    car.Engine = engine;
                }
            }

            if (carInfo.Length > 2)
            {
                int weight;

                bool isDigit = int.TryParse(carInfo[2], out weight);

                if (isDigit)
                {
                    car.Weight = weight;
                }
                else
                {
                    car.Color = carInfo[2];
                }

                if (carInfo.Length > 3)
                {
                    car.Color = carInfo[3];
                }
            }
            cars.Add(car);
        }

        foreach (var car in cars)
        {
            Console.WriteLine(car.ToString());
        }
    }
}