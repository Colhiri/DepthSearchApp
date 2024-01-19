using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using DepthSearchApp.Commands;
using DepthSearchApp.Models;
using DepthSearchApp.ViewModels;
using DepthSearchApp.Views;

namespace DepthSearchApp
{
    /// <summary>
    /// ViewModel Window Filters App
    /// </summary>
    public class FiltersViewModel : MainViewModel
    {
        private AllFilesModel allFilesModel = new AllFilesModel();
        public ReadOnlyObservableCollection<string> AllFiles { get => allFilesModel.SearchFiles(_MainPath); }

        private string _SelectedFile;
        public string SelectedFile
        {
            get { return _SelectedFile; }
            set { _SelectedFile = value; }
        }

        private string _MainPath;
        public string MainPath
        {
            get { return _MainPath; }
            set
            {
                _MainPath = value;
                OnPropertyChanged("AllFiles");
            }
        }

        private string _NameContains;
        public string NameContains
        {
            get { return _NameContains; }
            set
            {
                _NameContains = value;
                OnPropertyChanged("AllFiles");
            }
        }

        private string _CompanyContains;
        public string CompanyContains
        {
            get { return _CompanyContains; }
            set
            {
                _CompanyContains = value;
                OnPropertyChanged("AllFiles");
            }
        }

        private string _OrganisationContains;
        public string OrganisationContains
        {
            get { return _OrganisationContains; }
            set
            {
                _OrganisationContains = value;
                OnPropertyChanged("AllFiles");
            }
        }

        private string _DescriptionContains;
        public string DescriptionContains
        {
            get { return _DescriptionContains; }
            set
            {
                _DescriptionContains = value;
                OnPropertyChanged("AllFiles");
            }
        }

        private string _VersionContains;
        public string VersionContains
        {
            get { return _VersionContains; }
            set
            {
                _VersionContains = value;
                OnPropertyChanged("AllFiles");
            }
        }

        private string _AuthorPropertiesContains;
        public string AuthorPropertiesContains
        {
            get { return _AuthorPropertiesContains; }
            set
            {
                _AuthorPropertiesContains = value;
                OnPropertyChanged("AllFiles");
            }
        }

        private RelayCommand _ShowMessage;
        public RelayCommand ShowMessage
        {
            get
            {
                if (_ShowMessage == null)
                {
                    _ShowMessage = new RelayCommand(o =>
                    new FileEditWindow() { DataContext = new FileViewModel()}.Show(), null);
                    // MessageBox.Show("FFFF"), null); ;
                }
                return _ShowMessage;
            }
        }
    }


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
