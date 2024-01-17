using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using DepthSearchApp.Models;

namespace DepthSearchApp
{
    public class ViewModel : INotifyPropertyChanged
    {
        private AllFilesModel allFilesModel = new AllFilesModel();

        private string _MainPath;
        private string _NameContains;
        private string _CompanyContains;
        private string _OrganisationContains;
        private string _DescriptionContains;
        private string _VersionContains;
        private string _AuthorPropertiesContains;

        public string MainPath
        {
            get { return _MainPath; }
            set
            {
                _MainPath = value;
                OnPropertyChanged("AllFiles");
            }
        }

        public string NameContains
        {
            get { return _NameContains; }
            set
            {
                _NameContains = value;
                OnPropertyChanged("AllFiles");
            }
        }
        public string CompanyContains
        {
            get { return _CompanyContains; }
            set
            {
                _CompanyContains = value;
                OnPropertyChanged("AllFiles");
            }
        }
        public string OrganisationContains
        {
            get { return _OrganisationContains; }
            set
            {
                _OrganisationContains = value;
                OnPropertyChanged("AllFiles");
            }
        }
        public string DescriptionContains
        {
            get { return _DescriptionContains; }
            set
            {
                _DescriptionContains = value;
                OnPropertyChanged("AllFiles");
            }
        }
        public string VersionContains
        {
            get { return _VersionContains; }
            set
            {
                _VersionContains = value;
                OnPropertyChanged("AllFiles");
            }
        }
        public string AuthorPropertiesContains
        {
            get { return _AuthorPropertiesContains; }
            set
            {
                _AuthorPropertiesContains = value;
                OnPropertyChanged("AllFiles");
            }
        }

        public ReadOnlyObservableCollection<string> AllFiles
        {
            get => allFilesModel.SearchFiles(_MainPath);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName="")
        {
            if (PropertyChanged != null)
            {
                //PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
