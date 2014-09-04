using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.FileTree
{
    public class Folder
    {
        private List<File> files = new List<File>();
        private List<Folder> folders = new List<Folder>();
        public Folder(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public File[] Files
        {
            get
            {
                return this.files.ToArray();
            }
        }

        public Folder[] ChildFolders
        {
            get
            {
                return this.folders.ToArray();
            }
        }

        public void AddFile(File file)
        {
            this.files.Add(file);
        }

        public void AddFolder(Folder folder)
        {
            this.folders.Add(folder);
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
