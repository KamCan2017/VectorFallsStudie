using Prism.Commands;
using SearchApp.Model;
using SearchApp.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WordFinder;
using WordSearch;

namespace SearchApp.ViewModels
{
    /// <summary>
    /// MainWindowViewModel class represent the view model of the main view
    /// </summary>
    public class MainWindowViewModel: INotifyPropertyChanged
    {
        #region Fields
        private WordListModel _wordListModel;
        private string _searchWord;
        private DelegateCommand _searchCommand;
        private string _results;
        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the MainViewModel class
        /// </summary>
        public MainWindowViewModel()
        {
            _searchCommand = new DelegateCommand(async() => await ExecuteSearchCommand(), CanExecuteSearchCommand);
            InitWordList();
        }
        #endregion


        #region Properties

        /// <summary>
        /// Gets the search command
        /// </summary>
        public DelegateCommand SearchCommand { get { return _searchCommand; } }

        /// <summary>
        /// Gets the word list
        /// </summary>
        public string WordList { get; private set; }

        /// <summary>
        /// Gets or sets the search word
        /// </summary>
        public string SearchWord
        {
            get { return _searchWord; }
            set
            {
                _searchWord = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SearchWord)));
                SearchCommand.RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        /// Gets or sets the results
        /// </summary>
        public string Results
        {
            get { return _results; }
            set
            {
                _results = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Results)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region private methods

        private async Task ExecuteSearchCommand()
        {
            Stopwatch stopwatch = null;
          var foundeWords =  await Task.Factory.StartNew(() =>
           {
               stopwatch = Stopwatch.StartNew();
               var result = WordSearchHelper.ParallelFindWordsbySearchString(_wordListModel.Items, SearchWord);
               stopwatch.Stop();

               return result;
           });

            SearchResultModel searchResult = new SearchResultModel(CreateWords(foundeWords), stopwatch.Elapsed.TotalMilliseconds, SearchWord);
            Results = "------------------------------------------------------------------\n" +
                       "search word: " + searchResult.SearchWord + "; duration: " + searchResult.SearchDuration  + " (ms)\n" +
                       (!string.IsNullOrEmpty(searchResult.FoundedWords)? searchResult.FoundedWords : "Not found\n") + Results;
        }

        private bool CanExecuteSearchCommand()
        {
            return !string.IsNullOrEmpty(SearchWord) && !string.IsNullOrWhiteSpace(SearchWord);
        }

        private void InitWordList()
        {
            _wordListModel = new WordListModel();


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

            _wordListModel.AddWords(wordList);
            WordList = CreateWords(wordList);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(WordList)));
        }

        private static string CreateWords(IEnumerable<string> wordlist)
        {
            string words = string.Empty;
            if (wordlist != null && wordlist.Any())
            {
                foreach (string word in wordlist)
                    words += word + "\n";
            }
            return words;
        }
        #endregion
    }
}
