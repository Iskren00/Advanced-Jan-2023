using System;
using System.Linq;

string[] input = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

int n = int.Parse(input[0]);
int m = int.Parse(input[1]);

char[,] playground = new char[n, m];

int blindManRow = 0;
int blindManCol = 0; 

for (int i = 0; i < n; i++)
{
    char[] chars = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(char.Parse)
        .ToArray();

    for (int j = 0; j < m; j++)
    {
        playground[i, j] = chars[j];

        if (chars[j] == 'B')
        {
            blindManRow = i;
            blindManCol = j;
        }
    }

}

string command;

int countOfTuched = 0;
int countOfMoves = 0;

playground[blindManRow, blindManCol] = '-';

while ((command = Console.ReadLine()) != "Finish")
{
    switch (command)
    {
        case "up":
            if (blindManRow - 1 < 0 || playground[blindManRow - 1, blindManCol] == 'O')
            {
                continue;
            }

            blindManRow--;

            Play();
            break;

        case "down":
            if (blindManRow + 1 >= n || playground[blindManRow + 1, blindManCol] == 'O')
            {
                continue;
            }

            blindManRow++;

            Play();
            break;

        case "left":

            if (blindManCol - 1 < 0 || playground[blindManRow, blindManCol - 1] == 'O')
            {
                continue;
            }

            blindManCol--;

            Play();
            break;

        case "right":
            if (blindManCol + 1 >= n || playground[blindManRow, blindManCol + 1] == 'O')
            {
                continue;
            }

            blindManCol++;

            Play();
            break;
    }

    if (countOfTuched == 3)
    {
        break;
    }
}

Console.WriteLine("Game over!");
Console.WriteLine($"Touched opponents: {countOfTuched} Moves made: {countOfMoves}");

 void Play()
 {
    countOfMoves++;

    if (playground[blindManRow, blindManCol] == 'P')
    {
        playground[blindManRow, blindManCol] = '-';

        countOfTuched++;
    }
 }