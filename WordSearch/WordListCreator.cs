using System;
using System.Collections.Generic;

namespace WordSearch
{
    /// <summary>
    /// WordListCreator class creates a default word list used to search some words in it
    /// </summary>
    public static class WordListCreator
    {

        public static IEnumerable<string> CreateDefaultWordList()
        {
            char[] alphabet = {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L',
                               'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W',
                               'X', 'Y', 'Z' };

            List<string> wordList = new List<string>();
            Random random = new Random();
            string newWord = string.Empty;
            foreach(char letter in alphabet)
            {
                newWord = string.Empty;
                for(int i = 0; i < 4; i++)
                {
                    newWord += new string(new[] { letter });
                }

                int position = 0;
                do
                {
                    position = random.Next(0, 25);
                } while (position > wordList.Count);

                if (!wordList.Contains(newWord))
                    wordList.Insert(position, newWord);
            }

            return wordList;
        }
    }
}
