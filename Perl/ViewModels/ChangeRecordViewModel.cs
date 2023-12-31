﻿using Perl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perl.ViewModels
{
  public class ChangeRecordViewModel : ViewModelBase
  {
    private readonly ChangeRecord changeRecord;
    public string CourseName { get => changeRecord?.Course.CanvasName ?? String.Empty; }
    public string Faculty { get => changeRecord?.Faculty?.ToString() ?? String.Empty; }
    public string Note {  get => changeRecord.Note; }

    public ChangeRecordViewModel(ChangeRecord changeRecord)
    {
      this.changeRecord = changeRecord;
    }
  }
}
