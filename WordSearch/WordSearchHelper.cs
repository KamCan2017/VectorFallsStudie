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
        /// </summary>
        /// <param name="wordlist">The word list in which the search string has to be found</param>
        /// <param name="searchString">The serach string</param>
        /// <returns>The collection of founded words</returns>
        public static IEnumerable<string> FindWordsbySearchString(IEnumerable<string> wordlist, string searchString)
        {
            List<string> foundedWords = new List<string>();
            if (wordlist == null || !wordlist.Any() || 
               string.IsNullOrEmpty(searchString) || string.IsNullOrWhiteSpace(searchString))
                return foundedWords;

            foreach(string word in wordlist)
            {
                if (word.Equals(searchString, StringComparison.InvariantCultureIgnoreCase))
                    //if (word.StartsWith(searchString, StringComparison.InvariantCultureIgnoreCase))
                    foundedWords.Add(word);
            }

            return foundedWords;
        }

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
           
            List<string> foundedWords = new List<string>();
            if (wordlist == null || !wordlist.Any() ||
               string.IsNullOrEmpty(searchString) || string.IsNullOrWhiteSpace(searchString))
                return foundedWords;

            ConcurrentBag<string> concurrentBag = new ConcurrentBag<string>(foundedWords); 

            Parallel.ForEach(
                wordlist, 
                (word) => 
                {
                    if(word.Equals(searchString, StringComparison.InvariantCultureIgnoreCase))
                        //if (word.StartsWith(searchString, StringComparison.InvariantCultureIgnoreCase))
                        concurrentBag.Add(word);
                }                
                );           

            return concurrentBag;
        }
    }
}
