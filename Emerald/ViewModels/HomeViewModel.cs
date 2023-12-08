using Emerald.Commands;
using Emerald.Stores;
using Emerald.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Emerald.ViewModels
{
  public class HomeViewModel : ViewModelBase
  {
    private NavigationStore navigationStore;
    public ViewModelBase CurrentViewModel { get => navigationStore.CurrentViewModel; }
    public ICommand? QueryNavigate { get; }
    public ICommand? CourseListNavigate { get; }
    public HomeViewModel(NavigationStore navStore)
    {
      navigationStore = navStore;
      NavigationService queryNavService = new NavigationService(navStore, createQueryViewModel);
      QueryNavigate = new Navigate(queryNavService);
      navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
    }

    private void OnCurrentViewModelChanged()
    {
      OnPropertyChanged(nameof(CurrentViewModel));
    }

    public QueryViewModel createQueryViewModel()
    {
      return new QueryViewModel(navigationStore);
    }
  }
}
