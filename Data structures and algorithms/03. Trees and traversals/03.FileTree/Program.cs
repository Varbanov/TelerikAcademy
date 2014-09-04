using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.FileTree
{
    class Program
    {
        static void Main()
        {
            string rootDir = @"D:\desktop";
            Folder winFolder = new Folder("desktop");
            FillDirectoryTree(rootDir, winFolder);
            PrintSize(winFolder);
        }

        private static void PrintSize(Folder folder)
        {
            long folderSize = GetSize(folder);
            Console.WriteLine("Total size of {0} folder is {1} bytes.", folder.Name, folderSize);
        }

        private static long GetSize(Folder folder)
        {
            long totalSize = 0;
            CalculateSize(folder, ref totalSize);
            return totalSize;
        }

        private static void CalculateSize(Folder folder, ref long totalSize)
        {
            foreach (var file in folder.Files)
            {
                totalSize += file.Size;
            }

            foreach (var dir in folder.ChildFolders)
            {
                CalculateSize(dir, ref totalSize);
            }
        }

        private static void FillDirectoryTree(string path, Folder folder)
        {
            try
            {
                // add files
                var files = Directory.GetFiles(path);
                foreach (var file in files)
                {
                    string fileName = GetName(file);
                    FileInfo fileInfo = new FileInfo(file);
                    folder.AddFile(new File(fileName, fileInfo.Length));
                }

                // repeat for nested directories
                var directories = Directory.GetDirectories(path);
                foreach (var dir in directories)
                {
                    string dirName = GetName(dir);
                    Folder newFolder = new Folder(dirName);
                    folder.AddFolder(newFolder);
                    FillDirectoryTree(dir, newFolder);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static string GetName(string dirName)
        {
            int slash = dirName.LastIndexOf('\\') + 1;
            string fileName = dirName.Substring(slash, dirName.Length - slash);
            return fileName;
        }
    }
}
