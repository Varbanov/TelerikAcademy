namespace _02.TraverseWindowsDirectories
{
    public class TraverseDirectoriesEntryPoint
    {
        public static void Main()
        {
            TraverseDirectoriesEngine traverser = new TraverseDirectoriesEngine();
            traverser.GetNestedDirectories(@"C:\Windows");
        }
    }
}
