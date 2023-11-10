using Perl.Commands;
using Perl.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Perl.ViewModels
{
    public class QueryViewModel : ViewModelBase
    {
        private QueryStore QueryStore;

        public ICommand NavigateListingCommand { get; }
        public ICommand LoadQueryCommand { get; }
        public QueryPanelViewModel QueryPanelViewModel { get; }
        public ChangesPanelViewModel ChangePanelViewModel { get; }
        public QueryViewModel(QueryStore queryStore)
        {
            QueryStore = queryStore;
            QueryPanelViewModel = new QueryPanelViewModel(QueryStore);
            ChangePanelViewModel = new ChangesPanelViewModel(QueryStore);
            NavigateListingCommand = new QueryLoadCommand(QueryStore);
            LoadQueryCommand = new QueryLoadCommand(QueryStore);
        }
    }
}
