using DepthSearchApp.ViewModels;
using DepthSearchApp.Views;
using System;
using System.Collections.Generic;
using System.Windows;

namespace DepthSearchApp
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        Dictionary<Type, Type> windowsInProject = new Dictionary<Type, Type>();

        MainViewModel MainWindowViewModel;

        public App()
        {
            windowsInProject.Add(typeof(FiltersViewModel), typeof(MainWindow));
            windowsInProject.Add(typeof(FileViewModel), typeof(FileEditWindow));
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MainWindowViewModel = new FiltersViewModel();
            var window = (Window)Activator.CreateInstance(typeof(MainWindow));
            window.DataContext = MainWindowViewModel;
            window.ShowDialog();

            Shutdown();
        }
    }
}
