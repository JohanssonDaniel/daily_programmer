using System;
using System.Collections.Generic;

namespace daily_programmer
{
    class RackManagement
    {
        public static void Algorithm()
        {
            Console.WriteLine("This program will check if an given set ");
            Console.WriteLine("of letters can create a given word");

            Console.Write("Input available letters: ");
            string availableString = Console.ReadLine();

            Console.Write("Input wanted word: ");
            string reqString = Console.ReadLine();

            Dictionary<char, int> reqDict = LetterCounter(reqString.ToCharArray());
            Dictionary<char, int> availableDict = LetterCounter(availableString.ToCharArray());

            Console.WriteLine("You can create the word: {0}",
                containsRequiredLetters(reqDict, availableDict));
        }

        private static Dictionary<char, int> LetterCounter(char[] word)
        {
            Dictionary<char, int> lettersInWord = new Dictionary<char, int>();
            foreach (char letter in word)
            {
                if (lettersInWord.ContainsKey(letter))
                {
                    lettersInWord[letter]++;
                }
                else
                {
                    lettersInWord.Add(letter, 1);
                }
            }
            return lettersInWord;
        }

        private static bool containsRequiredLetters(Dictionary<char, int> required, 
                                                        Dictionary<char, int> available)
        {
            foreach(KeyValuePair<char, int> req in required)
            {
                int value = 0;
                available.TryGetValue(req.Key, out value);
                
                if (!available.ContainsKey(req.Key) && !available.ContainsKey('?'))
                {
                    return false;
                }
                else if ((value + available['?']) < req.Value)
                {
                    return false;
                }
                else if (available['?'] > 0)
                {
                    available['?'] -= (req.Value - value);
                    if (available['?'] < 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
