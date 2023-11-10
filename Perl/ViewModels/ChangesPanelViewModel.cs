using Perl.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perl.ViewModels
{
    public class ChangesPanelViewModel : ViewModelBase
    {
        private readonly QueryStore queryStore;
        private readonly ObservableCollection<ChangeRecordViewModel> changeRecordsViewModels;
        public IEnumerable<ChangeRecordViewModel> ChangeRecordsViewModels { get => changeRecordsViewModels; }

        public ChangesPanelViewModel(QueryStore queryStore) 
        {
            changeRecordsViewModels = new ObservableCollection<ChangeRecordViewModel>();
            this.queryStore = queryStore;
            this.queryStore.QueryRecordChanged += OnQueryRecordChanged;
        }

        private void OnQueryRecordChanged()
        {
            OnPropertyChanged(nameof(ChangeRecordsViewModels));
        }
    }
}
