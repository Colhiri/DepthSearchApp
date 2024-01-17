using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DepthSearchApp.Models
{
    public class AllFilesModel : INotifyPropertyChanged
    {
        public static List<string> FilesInDirectories(string path) => Directory.GetFileSystemEntries(path).ToList();
        public static List<string> AddFiles(string path) => Directory.GetFiles(path).ToList();
        public static List<string> AddDirectories(string path) => Directory.GetDirectories(path).ToList();
        public static List<string> listDir = new List<string>() { };
        public static List<string> listFiles = new List<string>();
        public static int CountDir = 0;

        public static List<string> RecursiveAllFiles(string path)
        {
            if (listDir.Count == 0)
            {
                listDir.Add(path);
            }
            List<string> result = AddDirectories(path);

            if (listDir.Count == CountDir)
            {
                return listFiles;
            }
            else
            {
                listDir = listDir.Concat(result).ToList();
                listFiles = listFiles.Concat(AddFiles(listDir[CountDir])).ToList();
                return RecursiveAllFiles(listDir[CountDir++]);
            }
        }

        public bool ValidationPath(string Path)
        {
            return Directory.Exists(Path);
        }

        public ReadOnlyObservableCollection<string> SearchFiles(string Path)
        {
            if (Directory.Exists(Path))
            {
                List<string> AllFiles = RecursiveAllFiles(Path);
                return new ReadOnlyObservableCollection<string>(new ObservableCollection<string>(AllFiles));
            }
            return null;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
