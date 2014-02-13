using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;
using KNT_Service; 

namespace KNT_Game
{
    class KNT_Net_Host
    {
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:15608/KNTNet.svc");

            ServiceHost selfHost = new ServiceHost(typeof(KNTNet), baseAddress);

            try
            {
                selfHost.AddServiceEndpoint(typeof(IKNTNet), new BasicHttpBinding(), "KNT");

                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                selfHost.Description.Behaviors.Add(smb);

                selfHost.Open();
                Console.WriteLine("The Service is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.WriteLine();
                Console.ReadLine();

                selfHost.Close();
            }
            catch (CommunicationException ex)
            {
                Console.WriteLine("An Exception ocurred: {0}", ex.Message);
                selfHost.Abort();
            }
        }
    }
}
