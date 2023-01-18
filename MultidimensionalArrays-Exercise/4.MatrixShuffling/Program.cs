using System;
using System.Linq;

int[] dimensions = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int rows = dimensions[0];
int cols = dimensions[1];
string[,] matrix = new string[rows, cols];

for (int row = 0; row < rows; row++)
{
    string[] input = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);
        

    for (int col = 0; col < cols; col++)
    {
        matrix[row, col] = input[col];
    }
}

string command;
while ((command = Console.ReadLine()) != "END")
{
    string[] cmdArg = command
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    if (cmdArg[0] != "swap" || cmdArg.Length != 5)
    {
        Console.WriteLine("Invalid input!");
        continue;
    }

    int rowOne = int.Parse(cmdArg[1]);
    int colOne = int.Parse(cmdArg[2]);
    int rowTwo = int.Parse(cmdArg[3]);
    int colTwo = int.Parse(cmdArg[4]);

    if (rowOne < 0 || rowOne >= rows || colOne < 0 || colOne >= cols || rowTwo < 0 || rowTwo >= rows || colTwo < 0 || colTwo >= cols)
    {
        Console.WriteLine("Invalid input!");
        continue;
    }

    string copy = matrix[rowOne, colOne];

    matrix[rowOne, colOne] = matrix[rowTwo, colTwo];
    matrix[rowTwo, colTwo] = copy;

    for (int row = 0; row < rows; row++)
    {
        for (int col = 0; col < cols; col++)
        {
            Console.Write(matrix[row, col] + " ");
        }

        Console.WriteLine();
    }
}

