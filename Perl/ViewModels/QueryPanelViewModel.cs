using Perl.Models;
using Perl.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perl.ViewModels
{
    public class QueryPanelViewModel : ViewModelBase
    {
        private readonly QueryStore QueryStore;
        public IEnumerable<Course> Records { get => QueryStore.QueryRecords; }
        public QueryPanelViewModel(QueryStore queryStore) 
        {
            QueryStore = queryStore;
        }

    }
}
