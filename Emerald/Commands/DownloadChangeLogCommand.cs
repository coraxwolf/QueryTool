using Emerald.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emerald.Commands
{
  public class DownloadChangeLogCommand : CommandBase
  {
    
    private readonly ObservableCollection<ChangeRecordViewModel> changeLog;
    public DownloadChangeLogCommand(ObservableCollection<ChangeRecordViewModel> changeLog)
    {
      this.changeLog = changeLog;
    }
    public override void Execute(object? parameter)
    {
      throw new NotImplementedException();
    }

    public override bool CanExecute(object? parameter)
    {
      if (changeLog.Count > 0) {return true;} 
      else { return false; }
    }
  }
}
