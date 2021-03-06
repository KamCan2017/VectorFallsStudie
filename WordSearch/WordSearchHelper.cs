﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordFinder
{
    /// <summary>
    /// WordSearchHelper class used to search a text in a word list
    /// </summary>
    public static class WordSearchHelper
    {
        /// <summary>
        /// Find a list of words from this word list,
        ///whose first characters match a search string
        ///by using the multi core processor functionality
        /// </summary>
        /// <param name="wordlist">The word list in which the search string has to be found</param>
        /// <param name="searchString">The serach string</param>
        /// <returns>The collection of founded words</returns>
        public static IEnumerable<string> ParallelFindWordsbySearchString(IEnumerable<string> wordlist, string searchString)
        {
            ConcurrentBag<string> foundedWords = new ConcurrentBag<string>();

            try
            {
                if (wordlist == null || !wordlist.Any() ||
               string.IsNullOrEmpty(searchString) || string.IsNullOrWhiteSpace(searchString))
                    return foundedWords;

                //Get valid words
                var validWords = wordlist.Where(w => !string.IsNullOrEmpty(w) && !string.IsNullOrWhiteSpace(w));
                Parallel.ForEach(
                    validWords,
                    (word) =>
                    {
                        if (word.StartsWith(searchString, StringComparison.InvariantCultureIgnoreCase))
                            foundedWords.Add(word);
                    }
                    );
            }
            catch (Exception e)
            {
                //Log the exception
                Console.WriteLine(e.Message);
                foundedWords = new ConcurrentBag<string>();
            }

            return foundedWords;
        }
    }
}
