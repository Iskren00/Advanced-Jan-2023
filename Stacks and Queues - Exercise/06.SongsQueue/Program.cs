using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.SongsQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> songs = new Queue<string>(
               Console.ReadLine()
               .Split(", ", StringSplitOptions.RemoveEmptyEntries)
               );

            while (songs.Any())
            {
                string[] cmdArg = Console.ReadLine()
                    .Split(" ");

                string cmdType = cmdArg[0];

                if (cmdType == "Play")
                {
                    songs.Dequeue();
                }
                else if (cmdType == "Add")
                {
                    string song = string.Join(" ", cmdArg.Skip(1));
                    if (songs.Contains(song))
                    {
                        Console.WriteLine($"{song} is already contained!");
                        continue;
                    }
                    songs.Enqueue(song);
                }
                else if (cmdType == "Show")
                {
                    Console.WriteLine(string.Join(", ", songs));
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
