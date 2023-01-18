using System;
using System.Linq;

int[] dimensions = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int rows = dimensions[0];
int cols = dimensions[1];
int[,] matrix = new int[rows, cols];

for (int row = 0; row < rows; row++)
{
    int[] input = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();

    for (int col = 0; col < cols; col++)
    {
        matrix[row, col] = input[col];
    }
}

int maxSum = int.MinValue;
int maxStartRow = 0;
int maxStartCol = 0;
int currentSum = 0;

for (int row = 0; row < rows - 2; row++)
{
    for (int col = 0; col < cols - 2; col++)
    {
        currentSum = matrix[row, col] + matrix[row, col + 1] +
            matrix[row, col + 2] + matrix[row + 1, col] +
            matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
            matrix[row + 2, col + 1] + matrix[row + 2, col + 2] + matrix[row + 2, col];

        if (currentSum > maxSum)
        {
            maxSum = currentSum;
            maxStartRow = row;
            maxStartCol = col;
        }
    }
}
int endRow = maxStartRow;
int endCol = maxStartCol;
    
Console.WriteLine($"Sum = {maxSum}");

for (int row = maxStartRow; row <= endRow + 2; row++)
{
    for (int col = maxStartCol; col <= endCol + 2; col++)
    {
        Console.Write(matrix[row, col] + " ");
    }
    Console.WriteLine();
}

