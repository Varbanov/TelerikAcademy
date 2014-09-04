namespace _02.TraverseWindowsDirectories
{
    using System;
    using System.IO;
    using System.Text;

    public class TraverseDirectoriesEngine
    {
        private void GetExeFilesFromFolder(string path)
        {
            StringBuilder output = new StringBuilder();

            string[] files = Directory.GetFiles(path, @"*.exe");

            for (int i = 0; i < files.Length; i++)
            {
                output.AppendLine(files[i]);
            }

            Console.Write(output.ToString());
        }

        public void GetNestedDirectories(string path)
        {
            try
            {
                this.GetExeFilesFromFolder(path);
                string[] nestedFolders = Directory.GetDirectories(path);

                if (nestedFolders.Length == 0)
                {
                    //bottom of recursion
                    return;
                }

                for (int i = 0; i < nestedFolders.Length; i++)
                {
                    //execute the same for all nested directories
                    this.GetNestedDirectories(nestedFolders[i]);
                }

            }
            catch (System.UnauthorizedAccessException)
            {
                Console.WriteLine("Could not access folder {0}!",  path);
                return;
            }
        }
    }
}
