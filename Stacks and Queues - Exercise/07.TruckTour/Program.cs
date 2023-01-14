using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TruckTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int petrolPumps = int.Parse(Console.ReadLine());

            Queue<long[]> pumps = new Queue<long[]>();

            List<long[]> pumpsOrg = new List<long[]>();

            for (int i = 0; i < petrolPumps; i++)
            {
                long[] arg = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse)
                    .ToArray();

                pumps.Enqueue(arg);
                pumpsOrg.Add(arg);
            }

            int startingStation = 0;

            long truckTank = 0;

            int counter = 0;

            for (int i = 0; i < petrolPumps; i++)
            {
                long[] tmp = pumps.Dequeue();

                long petrolAmount = tmp[0];

                long nextStationKm = tmp[1];

                truckTank += petrolAmount;

                if (truckTank >= nextStationKm)
                {
                    truckTank -= nextStationKm;
                }
                else
                {
                    truckTank = 0;
                    startingStation = ++counter;
                    i = 0;

                    if (startingStation <= petrolPumps - 1)   
                    {
                        pumps.Clear();              
                        foreach (var p in pumpsOrg)
                        {
                            pumps.Enqueue(p);
                        }

                        for (int j = 0; j < startingStation; j++)
                        {
                            long[] tmp1 = pumps.Dequeue();
                            pumps.Enqueue(tmp1);
                        }

                    }
                    else
                    {
                        startingStation = -1;
                        break;
                    }
                }
            }

            Console.WriteLine(startingStation);
        }
    }
}
