using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace KNT_Service
{
    [DataContract]
    public class Phase
    {
        public Phase(GameLogic.Phase phase)
        {
            _phase = phase;
        }

        public Player getCurrentPlayer()
        {
            return _currentPlayer;
        }

        [DataMember]
        Player _currentPlayer;

        public string getName()
        {
            return _name;
        }

        [DataMember]
        string _name;

        private void syncronize()
        {
            //
        }

        GameLogic.Phase _phase;
    }
}