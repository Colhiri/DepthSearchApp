using DepthSearchApp.Commands;
using DepthSearchApp.Models;
using System.Windows.Controls;
using System.Xml.Linq;

namespace DepthSearchApp.ViewModels
{
    public class FileViewModel : MainViewModel
    {
        private FileModel FileModel = new FileModel();

        public FileViewModel(string _SelectedFile) 
        {
            this._SelectedFile = _SelectedFile;
            _FileName = FileModel.GetFileName(SelectedFile);
            _IsReadOnly = FileModel.GetFileIsReadOnly(SelectedFile);
            _IsHidden = FileModel.GetFileIsHidden(SelectedFile);
            _IsArchive = FileModel.GetFileIsArchive(SelectedFile);
            _IsEncrypted = FileModel.GetFileIsEncrypted(SelectedFile);
        }

        private string _SelectedFile;
        public string SelectedFile 
        {
            get { return _SelectedFile; }
            set { _SelectedFile = value; }
        }

        private string _FileName;
        public string FileName 
        {
            get { return _FileName; }
            set 
            { 
                _FileName = value;
                OnPropertyChanged(nameof(FileName));
            }
        }

        private bool _IsReadOnly;
        public bool IsReadOnly
        {
            get { return _IsReadOnly; }
            set 
            { 
                _IsReadOnly = value; 
                OnPropertyChanged(nameof(IsReadOnly));
            }
        }

        private bool _IsHidden;
        public bool IsHidden
        {
            get { return _IsHidden; }
            set 
            {
                _IsHidden = value; 
                OnPropertyChanged(nameof(IsHidden));
            }
        }

        private bool _IsArchive;
        public bool IsArchive
        {
            get { return _IsArchive; }
            set
            {
                _IsArchive = value;
                OnPropertyChanged(nameof(IsArchive));
            }
        }

        private bool _IsEncrypted;
        public bool IsEncrypted
        {
            get { return _IsEncrypted; }
            set
            {
                _IsEncrypted = value;
                OnPropertyChanged(nameof(IsEncrypted));
            }
        }

        /// <summary>
        /// NOT WORKIMG c:\Users\MSI GP66\Desktop\Stat_v1_19\prot\2023-10-24 Туристскор\Трехосные_КД_ПП\
        /// 
        /// <TextBlock Grid.Row="3" Grid.Column="0">Скрытый</TextBlock>
        /// <CheckBox Grid.Row="3" Grid.Column= "1" Name= "HiddenCheckBox" Margin= "2"
        ///           IsChecked= "{Binding Path=IsHidden}"
        ///           IsEnabled= "True" ></ CheckBox >
        /// 
        /// < TextBlock Grid.Row= "4" Grid.Column= "0" > Архивный </ TextBlock >
        /// < CheckBox Grid.Row= "4" Grid.Column= "1" Name= "ArchiveCheckBox" Margin= "2"
        ///           IsChecked= "{Binding Path=IsArchive}"
        ///           IsEnabled= "True" ></ CheckBox >
        /// 
        /// < TextBlock Grid.Row= "5" Grid.Column= "0" > Зашифрованный </ TextBlock >
        /// < CheckBox  Grid.Row= "5" Grid.Column= "1" Name= "EncryptedCheckBox" Margin= "2"
        ///            IsChecked= "{Binding Path=IsEncrypted}"
        ///            IsEnabled= "True" ></ CheckBox >
        /// 
        /// </summary>
        private bool _WindowEnabled;
        public bool WindowEnabled 
        { 
            get { return _WindowEnabled; }
            set 
            {
                SaveCommand();
                _WindowEnabled = true; 
            }
        }
        public void SaveCommand()
        {
            FileModel.SetFileName(SelectedFile, _FileName);
            FileModel.SetIsReadOnly(SelectedFile, _IsReadOnly);
            FileModel.SetIsHidden(SelectedFile, _IsHidden);
            FileModel.SetIsArchive(SelectedFile, _IsArchive);
            FileModel.SetIsEncrypted(SelectedFile, _IsEncrypted);
        }

        /// <summary>
        /// Команда показа окна изменения файла
        /// </summary>
        private RelayCommand _ApplyParameters;
        public RelayCommand ApplyParameters
        {
            get
            {
                if (_ApplyParameters == null)
                {
                    _ApplyParameters = new RelayCommand(o => SaveCommand(), null);
                }
                return _ApplyParameters;
            }
        }
    }
}
