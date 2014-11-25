namespace _03.StringsWcfService
{
    using System.ServiceModel;

    [ServiceContract]
    public interface IStringsService
    {
        [OperationContract]
        int GetFirstStringOccurencesInSecondString(string firstString, string secondString);
    }
}
