namespace SearchApp.Models
{
    /// <summary>
    /// The SearchResultModel class
    /// </summary>
    public class SearchResultModel
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the SearchResultModel class
        /// </summary>
        /// <param name="foundedWords">the results</param>
        /// <param name="searchDuration">the search duration</param>
        /// <param name="searchString">the word to search</param>
        public SearchResultModel(string foundedWords, double searchDuration, string searchString)
        {
            SearchWord = searchString;
            FoundedWords = !string.IsNullOrEmpty(foundedWords) ? foundedWords : "Kein Treffer\n";
            SearchDuration = searchDuration;
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets the search word
        /// </summary>
        public string SearchWord { get; private set; }

        /// <summary>
        /// Gets the founded words
        /// </summary>
        public string FoundedWords { get; private set; }

        public double SearchDuration { get; private set; }

        #endregion
    }
}
