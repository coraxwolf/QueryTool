using Microsoft.EntityFrameworkCore;
using Perl.Context;
using Perl.Stores;
using Perl.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Perl
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {
    private QueryStore QueryStore;
    private NavigationStore NavigationStore;
    private const string DB_CONNECTION_STRING = "Data Source=courses.db";


    public App()
    {
      QueryStore = new QueryStore();
      NavigationStore = new NavigationStore(QueryStore);
    }
    protected override void OnStartup(StartupEventArgs e)
    {
      DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(DB_CONNECTION_STRING).Options;
      CourseListDbContext DbContext = new CourseListDbContext(options);
      DbContext.Database.Migrate();

      Window MainWindow = new MainWindow()
      {
        DataContext = new QueryViewModel(QueryStore)
      };
      MainWindow.Show();

      base.OnStartup(e);
    }
  }
}
