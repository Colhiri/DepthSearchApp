using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace CKAD
{
    public class Program
    {
        public static List<string> FilesInDirectories(string path) => Directory.GetFileSystemEntries(path).ToList();
        public static List<string> AddFiles(string path) => Directory.GetFiles(path).ToList();
        public static List<string> AddDirectories(string path) => Directory.GetDirectories(path).ToList();
        public static List<string> listDir = new List<string>() { };
        public static List<string> listFiles = new List<string>();
        public static int CountDir = 0;

        public static List<string> RecursiveAllFiles(string path)
        {
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

        public static void TEST(string[] args)
        {
            string pathToSave = @"c:\Users\kabanov\source\repos\DecompileGS\DecompileGS\";
            string pathToDir = @"c:\Program Files\Autodesk\";
            listDir.Add(pathToDir);
            List<string> AllFiles = RecursiveAllFiles(pathToDir);
            // bool check = NamesFiles.Contains(@"C:\Program Files\Autodesk\AutoCAD 2019\PointCAD.GS.Series.UI.dll");

            List<FileVersionInfo> filesMG = AllFiles.AsParallel()
                                                    .WithDegreeOfParallelism(6)
                                                    .Select(x => FileVersionInfo.GetVersionInfo(x))
                                                    .Where(x => (x.ProductName == "GS.Series" || x.ProductName == "GeoSolution" || x.CompanyName == "PointEng"))
                                                    .ToList();

            // List<FileVersionInfo> files = AllFiles.Select(x => FileVersionInfo.GetVersionInfo(x)).Where(x => (x.ProductName == "GS.Series" || x.ProductName == "GeoSolution" || x.CompanyName == "PointEng")).ToList();
            /*
            foreach (string filePath in AllFiles)
            {
                FileInfo fileInfo = new FileInfo(filePath);
                FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(filePath);
                if (versionInfo.ProductName == "GeoSolution" || versionInfo.CompanyName == "PointEng")
                {
                    pathFilesGS.Add(filePath);
                    // File.Copy(filePath, String.Concat(pathToSave, fileInfo.Name), true);
                }
            }
            */

            Console.WriteLine();
        }
    }

}

