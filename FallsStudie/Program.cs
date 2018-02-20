using System;
using System.Collections.Generic;
using WordFinder;
using WordSearch;

namespace FallsStudie
{
    class Program
    {
        static void Main(string[] args)
        {
           var wordList = WordListCreator.CreateDefaultWordList();
                
            //    new List<string>
            //{
            //    "AAAAAAA",
            //    "ZZZZZZ",
            //    "Hello, welcome...",
            //    "Vector is a great company",
            //    "vector workplace is nice",
            //    "BBBZZZGGG",
            //    "hello Böblingen",
            //    "vectors contain...",
            //    "Xvector",
            //    "vector object is usefull",
            //    "earth is a beautifull planet",
            //    "earth environment changes to fast",
            //    "earth is the only planet where humans live"
            //};

            Console.WriteLine("--------Word List--------------------");
            foreach (string word in wordList)
                Console.WriteLine(word);

            Console.WriteLine("\nsearch a word: ");

            string searchString = Console.ReadLine();
            Console.WriteLine();

            var foundedWords = WordSearchHelper.ParallelFindWordsbySearchString(wordList, searchString);
            Console.WriteLine("results for {0}: ", searchString);
            foreach (string word in foundedWords)
                Console.WriteLine(word);

            Console.ReadLine();

        }
    }
}
