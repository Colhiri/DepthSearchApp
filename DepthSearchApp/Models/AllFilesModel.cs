using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace DepthSearchApp.Models
{
    /// <summary>
    /// Модель основного окна
    /// </summary>
    public class AllFilesModel : MainModel
    {
        /// <summary>
        /// Получить файлы из директории
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private List<string> AddFiles(string path) => Directory.GetFiles(path).ToList();

        /// <summary>
        /// Получить сабдиректории из выбранной директории
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private List<string> AddDirectories(string path) => Directory.GetDirectories(path).ToList();

        /// <summary>
        /// Сохранение всех найденных директорий
        /// </summary>
        private List<string> listDir = new List<string>();

        /// <summary>
        /// Сохранение всех найденных файлов
        /// </summary>
        private List<string> listFiles = new List<string>();

        /// <summary>
        /// Счетчик директорий для продвижения по листу
        /// </summary>
        private int CountDir = 0;

        /// <summary>
        /// Рекурсивный поиск всех файлов в директориях
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private List<string> RecursiveAllFiles(string path)
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

        /// <summary>
        /// Проверка существования пути
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        public bool ValidationPath(string Path)
        {
            return Directory.Exists(Path);
        }

        /// <summary>
        /// Поиск файлов
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        public ReadOnlyObservableCollection<string> SearchFiles(string Path)
        {
            if (ValidationPath(Path))
            {
                List<string> AllFiles = RecursiveAllFiles(Path);
                return new ReadOnlyObservableCollection<string>(new ObservableCollection<string>(AllFiles));
            }
            return null;
        }
    }
}
