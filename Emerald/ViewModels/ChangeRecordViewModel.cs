using Emerald.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emerald.ViewModels
{
  public class ChangeRecordViewModel : ViewModelBase
  {
    private readonly ChangeRecord changeRecord;
    public string Change
    {
      get
      {
        return changeRecord.ToString();
      }
    }

    public ChangeRecordViewModel(ChangeRecord changeRecord)
    {
      this.changeRecord = changeRecord;
    }

  }
}
