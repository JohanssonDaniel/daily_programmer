using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace daily_programmer
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ ".ToCharArray();

            Console.WriteLine("This program will take take two strings and change each individual");
            Console.WriteLine("letter in the first string until it is the same as the second string");

            Console.Write("Input first string: ");
            string firstString = Console.ReadLine();

            Console.Write("Input second string(same length): ");
            string secondString = Console.ReadLine();

            if(firstString.Length == secondString.Length)
            { 
                int size = firstString.Length;
                int alphaSize = alpha.Length;

                char[] firstChar = firstString.ToUpper().ToCharArray();
                char[] secondChar = secondString.ToUpper().ToCharArray();

                for (int i = 0; i < size; i++)
                {
                    for (int a = 0; a < alphaSize; a++)
                    { 
                        if (firstChar[i] == secondChar[i])
                        {
                            Console.WriteLine(firstChar);
                            break;
                        }
                        else
                        {
                            firstChar[i] = alpha[a];
                        }
                    }
                }
                    
                firstString = new string(firstChar).ToLower();
                Console.WriteLine(firstString);
                Console.ReadLine();
            }
        }
    }
}
