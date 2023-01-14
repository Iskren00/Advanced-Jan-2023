using System;
using System.Collections.Generic;

namespace _09.SimpleTextEditor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string text = string.Empty;

            Stack<string> changes = new Stack<string>();   

            for (int i = 0; i < n; i++)
            {
                string[] cmdArg = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                int cmdType = int.Parse(cmdArg[0]);

                switch (cmdType)
                {
                    case 1:
                        changes.Push(text);
                        text += cmdArg[1];
                        break;
                    case 2:
                        changes.Push(text);
                        text = text.Remove(text.Length - int.Parse(cmdArg[1]));
                        break;
                    case 3:
                        Console.WriteLine(text[int.Parse(cmdArg[1]) - 1]);
                        break;
                    case 4:
                        if (changes.Count != 0)
                        {
                            text = changes.Pop();
                        }
                        break;
                }
            }


        }
    }
}
