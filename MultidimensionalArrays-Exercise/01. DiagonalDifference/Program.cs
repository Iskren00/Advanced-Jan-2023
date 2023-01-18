using System;
using System.Linq;

int n = int.Parse(Console.ReadLine());

int[,] matrix = new int[n, n];

for (int row = 0; row < n; row++)
{
    int[] numbers = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();

    for (int col = 0; col < n; col++)
    {
        matrix[row, col] = numbers[col];
    }
}

int primeri = 0;
int secondary = 0;

for (int i = 0; i < n; i++)
{
    primeri += matrix[i, i];
    secondary += matrix[n - 1 - i, i];
}


Console.WriteLine(Math.Abs(primeri - secondary));
