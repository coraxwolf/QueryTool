using Perl.Commands;
using Perl.Models;
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
    public Int32 CourseCount { get => QueryStore.Courses.Count(); }
    public Int32 FacultyCount { get => QueryStore.Faculty.Count(); }
    public IEnumerable<ChangeRecord> ChangeRecords { get => QueryStore.Changes; }
    public QueryViewModel(QueryStore queryStore)
    {
      QueryStore = queryStore;
      NavigateListingCommand = new QueryLoadCommand(QueryStore);
      LoadQueryCommand = new QueryLoadCommand(QueryStore);
      QueryStore.QueryRecordChanged += QueryStore_QueryRecordChanged;
    }

    private void QueryStore_QueryRecordChanged()
    {
      OnPropertyChanged(nameof(QueryStore));
    }
  }
}
