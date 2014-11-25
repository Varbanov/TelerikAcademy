namespace _04.HostStringsService.Console
{
    using _03.StringsWcfService;
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Description;

    class WcfStringsServiceHostMain
    {
        static void Main()
        {
            Console.WriteLine("Please run as administrator from bin/debug or run your Visual Studio with right click of mouse/Run as administrator!");

            // Please run as administrator from bin/debug or run your Visual Studio with right click of mouse/Run as administrator

            Uri serviceAddress = new Uri("http://localhost:1434/strings");
            ServiceHost selfHost = new ServiceHost(typeof(StringsService), serviceAddress);
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            selfHost.Description.Behaviors.Add(smb);

            using (selfHost)
            {
                selfHost.Open();
                System.Console.WriteLine("The service is started at endpoint " + serviceAddress);

                System.Console.WriteLine("Press [Enter] to exit.");
                System.Console.ReadLine();
            }
        }
    }
}
