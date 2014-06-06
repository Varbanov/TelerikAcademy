namespace CohesionAndCoupling
{
    using System;

    public static class FilenameUtils
    {
        public static string GetFileExtension(string fileName)
        {
            int indexOfLastDot = fileName.LastIndexOf(".");
            if (indexOfLastDot == -1)
            {
                throw new ArgumentException("The file extension cannot be extraced: no dot is found in the name");
            }

            string extension = fileName.Substring(indexOfLastDot + 1);
            return extension;
        }

        public static string GetFileNameWithoutExtension(string fileName)
        {
            int indexOfLastDot = fileName.LastIndexOf(".");
            if (indexOfLastDot == -1)
            {
                throw new ArgumentException("Invalid filename: no dot is found in the name");
            }

            string extension = fileName.Substring(0, indexOfLastDot);
            return extension;
        }
    }
}
