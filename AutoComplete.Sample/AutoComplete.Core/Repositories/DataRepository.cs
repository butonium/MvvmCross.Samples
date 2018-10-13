using AutoComplete.Core.Repositories.Interfaces;
using MvvmCross.ViewModels;

namespace AutoComplete.Core.Repositories
{
    public class DataRepository : IDataRepository
    {
        public DataRepository()
        {

        }

        public string SelectedResult { get;set; }
        public string PartialText { get; set; }
        public MvxObservableCollection<string> SearchResults { get; set; }

        public async void Sync()
        {
            // Get search results from the REST API
            // And update them to the SearchResults
        }
    }
}
