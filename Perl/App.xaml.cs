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

        public App()
        {
            QueryStore = new QueryStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            Window MainWindow = new MainWindow()
            {
                DataContext = new QueryViewModel(QueryStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
