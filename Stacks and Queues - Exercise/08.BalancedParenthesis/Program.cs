using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.BalancedParenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string paranthesis = Console.ReadLine();

            Stack<char> stack = new Stack<char>();

            foreach (char c in paranthesis)
            {
                switch (c)
                {
                    case '(':
                    case '{':
                    case '[':
                        stack.Push(c);
                        break;
                    case ')':
                        if (stack.Count == 0 || stack.Pop() != '(')
                        {
                            Console.WriteLine("NO");
                            return;
                        }
                        break;
                    case '}':
                        if (stack.Count == 0 || stack.Pop() != '{')
                        {
                            Console.WriteLine("NO");
                            return;
                        }
                        break;
                    case ']':
                        if (stack.Count == 0 || stack.Pop() != '[')
                        {
                            Console.WriteLine("NO");
                            return;
                        }
                        break;
                }
            }

            Console.WriteLine("YES");
        }
    }
}
