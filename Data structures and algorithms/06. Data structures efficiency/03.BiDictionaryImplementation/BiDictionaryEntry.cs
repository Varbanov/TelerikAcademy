namespace _03.BiDictionaryImplementation
{
    using System;

    public class BiDictionaryEntry
    {
        static void Main()
        {
            var dict = new BiDictionary<string, int, string>();

            dict.Add("pesho", 1, "rabbit");
            dict.Add("bai ivan", 2, "frog");
            dict.Add("maria", 3, "bat");
            dict.Add("maria", 2, "donkey");
            dict.Add("pesho", 3, "bear");
            dict.Add("bai ivan", 1, "hippo");

            var peshos = dict.FindByKey1("pesho");

            foreach (var item in peshos)
            {
                Console.WriteLine(item);
            }

            var marias = dict.FindByKey1AndKey2("maria", 3);

            foreach (var item in marias)
            {
                Console.WriteLine(item);
            }

        }


    }
}
