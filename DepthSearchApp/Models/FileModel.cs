using Microsoft.VisualBasic.FileIO;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace DepthSearchApp.Models
{
    /// <summary>
    /// Viewmodel selected file
    /// </summary>
    public class FileModel : MainModel
    {
        private string GetDirectory(string path) => Path.GetDirectoryName(path);

        #region Get Parameter File
        /// <summary>
        /// Файл только для чтения?
        /// </summary>
        public bool GetFileIsReadOnly(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            return fileInfo.IsReadOnly;
        }

        /// <summary>
        /// Файл скрыт?
        /// </summary>
        public bool GetFileIsHidden(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            // FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(path);
            // FileSystemInfo fileSystemInfo = fileInfo as FileSystemInfo;
            return fileInfo.Attributes.HasFlag(FileAttributes.Hidden);
        }

        /// <summary>
        /// Файл готов для архивирования?
        /// </summary>
        public bool GetFileIsArchive(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            return fileInfo.Attributes.HasFlag(FileAttributes.Archive);
        }

        /// <summary>
        /// Файл зашифрован?
        /// </summary>
        public bool GetFileIsEncrypted(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            return fileInfo.Attributes.HasFlag(FileAttributes.Encrypted);
        }

        /// <summary>
        /// Краткое имя файла
        /// </summary>
        public string GetFileName(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            return fileInfo.Name;
        }

        /// <summary>
        /// Краткое имя файла
        /// </summary>
        public string GetFileCompanyName(string path)
        {
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(path);
            return fileVersionInfo.CompanyName;
        }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime GetFileDateCreation(string path)
        {
            return DateTime.Now;
        }

        /// <summary>
        /// Дата изменения
        /// </summary>
        public DateTime GetFileDateEditing(string path)
        {
            return DateTime.Now;
        }
        #endregion

        #region Edit Parameter
        private bool CheckFileAttribute(string path, FileAttributes attr) => File.GetAttributes(path) == attr;

        public void SetIsReadOnly(string path, bool value)
        {
            FileInfo fileInfo = new FileInfo(path);
            if (fileInfo.IsReadOnly != value) fileInfo.IsReadOnly = value;
        }

        public void SetIsHidden(string path, bool value)
        {
            if (value == CheckFileAttribute(path, FileAttributes.Hidden)) return; 
            File.SetAttributes(path, FileAttributes.Hidden);
        }

        public void SetIsArchive(string path, bool value)
        {
            if (value == CheckFileAttribute(path, FileAttributes.Archive)) return;
            File.SetAttributes(path, FileAttributes.Archive);
        }

        public void SetIsEncrypted(string path, bool value)
        {
            if (value == CheckFileAttribute(path, FileAttributes.Encrypted)) return;
            File.SetAttributes(path, FileAttributes.Encrypted);
        }

        public void SetFileName(string path, string NewName)
        {
            FileInfo fileInfo = new FileInfo(path);
            if (fileInfo.Name == NewName) return;
            FileSystem.RenameFile(fileInfo.FullName, NewName);
        }

        public void SetDateCreation(string path, DateTime NewDateCreation)
        {

        }

        public void SetDateEditing(string path, DateTime NewDateCreation)
        {

        }
        #endregion
    }
}
