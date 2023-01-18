using System;
using System.Linq;

int rows = int.Parse(Console.ReadLine());

long[][] matrix = new long[rows][];

for (int row = 0; row < rows; row++)
{
	long[] input = Console.ReadLine()
		.Split(" ", StringSplitOptions.RemoveEmptyEntries)
		.Select(long.Parse)
		.ToArray();

		matrix[row] = input;	
}


for (int row = 0; row < rows - 1; row++)
{
	if (matrix[row].Length == matrix[row + 1].Length)
	{
		for (int col = 0; col < matrix[row].Length; col++)
		{
			matrix[row][col] *= 2;
            matrix[row + 1][col] *= 2;
        }
	}
	else
	{
		for (int col = 0; col < matrix[row].Length; col++)
		{
			matrix[row][col] /= 2;
		}

        for (int col = 0; col < matrix[row + 1].Length; col++)
        {
            matrix[row + 1][col] /= 2;
        }
    }
}

while (true)
{
    string command = Console.ReadLine();

    if (command == "End")
    {
        break;
    }

    string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

    int row = int.Parse(tokens[1]);
    int col = int.Parse(tokens[2]);
    int value = int.Parse(tokens[3]);

    if (tokens[0] == "Add")
    {
        if (ValidCoordinates(row, col, matrix))
        {
            matrix[row][col] += value;
        }
    }
    else
    {
        if (ValidCoordinates(row, col, matrix))
        {
            matrix[row][col] -= value;
        }
    }
}

for (int row = 0; row < rows; row++)
{
    for (int col = 0; col < matrix[row].Length; col++)
    {
        Console.Write($"{matrix[row][col]} ");
    }

    Console.WriteLine();
}

static bool ValidCoordinates(int row, int col, long[][] jaggedArray)
{
    return row >= 0
        && row < jaggedArray.Length
        && col >= 0
        && col < jaggedArray[row].Length;
}