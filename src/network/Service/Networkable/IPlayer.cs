using KNT_Service.Wrapper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace KNT_Service.Networkable
{
    [ServiceContract]
    public interface IPlayer
    {

        [OperationContract]
        string getName();

        [OperationContract]
        void setName(string n);

        [OperationContract]
        int getTurn();

        [OperationContract]
        void setTurn(int t);

        [OperationContract]
        int getDiceroll();

        [OperationContract]
        void setDiceroll(int roll);

        [OperationContract]
        List<Wrapper.Thing> getThingsInPlay();

        [OperationContract]
        Dictionary<int, Wrapper.Thing> getRack();

        [OperationContract]
        List<Wrapper.Tile> getOwnedTiles();

        [OperationContract]
        int getGold();

        [OperationContract]
        void setGoldValue(int value);

        [OperationContract]
        Point getDrawingPosition();

        [OperationContract]
        void setDrawingYPosition(int y);

        [OperationContract]
        Dictionary<int, bool> getMyMarkers();

        [OperationContract]
        bool containsMarkerID(int id);

        [OperationContract]
        void addMarkerID(int id);

        [OperationContract]
        int getCurrentMarkerID();

        [OperationContract]
        bool isHoldingMarker();

        [OperationContract]
        void setHandsFull();

        [OperationContract]
        bool isInPhase();

        [OperationContract]
        int getPlayerNumber();
    }
}