namespace _03.StringsWcfService
{
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class StringsService : IStringsService
    {
        public int GetFirstStringOccurencesInSecondString(string firstString, string secondString)
        {
            int count = 0;
            int currentIndex = secondString.IndexOf(firstString);

            while (currentIndex >= 0)
            {
                count++;
                currentIndex = secondString.IndexOf(firstString, currentIndex + 1);
            }

            return count;
        }
    }
}
