using Emerald.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emerald.Stores
{
  public class NavigationStore
  {
    private ViewModelBase currentViewModel;
    public ViewModelBase CurrentViewModel
    {
      get => currentViewModel;
      set
      {
        currentViewModel = value;
        OnCurrentViewModelChanged();
      }
    }

    public event Action? CurrentViewModelChanged;

    public void OnCurrentViewModelChanged()
    {
      CurrentViewModelChanged?.Invoke();
    }

    public NavigationStore()
    {
      currentViewModel = new HomeViewModel(this);
    }
  }
}
