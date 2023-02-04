using System;
using System.Collections.Generic;

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

            Car car = new Car();
            string model = carArg[0];
            double fuelAmount = double.Parse(carArg[1]);
            double fuelConsumptionPerKilometer = double.Parse(carArg[2]);

            car.Model = model;
            car.FuelAmount = fuelAmount;
            car.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;

            cars.Add(car);
        }

        string command = string.Empty;

        while ((command = Console.ReadLine()) != "End")
        {
            string[] cmdArg = command
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string carModel = cmdArg[1];
            double amountOfKm = double.Parse(cmdArg[2]);

            foreach (var car in cars)
            {
                if (car.Model == carModel)
                {
                    car.Drive(amountOfKm);
                }
            }
        }

        foreach (var car in cars)
        {
            Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TravelledDistance}");
        }
    }
}