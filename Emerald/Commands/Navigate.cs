using Emerald.Stores;
using Emerald.ViewModels;
using Emerald.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emerald.Commands
{
  public class Navigate : CommandBase
  {

    private NavigationService navigationService;
    public Navigate(NavigationService navServices)
    {
      navigationService = navServices;
    }
    public override void Execute(object? parameter)
    {
      navigationService.Navigate();
    }
  }
}
