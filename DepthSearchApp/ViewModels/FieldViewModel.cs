namespace DepthSearchApp.ViewModels
{
    public class FieldViewModel : MainViewModel
    {
        private string _SelectedFile;
        public string SelectedFile 
        { 
            get { return _SelectedFile; }
            set { _SelectedFile = value; }
        }

        private bool _IsReadOnly;
        public bool IsReadOnly
        {
            get { return _IsReadOnly; }
            set { _IsReadOnly = value; }
        }

        private bool _IsHidden;
        public bool IsHidden
        {
            get { return _IsHidden; }
            set { _IsHidden = value; }
        }

        private bool _IsArchive;
        public bool IsArchive
        {
            get { return _IsArchive; }
            set { _IsArchive = value; }
        }

        private bool _IsEncrypted;
        public bool IsEncrypted
        {
            get { return _IsEncrypted; }
            set { _IsEncrypted = value; }
        }


    }
}
