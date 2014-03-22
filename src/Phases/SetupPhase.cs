using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic.Phases
{
    public class SetupPhase : Phase
    {
        public SetupPhase() :
            base("Setup")
        {
            positionsSet = false;
            markersSet = false;
        }

        public override void playPhase(KNT_Client.Networkable.Player player)
        {
            _player = player;
            if( currentState != State.IN_PROGRESS )
                beginPhase();
            setup();
        }

        private void setup()
        {
            //roll to see how places first
            if (!positionsSet)
                positionsSet = setPositions();
            //place starting markers
            else if (!markersSet)
                markersSet = placeStartingMarkers();
            //else if (!fortSet)
            //check to see if everyone has finised their turn
            if( positionsSet && markersSet )
                endPhase();
        }

        private bool placeStartingMarkers()
        {
            if ( _player.placedAllMarkers() )
            {
                _player.donePhase();
                return true;
            }

            return false;
        }

        private bool setPositions()
        {

            if (GameLogic.Managers.PlayerManager.PManager.setPlayerOrder()) ;

            //this function will need to change based more on how things go in networking

            return false;
        }

        bool positionsSet,
             markersSet;
    }
}
