namespace _05.SetImplementation
{
    using System;
    using System.Collections.Generic;
    //using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SetEntryPoint
    {
        public static void Main()
        {
            var set = new Set<string>();

            for (int i = 0; i < 12; i++)
            {
                set.Add("item" + i);
            }

            Console.WriteLine("Count: {0}", set.Count);
            foreach (var item in set)
            {
                Console.WriteLine(item);
            }
        }
    }
}
