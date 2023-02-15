using System;

int n = int.Parse(Console.ReadLine());

char[,] battlefield = new char[n , n];

int submarineRow = 0;
int submarineCol = 0;

for (int i = 0; i < n; i++)
{
    string col = Console.ReadLine();

	for (int j = 0; j < n; j++)
	{
		battlefield[i, j] = col[j];

		if (col[j] == 'S')
		{
			submarineRow = i;
			submarineCol = j;
		}			
	}
}

int minesCount = 0;
int cruisersCount = 0;

battlefield[submarineRow, submarineCol] = '-';

while (minesCount != 3 && cruisersCount != 3)
{
	string command = Console.ReadLine();

	switch (command)
	{
		case "down":
			submarineRow++;

			if (battlefield[submarineRow,submarineCol] == '*')
			{
				minesCount++;
			}
			else if (battlefield[submarineRow, submarineCol] == 'C')
			{
				cruisersCount++;
			}

			battlefield[submarineRow,submarineCol] = '-';
			break;
        case "up":
            submarineRow--;

            if (battlefield[submarineRow, submarineCol] == '*')
            {
                minesCount++;
            }
            else if (battlefield[submarineRow, submarineCol] == 'C')
            {
                cruisersCount++;
            }

            battlefield[submarineRow, submarineCol] = '-';
            break;
        case "left":
			submarineCol--;

            if (battlefield[submarineRow, submarineCol] == '*')
            {
                minesCount++;
            }
            else if (battlefield[submarineRow, submarineCol] == 'C')
            {
                cruisersCount++;
            }

            battlefield[submarineRow, submarineCol] = '-';
            break;
		case "right":
			submarineCol++;

            if (battlefield[submarineRow, submarineCol] == '*')
            {
                minesCount++;
            }
            else if (battlefield[submarineRow, submarineCol] == 'C')
            {
                cruisersCount++;
            }

            battlefield[submarineRow, submarineCol] = '-';
            break;
    }
}

battlefield[submarineRow, submarineCol] = 'S';

if (minesCount == 3)
{
    Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{submarineRow}, {submarineCol}]!");
}
else
{
    Console.WriteLine("Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
}

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < n; j++)
    {
        Console.Write(battlefield[i,j]);
    }
    Console.WriteLine();
}