using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace DepthSearchApp.Models
{
    public class AllFilesModel : MainModel
    {
        private static List<string> FilesInDirectories(string path) => Directory.GetFileSystemEntries(path).ToList();
        private static List<string> AddFiles(string path) => Directory.GetFiles(path).ToList();
        private static List<string> AddDirectories(string path) => Directory.GetDirectories(path).ToList();
        private static List<string> listDir = new List<string>() { };
        private static List<string> listFiles = new List<string>();
        private static int CountDir = 0;

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
    }
}
