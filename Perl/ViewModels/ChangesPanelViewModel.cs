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

        public ObservableCollection<QueryCourseRecordViewModel> GetQueryRecordsViewModels()
        {
            ObservableCollection<QueryCourseRecordViewModel> viewModelsList = new ObservableCollection<QueryCourseRecordViewModel>();
            queryStore.QueryRecords.ToList().ForEach(record =>
            {
                viewModelsList.Add(new QueryCourseRecordViewModel(record));
            });
            return viewModelsList;
        }

        public ChangesPanelViewModel(QueryStore queryStore) 
        {
            this.queryStore = queryStore;
            this.queryStore.QueryRecordChanged += OnQueryRecordChanged;
        }

        private void OnQueryRecordChanged()
        {
            OnPropertyChanged();
        }
    }
}
