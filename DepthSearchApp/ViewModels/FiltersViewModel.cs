using System.Collections.ObjectModel;

using DepthSearchApp.Models;
using DepthSearchApp.ViewModels;

namespace DepthSearchApp
{
    /// <summary>
    /// ViewModel Window FIlters App
    /// </summary>
    public class FiltersViewModel : MainViewModel
    {
        private AllFilesModel allFilesModel = new AllFilesModel();
        public ReadOnlyObservableCollection<string> AllFiles { get => allFilesModel.SearchFiles(_MainPath); }

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
    }
}
