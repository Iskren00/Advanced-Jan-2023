using System;
using System.Runtime.CompilerServices;
using System.Xml.Schema;

namespace DefiningClasses;

internal class Car
{
    public string Model { get; set; }

    public double FuelAmount { get; set; }

    public double FuelConsumptionPerKilometer { get; set; }

    public double TravelledDistance { get; set; }

    public void Drive(double amountOfKm)
    {
        double fuel = amountOfKm * this.FuelConsumptionPerKilometer;

        if (fuel > this.FuelAmount)
        {
            Console.WriteLine("Insufficient fuel for the drive");          
        }
        else
        {
            this.FuelAmount -= fuel;
            this.TravelledDistance += amountOfKm;
        }
    }

}
