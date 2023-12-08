using Emerald.Commands;
using Emerald.Models;
using Emerald.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Emerald.ViewModels
{
  public class QueryViewModel : ViewModelBase
  {
    private readonly ObservableCollection<ChangeRecordViewModel> changelog;
    private NavigationStore navStore;

    public IEnumerable<ChangeRecordViewModel> ChangeLog => changelog;
    public LoadQueryCommand LoadQuery { get; }
    public DownloadChangeLogCommand DownloadCommand { get; }

    public QueryViewModel(NavigationStore navigation)
    {
      changelog = [];
      navStore = navigation;
      LoadQuery = new LoadQueryCommand(changelog, new Dictionary<string, Course>(), new Dictionary<string, Faculty>());
      DownloadCommand = new DownloadChangeLogCommand(changelog);
    }
  }
}
