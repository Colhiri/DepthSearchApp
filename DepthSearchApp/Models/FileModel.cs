using Microsoft.VisualBasic.FileIO;
using Microsoft.WindowsAPICodePack.Shell;
using System;
using System.Diagnostics;
using System.IO;
using System.Security.AccessControl;

namespace DepthSearchApp.Models
{
    /// <summary>
    /// Viewmodel selected file
    /// </summary>
    public class FileModel : MainModel
    {
        private string PathSelectedFile;
        private ShellFile ShellSelectedFile;
        private FileInfo InfoSelectedFile;
        private FileVersionInfo VersionInfoSelectedFile;
        private FileAttributes AttributesSelectedFile;
        private string DirectoryName;

        public string FileName { get; private set; }
        public bool IsReadOnly { get; private set; }
        public bool IsHidden { get; private set; }
        public bool IsArchive { get; private set; }
        public bool IsEncrypted { get; private set; }
        public DateTime CreateDate { get; private set; }
        public DateTime EditDate { get; private set; }
        public DateTime AccessDate {  get; private set; }
        public string Author {get; private set;}
        public string Title {get; private set;}

        public string CompanyNameSelectedFile { get; private set;}
        public string VersionSelectedFile { get; private set; }

        public FileModel(string PathToFile)
        {
            this.PathSelectedFile = PathToFile;
            this.ShellSelectedFile = ShellFile.FromFilePath(PathToFile);
            this.InfoSelectedFile = new FileInfo(PathToFile);
            this.VersionInfoSelectedFile = FileVersionInfo.GetVersionInfo(PathToFile);
            this.AttributesSelectedFile = File.GetAttributes(PathToFile);
            this.DirectoryName = InfoSelectedFile.DirectoryName;

            this.FileName = InfoSelectedFile.Name;
            this.IsReadOnly = InfoSelectedFile.IsReadOnly;
            this.IsHidden = CheckFileAttribute(FileAttributes.Hidden);
            this.IsArchive = CheckFileAttribute(FileAttributes.Archive);
            this.IsEncrypted = CheckFileAttribute(FileAttributes.Encrypted);
            this.CreateDate = InfoSelectedFile.CreationTime;
            this.EditDate = InfoSelectedFile.LastWriteTime;
            this.AccessDate = InfoSelectedFile.LastAccessTime;
            this.Author = String.Join(" ", ShellSelectedFile.Properties.System.Author.Value).Trim();
            this.Title = ShellSelectedFile.Properties.System.Title.Value;

            this.CompanyNameSelectedFile = VersionInfoSelectedFile.CompanyName;
            this.VersionSelectedFile = VersionInfoSelectedFile.FileVersion;

        }

        private bool CheckFileAttribute(FileAttributes Attribute) => (AttributesSelectedFile & Attribute) == Attribute;
        private FileAttributes RemoveFileAttribute(FileAttributes Attribute) => AttributesSelectedFile & ~Attribute;
        private bool CheckValidFileName(string FileName) => FileName.IndexOfAny(Path.GetInvalidPathChars()) < 0 || File.Exists(DirectoryName + FileName);
        
        #region Get Parameter File
        #endregion

        #region Edit Parameter
        public void SetIsReadOnly(bool value)
        {
            if (IsReadOnly != value)
            { 
                InfoSelectedFile.IsReadOnly = value; 
                IsReadOnly = value;
            }
        }

        public void SetIsHidden(bool value)
        {
            if (value == IsHidden) return;
            switch (value)
            {
                case true:
                    {
                        File.SetAttributes(PathSelectedFile, File.GetAttributes(PathSelectedFile) | FileAttributes.Hidden);
                        break;
                    }
                case false:
                    {
                        FileAttributes newAttr = RemoveFileAttribute(FileAttributes.Hidden);
                        File.SetAttributes(PathSelectedFile, newAttr);
                        break;
                    }
            }
        }

        public void SetIsArchive(bool value)
        {
            if (value == IsArchive) return;
            switch (value) 
            {
                case true:
                {
                    File.SetAttributes(PathSelectedFile, FileAttributes.Archive);
                    break;
                }
                case false:
                {
                    FileAttributes newAttr = RemoveFileAttribute(FileAttributes.Archive);
                    File.SetAttributes(PathSelectedFile, newAttr);
                    break;
                }
            }
        }

        public void SetIsEncrypted(bool value)
        {
            if (value == IsEncrypted) return;
            switch (value)
            {
                case true:
                    {
                        File.Encrypt(PathSelectedFile);
                        break;
                    }
                case false:
                    {
                        File.Decrypt(PathSelectedFile);
                        break;
                    }
            }
        }

        public void SetFileName(string NewName)
        {
            if (FileName == NewName ) return;
            if (!CheckValidFileName(NewName)) return;
            FileSystem.RenameFile(PathSelectedFile, NewName);
        }

        public void SetDateCreation(DateTime NewDate)
        {
            InfoSelectedFile.CreationTime = NewDate;
        }

        public void SetDateEditing(DateTime NewDate)
        {
            InfoSelectedFile.LastWriteTime = NewDate;
        }

        public void SetDateAccess(DateTime NewDate)
        {
            InfoSelectedFile.LastAccessTime = NewDate;
        }

        public void SetAuthor(string NewAuthors)
        {
            string[] Authors = NewAuthors.Split(',');
            ShellSelectedFile.Properties.System.Author.Value = Authors;
        }

        public void SetTitle(string NewTitle)
        {
            ShellSelectedFile.Properties.System.Title.Value = NewTitle;
        }
        #endregion
    }
}
