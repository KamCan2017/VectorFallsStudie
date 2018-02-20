using System.Collections.Generic;
using System.Linq;

namespace SearchApp.Model
{
    /// <summary>
    /// WordListModel class exposes a word list
    /// and add/remove words in this list
    /// </summary>
    public class WordListModel
    {
        #region Fields
        private List<string> _wordList = new List<string>();
        #endregion

        #region Properties

        /// <summary>
        /// Gets the word list
        /// </summary>
        public IEnumerable<string> Items { get { return _wordList.ToList(); } }
        #endregion

        #region public methods

        /// <summary>
        /// Add a new word
        /// </summary>
        /// <param name="word">The word to add</param>
        public void AddWord(string word)
        {
            if (string.IsNullOrEmpty(word) || string.IsNullOrWhiteSpace(word))
                return;
                
            _wordList.Add(word);
        }

        /// <summary>
        /// Add a  word list
        /// </summary>
        /// <param name="word">The word list to add</param>
        public void AddWords(IEnumerable<string> words)
        {
            if (words == null || !words.Any())
                return;

            _wordList.AddRange(words);
        }

        /// <summary>
        /// Remove a word
        /// </summary>
        /// <param name="word">The word to remove</param>
        public void RemoveWord(string word)
        {
            if (string.IsNullOrEmpty(word) || string.IsNullOrWhiteSpace(word))
                return;

            _wordList.RemoveAll(w => w == word);
        }
        #endregion
    }
}
