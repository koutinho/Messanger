using MessangerClient.Model;
using MessangerClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MessangerClient
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            IMessageManager messageManager = new WebApiMessageManager();

            MainWindowViewModel viewModel = new MainWindowViewModel(messageManager);

            MainWindow view = new MainWindow();
            view.DataContext = viewModel;


            view.Show();
        }
    }
}
