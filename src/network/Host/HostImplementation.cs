using KNT_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;

namespace KNT_Host
{
    public class HostImplementation : KNT_Net_Host
    {
        public void CreateGame()
        {
            baseAddress = new Uri("http://localhost:8888/KNTNet.svc");

            selfHost = new ServiceHost(typeof(KNTNet), baseAddress);

            Poll();
        }

        public void Poll()
        {
            try
            {
                //selfHost.AddServiceEndpoint(typeof(IKNTNet), new BasicHttpBinding(), "KNT");

                //ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                //smb.HttpGetEnabled = true;
                //selfHost.Description.Behaviors.Add(smb);

                selfHost.Open();

                Console.WriteLine("Service Started, <ENTER> to close.");
                Console.ReadLine();

                selfHost.Close();
            }
            catch (CommunicationException ex)
            {
                Console.WriteLine("An Exception ocurred: {0}", ex.Message);
                selfHost.Abort();
            }
        }

        public void UpdateGame()
        {
        }

        ServiceHost selfHost;
        Uri baseAddress;

        public static void Main(string[] args)
        {
            HostImplementation test = new HostImplementation();

            test.CreateGame();
        }
    }
}
