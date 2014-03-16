using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace KNT_Service.Networkable
{
    [ServiceContract]
    public interface IBoard
    {
        [OperationContract]
        List<Wrapper.Tile> getHexList();
    }
}