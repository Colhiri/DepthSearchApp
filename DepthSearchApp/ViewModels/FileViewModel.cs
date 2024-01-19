
namespace DepthSearchApp.ViewModels
{
    public class FileViewModel : MainViewModel
    {
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
                OnPropertyChanged(nameof(_IsHidden));
            }
        }

        private bool _IsArchive;
        public bool IsArchive
        {
            get { return _IsArchive; }
            set
            {
                _IsArchive = value;
                OnPropertyChanged(nameof(_IsArchive));
            }
        }

        private bool _IsEncrypted;
        public bool IsEncrypted
        {
            get { return _IsEncrypted; }
            set
            {
                _IsEncrypted = value;
                OnPropertyChanged(nameof(_IsEncrypted));
            }
        }
    }
}
