using System;
using System.Windows;
using System.Windows.Input;
using DepthSearchApp.ViewModels;
using DepthSearchApp.Views;

namespace DepthSearchApp
{
    public class OpenChildWindow : ICommand
    {
        private MainViewModel _MainViewModel;

        public OpenChildWindow(MainViewModel MainViewModel) 
        {
            this._MainViewModel = MainViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            var window = (Window)Activator.CreateInstance(typeof(FileEditWindow));
            window.Show();
        }
    }
}
