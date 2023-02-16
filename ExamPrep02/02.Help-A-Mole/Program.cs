using System;

namespace _02.Help_A_Mole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] playingField = new char[n, n];

            int moleRow = 0;
            int moleCol = 0;

            int firstSRow = 0;
            int firstSCol = 0;
            int secondSRow = 0;
            int secondSCol = 0;

            bool isFirstTunel = false;

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                for (int j = 0; j < n; j++)
                {
                    playingField[i, j] = input[j];

                    if (playingField[i, j] == 'M')
                    {
                        moleRow = i;
                        moleCol = j;
                    }

                    if (playingField[i, j] == 'S' && isFirstTunel == false)
                    {
                        firstSRow = i;
                        firstSCol = j;
                        isFirstTunel = true;
                    }
                    else if (playingField[i, j] == 'S' && isFirstTunel == true)
                    {
                        secondSRow = i;
                        secondSCol = j;
                    }
                }
            }

            int points = 0;

            string command;

            playingField[moleRow, moleCol] = '-';

            while ((command = Console.ReadLine()) != "End")
            {

                switch (command)
                {
                    case "up":
                        if (moleRow - 1 < 0)
                        {
                            Console.WriteLine("Don't try to escape the playing field!");
                            continue;
                        }

                        moleRow--;

                        Play();
                        break;
                    case "down":
                        if (moleRow + 1 >= n)
                        {
                            Console.WriteLine("Don't try to escape the playing field!");
                            continue;
                        }

                        moleRow++;

                        Play();
                        break;
                    case "left":
                        if (moleCol - 1 < 0)
                        {
                            Console.WriteLine("Don't try to escape the playing field!");
                            continue;
                        }

                        moleCol--;

                        Play();
                        break;
                    case "right":
                        if (moleCol + 1 >= n)
                        {
                            Console.WriteLine("Don't try to escape the playing field!");
                            continue;
                        }

                        moleCol++;

                        Play();
                        break;
                }

                if (points >= 25)
                {
                    break;
                }
            }

            playingField[moleRow, moleCol] = 'M';

            if (points >= 25)
            {
                Console.WriteLine("Yay! The Mole survived another game!");
                Console.WriteLine($"The Mole managed to survive with a total of {points} points.");
            }
            else
            {
                Console.WriteLine("Too bad! The Mole lost this battle!");
                Console.WriteLine($"The Mole lost the game with a total of {points} points.");
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(playingField[i, j]);
                }
                Console.WriteLine();
            }


            void Play()
            {
                if (playingField[moleRow, moleCol] != '-')
                {

                    if (playingField[moleRow, moleCol] == 'S')
                    {
                        playingField[moleRow, moleCol] = '-';

                        if ((moleRow == firstSRow) && (moleCol == firstSCol))
                        {
                            moleRow = secondSRow;
                            moleCol = secondSCol;
                        }
                        else
                        {
                            moleRow = firstSRow;
                            moleCol = firstSCol;
                        }

                        points -= 3;
                        playingField[moleRow, moleCol] = '-';
                    }
                    else
                    {
                        int point = (int)playingField[moleRow, moleCol] - 48;
                        points += point;
                        playingField[moleRow, moleCol] = '-';
                    }
                }
            }
        }       
    }
}