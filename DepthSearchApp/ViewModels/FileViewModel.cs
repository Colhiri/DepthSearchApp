using DepthSearchApp.Commands;
using DepthSearchApp.Models;
using System;

namespace DepthSearchApp.ViewModels
{
    public class FileViewModel : MainViewModel
    {
        private FileModel FileModel;

        public FileViewModel(string _SelectedFile) 
        {
            this._SelectedFile = _SelectedFile;
            FileModel = new FileModel(_SelectedFile);

            _FileName = FileModel.FileName;
            _IsReadOnly = FileModel.IsReadOnly;
            _IsHidden = FileModel.IsHidden;
            _IsArchive = FileModel.IsArchive;
            _IsEncrypted = FileModel.IsEncrypted;
            _CreateDate = FileModel.CreateDate;
            _AccessDate = FileModel.AccessDate;
            _EditDate = FileModel.EditDate;
            _Author = FileModel.Author;
            _Title = FileModel.Title;
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
            }
        }

        private bool _IsReadOnly;
        public bool IsReadOnly
        {
            get { return _IsReadOnly; }
            set 
            { 
                _IsReadOnly = value; 
            }
        }

        private bool _IsHidden;
        public bool IsHidden
        {
            get { return _IsHidden; }
            set 
            {
                _IsHidden = value;
            }
        }

        private bool _IsArchive;
        public bool IsArchive
        {
            get { return _IsArchive; }
            set
            {
                _IsArchive = value;
            }
        }

        private bool _IsEncrypted;
        public bool IsEncrypted
        {
            get { return _IsEncrypted; }
            set
            {
                _IsEncrypted = value;
            }
        }

        private DateTime _CreateDate;
        public DateTime CreateDate
        {
            get { return _CreateDate; }
            set 
            {
                _CreateDate = value;
            }
        }

        private DateTime _EditDate;
        public DateTime EditDate
        {
            get { return _EditDate; }
            set
            {
                _EditDate = value;
            }
        }

        private DateTime _AccessDate;
        public DateTime AccessDate
        {
            get { return _AccessDate; }
            set
            {
                _AccessDate = value;
            }
        }

        private string _Author;
        public string Author
        {
            get { return _Author; }
            set { 
                _Author = value;
            }
        }

        private string _Title;
        public string Title
        {
            get { return _Title; }
            set 
            { 
                _Title = value;
            }
        }

        /// <summary>
        /// c:\Users\MSI GP66\Desktop\Stat_v1_19\prot\2023-10-24 Туристскор\Трехосные_КД_ПП\
        /// c:\Users\kabanov\Desktop\Stat_v1_19\prot\2023-11-30 Черногорск\компрессия\
        /// </summary>
        public void SaveCommand()
        {
            FileModel.SetFileName(_FileName);
            FileModel.SetIsReadOnly(_IsReadOnly);
            FileModel.SetIsHidden(_IsHidden);
            FileModel.SetIsArchive(_IsArchive);
            FileModel.SetDateCreation(_CreateDate);
            FileModel.SetDateEditing(_EditDate);
            FileModel.SetDateAccess(_AccessDate);
            FileModel.SetAuthor(_Author);
            FileModel.SetTitle(_Title);
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
