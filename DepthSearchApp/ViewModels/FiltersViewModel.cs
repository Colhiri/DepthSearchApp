using System.Collections.ObjectModel;
using System.Diagnostics;
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
        /// <summary>
        /// Модель для основного окна
        /// </summary>
        private AllFilesModel allFilesModel = new AllFilesModel();

        /// <summary>
        /// Коллекция объектов всех найденных файлов по пути
        /// </summary>
        public ReadOnlyObservableCollection<string> AllFiles { get => allFilesModel.SearchFiles(_MainPath); }

        /// <summary>
        /// Выбранный файл
        /// </summary>
        private string _SelectedFile;
        public string SelectedFile
        {
            get { return _SelectedFile; }
            set 
            { 
                _SelectedFile = value;
                OnPropertyChanged("ButtonEditFileEnabled");
            }
        }

        [Conditional("DEBUG")]
        private void SetMainPath() => _MainPath = @"c:\\Users\\kabanov\\Desktop\\Stat_v1_19\\prot\\2023-11-30 Черногорск\\компрессия\\";
        public FiltersViewModel()
        {

            // c:\Users\MSI GP66\Desktop\Stat_v1_19\prot\2023-10-24 Туристскор\Трехосные_КД_ПП\
            // c:\\Users\\kabanov\\Desktop\\Stat_v1_19\\prot\\2023-11-30 Черногорск\\компрессия\\
            SetMainPath();
        }

        /// <summary>
        /// Основной путь
        /// </summary>
        private string _MainPath;
        public string MainPath
        {
            get
            {
                return _MainPath; 
            }
            set
            {
                _MainPath = value;
                OnPropertyChanged("AllFiles");
            }
        }

        /// <summary>
        /// Что должно содержаться в имени файла
        /// </summary>
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

        /// <summary>
        /// Что должно содержаться в названии компании файла
        /// </summary>
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

        /// <summary>
        /// Что должно содержаться в названии организации, которая создала файл файла
        /// </summary>
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

        /// <summary>
        /// Что должно содержаться в описании файла
        /// </summary>
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

        /// <summary>
        /// Что должно содержаться в версии файла
        /// </summary>
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

        /// <summary>
        /// Что должно содержаться в авторских свойствах файла
        /// </summary>
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

        /// <summary>
        /// Активна ли кнорпка изменения файла (выбран ли файл для редактирования свойств)
        /// </summary>
        public bool ButtonEditFileEnabled { get => SelectedFile != null; }

        /// <summary>
        /// Команда показа окна изменения файла
        /// </summary>
        private RelayCommand _ShowMessage;
        public RelayCommand ShowMessage
        {
            get
            {
                if (_ShowMessage == null)
                {
                    _ShowMessage = new RelayCommand(o =>
                    new FileEditWindow() { 
                        DataContext = new FileViewModel(SelectedFile) 
                    }.Show(), null);
                }
                return _ShowMessage;
            }
        }
    }
}
