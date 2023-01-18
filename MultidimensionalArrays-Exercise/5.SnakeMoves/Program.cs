using System;
using System.Linq;

int[] dimensions = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int rows = dimensions[0];
int cols = dimensions[1];
char[,] matrix = new char[rows, cols];
string input = Console.ReadLine();

//SoftUn
//UtfoSi
//niSoft
//foSinU
//tUniSo
int counter = 0;

for (int row = 0; row < rows; row++)
{

    if (row % 2 == 0)
    {
        for (int col = 0; col < cols; col++)
        {
            if (counter == input.Length)
            {
                counter = 0;
            }
            matrix[row, col] = input[counter];
            counter++;
        }
    }
    else
    {
        for (int col = cols - 1; col >= 0; col--)
        {
            if (counter == input.Length)
            {
                counter = 0;
            }
            matrix[row, col] = input[counter];
            counter++;
        }
    }
}

for (int row = 0; row < rows; row++)
{
    for (int col = 0; col < cols; col++)
    {
        Console.Write($"{matrix[row, col]}");
    }

    Console.WriteLine();
}
