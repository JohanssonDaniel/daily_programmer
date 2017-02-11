using System;
using System.Collections.Generic;

namespace daily_programmer
{
    class RackManagement
    {
        public static void Algorithm()
        {
            Console.WriteLine("This program will check if a given set ");
            Console.WriteLine("of letters can create a given word");

            Console.Write("Input available letters: ");
            string availableString = Console.ReadLine();

            string[] words = System.IO.File.ReadAllLines(
                @"C:\Users\DannePanne\Documents\Arbeten\daily_programmer\daily_programmer\enable1.txt");

            var wordList = new List<String>();
            wordList.AddRange(words);

            wordList.Sort(SortByLength);

            foreach (string word in wordList)
            {
                Dictionary<char, int> reqDict = LetterCounter(word.ToCharArray());
                Dictionary<char, int> availableDict = LetterCounter(availableString.ToCharArray());
                if (!availableDict.ContainsKey('?'))
                {
                    availableDict.Add('?', 0);
                }
                if (containsRequiredLetters(reqDict, availableDict))
                {
                    Console.WriteLine(word);
                    break;
                }
            }
        }

        private static int SortByLength(string word1, string word2)
        {
            return word2.Length.CompareTo(word1.Length);
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
                if (available.ContainsKey(req.Key))
                {
                    if (available[req.Key] >= req.Value)
                    {
                        continue;
                    }
                    else if ((available[req.Key] + available['?']) >= req.Value)
                    {
                        available['?'] -= (req.Value - available[req.Key]);
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (available['?'] >= req.Value)
                {
                    available['?'] -= req.Value;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}
