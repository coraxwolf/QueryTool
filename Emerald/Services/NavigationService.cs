using Emerald.Commands;
using Emerald.Stores;
using Emerald.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emerald.Services
{
  public class NavigationService
  {
    private readonly NavigationStore navigationStore;
    private Func<ViewModelBase> createViewModel;

    public NavigationService(NavigationStore store, Func<ViewModelBase> createView)
    {
      navigationStore = store;
      createViewModel = createView;
    }

    public void Navigate()
    {
      navigationStore.CurrentViewModel = createViewModel();
      navigationStore.OnCurrentViewModelChanged();
    }
  }
}
