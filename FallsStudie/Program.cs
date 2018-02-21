using System;
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
            //    "XCamp is a great company",
            //    "XCamp workplace is nice",
            //    "BBBZZZGGG",
            //    "hello Böblingen",
            //    "xcamp contain...",
            //    "xxcamp",
            //    "camp object is usefull",
            //    "earth is a beautifull planet",
            //    "earth environment changes to fast",
            //    "earth is the only planet where humans live"
            //};

            Console.WriteLine("--------Wortliste--------------------");
            foreach (string word in wordList)
                Console.WriteLine(word);

            Console.WriteLine("\nSuchen sie ein Wort: ");

            string searchString = Console.ReadLine();
            Console.WriteLine();

            var foundedWords = WordSearchHelper.ParallelFindWordsbySearchString(wordList, searchString);
            Console.WriteLine("Ergebnisse für {0}: ", searchString);
            foreach (string word in foundedWords)
                Console.WriteLine(word);

            Console.ReadLine();

        }
    }
}
