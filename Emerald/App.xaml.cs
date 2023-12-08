using Emerald.Data;
using Emerald.Stores;
using Emerald.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using System.Data;
using System.Windows;

namespace Emerald
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {
    public string CurrentTerm { get; set; } = string.Empty;
    public IHost host;

    public App()
    {
      host = Host.CreateDefaultBuilder()
        .ConfigureServices((hostContext, services) =>
        {
          /* DB Connection String
          string connectionString = hostContext.Configuration.GetConnectionString("Default");

          // DB Context Factory
          services.AddSingleton(new MySQLDBContextFactory(connectionString));

          */

          // Course Provider

          // Course Creator

          // Faculty Provider

          // Faculty Creator

          // Faculty Assignment Provider

          // Faculty Assignment Creator

          // Navigation Store
          services.AddSingleton<NavigationStore>();

          // Course Store

          // Faculty Store

          // Views

          // MainWindow
          services.AddSingleton<HomeViewModel>();
          services.AddSingleton<QueryViewModel>();
          services.AddSingleton(services => new MainWindow()
          {
            DataContext = services.GetRequiredService<HomeViewModel>()
          });

        })
        .Build();
    }

    protected void GenerateTermCode()
    {
      DateOnly curDate = DateOnly.FromDateTime(DateTime.Now) ;
      // Calculate current Term Code
      string acadYear;
      if (curDate.Month > 8)
      {
        // In next Academic Year
        acadYear = (curDate.Year + 1).ToString().Substring(2);
      }
      else
      {
        acadYear = curDate.Year.ToString().Substring(2);
      }
      string semester;
      if (curDate.Month > 8)
      {
        // In Fall
        semester = "1";
      }
      else if (curDate.Month > 5 && curDate.Month < 9)
      {
        // In Summer
        semester = "3";
      }
      else
      {
        // Month is between 1 and 5, spring
        semester = "2";
      }
      CurrentTerm = '6' + acadYear + semester;
    }

    protected override void OnStartup(StartupEventArgs e)
    {
      if (CurrentTerm == string.Empty)
      {
        GenerateTermCode();
      }

      host.Start();

      NavigationStore navStore = host.Services.GetRequiredService<NavigationStore>();

      // DB Connection
      DbContextOptions options = new DbContextOptionsBuilder().UseSqlite("Data Source=EOTool.db").Options;
      using (EODbContext dbContext = new EODbContext(options))
      {
        dbContext.Database.Migrate();
      }


      MainWindow = host.Services.GetRequiredService<MainWindow>();

      MainWindow.Show();

      base.OnStartup(e);
    }

    protected override void OnExit(ExitEventArgs e)
    {
      host.Dispose();
      
      base.OnExit(e);
    }
  }

}
