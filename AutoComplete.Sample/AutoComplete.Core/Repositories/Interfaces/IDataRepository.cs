using MvvmCross.ViewModels;

namespace AutoComplete.Core.Repositories.Interfaces
{
    public interface IDataRepository
    {
        MvxObservableCollection<string> SearchResults { get; set; }
        string PartialText { get; set; }
        string SelectedResult { get; set; }
        void Sync();
    }
}
