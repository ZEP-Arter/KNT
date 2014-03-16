using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KNT_Client.KNT_ServiceReference;

namespace KNT_Client
{
    public class ClientImplementation
    {
        public static void Main(string[] args)
        {
            KNTNetClient client = new KNTNetClient();

            client.connect("Eric");

            client.Close();
        }

    }
}
