namespace Singleton
{
    using System;
    using System.Collections.Generic;

    public class Subscriber : IInformable
    {
        public Subscriber()
        {
            this.Information = new List<string>();
        }

        public List<string> Information { get; private set; }
       
        public void Inform(string information)
        {
            this.Information.Add(information);
        }

        public void ShowAllInformation()
        {
            for (int i = 0; i < this.Information.Count; i++)
            {
                Console.WriteLine(this.Information[i]);
            }
        }
    }
}
