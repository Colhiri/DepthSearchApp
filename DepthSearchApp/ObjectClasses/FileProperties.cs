using System;

namespace DepthSearchApp.ObjectClasses
{
    public class FileProperties
    {
        public string FileName;
        public bool IsReadOnly;
        public bool IsHidden;
        public bool IsArchive;
        public bool IsEncrypted;
        public DateTime CreateDate;
        public DateTime EditDate;
        public string Author;
        public string Title;

        public FileProperties(string SelectedFile)
        {

        }

    }
}