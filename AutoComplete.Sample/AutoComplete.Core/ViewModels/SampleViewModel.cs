using AutoComplete.Core.Repositories.Interfaces;
using MvvmCross.ViewModels;

namespace AutoComplete.Core.ViewModels
{
    public class SampleViewModel : MvxViewModel
    {
        private readonly IDataRepository dataRepository;

        private string selectedResult;
        public string SelectedResult
        {
            get
            {
                return dataRepository.SelectedResult;
            }
            set
            {
                dataRepository.SelectedResult = value;
                RaisePropertyChanged(() => SelectedResult);
            }
        }

        public string PartialText
        {
            get
            {
                return dataRepository.PartialText;
            }
            set
            {
                dataRepository.PartialText = value;
                RaisePropertyChanged(() => PartialText);
                dataRepository.Sync();
            }
        }

        public MvxObservableCollection<string> SearchResults
        {
            get
            {
                return dataRepository.SearchResults;
            }
            set
            {
                dataRepository.SearchResults = value;
                RaisePropertyChanged(() => SearchResults);
            }
        }

        public SampleViewModel(IDataRepository dataRepository)
        {
            this.dataRepository = dataRepository;
        }
    }
}
