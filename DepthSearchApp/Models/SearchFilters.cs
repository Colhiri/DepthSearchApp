using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DepthSearchApp
{
    public class SearchFilters : INotifyPropertyChanged
    {
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
                OnPropertyChanged("AllFilesInMainPath");
            }
        }
        public string NameContains
        {
            get { return _NameContains; }
            set
            {
                _NameContains = value;
                OnPropertyChanged("AllFilesInMainPath");
            }
        }
        public string CompanyContains
        {
            get { return _CompanyContains; }
            set
            {
                _CompanyContains = value;
                OnPropertyChanged("AllFilesInMainPath");
            }
        }
        public string OrganisationContains
        {
            get { return _OrganisationContains; }
            set
            {
                _OrganisationContains = value;
                OnPropertyChanged("AllFilesInMainPath");
            }
        }
        public string DescriptionContains
        {
            get { return _DescriptionContains; }
            set
            {
                _MainPath = value;
                OnPropertyChanged("AllFilesInMainPath");
            }
        }
        public string VersionContains
        {
            get { return _VersionContains; }
            set
            {
                _MainPath = value;
                OnPropertyChanged("AllFilesInMainPath");
            }
        }
        public string AuthorPropertiesContains
        {
            get { return _AuthorPropertiesContains; }
            set
            {
                _MainPath = value;
                OnPropertyChanged("AllFilesInMainPath");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
