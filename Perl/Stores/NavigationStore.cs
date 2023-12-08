using Perl.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perl.Stores
{
  public class NavigationStore
  {
    public ViewModelBase CurrentViewModel { get; set; }

    public NavigationStore(QueryStore queryStore) 
    {
      CurrentViewModel = new QueryViewModel(queryStore);
    }
  }
}
