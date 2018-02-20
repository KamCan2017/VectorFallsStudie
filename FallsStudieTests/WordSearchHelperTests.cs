﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using WordFinder;

namespace FallsStudie.Tests
{
    [TestClass()]
    public class WordSearchHelperTests
    {
        private List<string> _wordList; 


        [TestInitialize]
        public void Init()
        {
            _wordList = new List<string>
            {
                "AAAAAAA",
                "ZZZZZZ",
                "Hello",
                "Hello, welcome...",
                "XCamp is a great company",
                "XCamp workplace is nice",
                "BBBZZZGGG",
                "hello Böblingen",
                "XCamp",
                "xcamp",
                "XCAMP",
                "earth is a beautiful planet",
            };

        }

        [TestMethod()]
        public void FindWordsbySearchString_InvalidInput_Test()
        {
            //search string is empty
            var result = WordSearchHelper.FindWordsbySearchString(_wordList, string.Empty);
            var expected = new List<string>();
            Assert.AreEqual(expected.Count, result.Count());

            //search string is null
            result = WordSearchHelper.FindWordsbySearchString(_wordList, null);
            Assert.AreEqual(expected.Count, result.Count());

            //Word list is empty
            result = WordSearchHelper.FindWordsbySearchString(new List<string>(), null);
            Assert.AreEqual(expected.Count, result.Count());

            //word list is null
            result = WordSearchHelper.FindWordsbySearchString(null, null);
            Assert.AreEqual(expected.Count, result.Count());
        }

        [TestMethod()]
        public void FindWordsbySearchString_OneWord_Test()
        {
            //Find one word
            var result = WordSearchHelper.FindWordsbySearchString(_wordList, "AAAAAAA");
            var expected = new List<string> { "AAAAAAA" };

            Assert.AreEqual(expected.Count, result.Count());
            Assert.AreEqual(expected.First(), result.First());
        }

        [TestMethod()]
        public void FindWordsbySearchString_TwoWords_Test()
        {
            //Find 2 words
            var result = WordSearchHelper.FindWordsbySearchString(_wordList, "Hello");
            var expected = new List<string> { "Hello" };

            Assert.AreEqual(expected.Count, result.Count());

            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], result.ElementAt(i));
        }

        [TestMethod()]
        public void FindWordsbySearchString_MoreWords_Test()
        {
            //Find 2 words
            var result = WordSearchHelper.FindWordsbySearchString(_wordList, "XCamp");
            var expected = new List<string> { "XCamp",  "xcamp",  "XCAMP",};

            Assert.AreEqual(expected.Count, result.Count());

            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], result.ElementAt(i));
        }

        [TestMethod()]
        public void ParallelFindWordsbySearchString_MoreWords_Test()
        {
            //Find 2 words
            var result = WordSearchHelper.ParallelFindWordsbySearchString(_wordList, "XCamp");
            var expected = new List<string> { "XCamp", "xcamp", "XCAMP", };

            Assert.AreEqual(expected.Count, result.Count());

            foreach (string word in result)
                Assert.IsTrue(expected.Contains(word));
        }
    }
}