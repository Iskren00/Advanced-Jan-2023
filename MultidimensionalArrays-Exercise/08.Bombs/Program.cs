using System;
using System.Linq;

int n = int.Parse(Console.ReadLine());

int[,] array = new int[n,n];
    
for (int i = 0; i < n; i++)
{
    int[] numbers = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();

    for (int j = 0; j < numbers.Length; j++)
    {
        array[i, j] = numbers[j];
    }
}

string[] bombsIndex = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

for (int i = 0; i < bombsIndex.Length; i++)
{
    int[] bomb = bombsIndex[i]
        .Split(",", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();


    int bombRow = bomb[0];
    int bombCol = bomb[1];

    int boom = array[bombRow, bombCol];


    array = DoSomting(boom, array, bombRow, bombCol);
}

int count = 0;
int sum = 0;


for (int i = 0; i < n; i++)
{
    for (int j = 0; j < n; j++)
    {
        if (array[i,j] > 0)
        {
            count++;
            sum += array[i, j];
        }
    }
}

Console.WriteLine($"Alive cells: {count}");
Console.WriteLine($"Sum: {sum}");

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < n; j++)
    {
        Console.Write(array[i,j] + " ");
    }

    Console.WriteLine();
}

int[,] DoSomting(int boom, int[,] array, int bombRow, int BombCol)
{

    if (boom <= 0)
    {
        return array;
    }

    if ((bombRow - 1 >= 0) && (BombCol - 1 >= 0))
    {
        Calculate(bombRow - 1, BombCol - 1, boom);
    }

    if ((bombRow - 1 >= 0))
    {
        Calculate(bombRow - 1, BombCol, boom);
    }

    if ((bombRow - 1 >= 0) && (BombCol + 1 < n))
    {
        Calculate(bombRow - 1, BombCol + 1, boom);
    }

    if ((BombCol - 1 >= 0))
    {
        Calculate(bombRow, BombCol - 1, boom);
    }

    if ((BombCol + 1 < n))
    {
        Calculate(bombRow, BombCol + 1, boom);
    }

    if ((bombRow + 1 < n) && (BombCol - 1 >= 0))
    {
        Calculate(bombRow + 1, BombCol - 1, boom);
    }

    if ((bombRow + 1 < n))
    {
        Calculate(bombRow + 1, BombCol, boom);
    }

    if ((bombRow + 1 < n) && (BombCol + 1 < n))
    {
        Calculate(bombRow + 1, BombCol + 1, boom);
    }

    array[bombRow, BombCol] = 0;

    return array;
}

void Calculate(int row, int col, int boom)
{
    if (array[row, col] > 0)
    {
        array[row, col] -= boom;
    }
}
