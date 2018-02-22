using System;
using System.Collections.Generic;
using System.Linq;

namespace SearchApp.Model
{
    /// <summary>
    /// WordListModel class exposes a word list
    /// and add words in this list
    /// </summary>
    public class WordListModel
    {
        #region Fields
        private List<string> _wordList = new List<string>();
        private Object _lockObject = new Object();

        #endregion

        #region Properties

        /// <summary>
        /// Gets the word list
        /// </summary>
        public IEnumerable<string> Items
        {
            get
            {
                lock(_lockObject)
                {
                    return _wordList;
                }
            }
        }

        #endregion

        #region public methods

        /// <summary>
        /// Add a  word list
        /// </summary>
        /// <param name="word">The word list to add</param>
        public void AddWords(IEnumerable<string> words)
        {
            lock (_lockObject)
            {
                if (words == null || !words.Any())
                    return;

                _wordList.AddRange(words);
            }
        }     
        #endregion
    }
}
