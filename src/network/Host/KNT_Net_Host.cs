using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;
using KNT_Service; 

namespace KNT_Host
{
    public interface KNT_Net_Host
    {
        void CreateGame();
        void Poll();
        void UpdateGame(); // <- this might be the function that does the notification ( like the observer DP )
    }
}
