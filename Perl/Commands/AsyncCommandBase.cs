﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perl.Commands
{
  public abstract class AsyncCommandBase : CommandBase
  {
    private bool isExecuting;
    public bool IsExecuting { 
      get 
      { 
        return isExecuting; 
      } 
      set 
      { 
        isExecuting = value;
        OnCanExecuteChanged();
      }
    }

    public override bool CanExecute(object? parameter)
    {
      return !IsExecuting & base.CanExecute(parameter);
    }
    public override async void Execute(object? parameter)
    {
      IsExecuting = true;

      await ExecuteAsync(parameter);

      IsExecuting = false;
    }
    public abstract Task ExecuteAsync(object? parameter);
  }
}
