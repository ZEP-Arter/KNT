using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic
{
    public class SetupPhase : Phase
    {
        public SetupPhase() :
            base("Setup")
        {
            positionsSet = false;
            markersSet = false;
        }

        public override void playPhase(List<Player> players)
        {
            _players = players;
            if( currentPlayer == null || positionsSet)
                currentPlayer = _players[0];
            if( currentState != State.IN_PROGRESS )
                beginPhase();
            setup();
        }

        public override Player getCurrentPlayer()
        {
            return currentPlayer;
        }

        private void setup()
        {
            //roll to see how places first
            if (!positionsSet)
                positionsSet = setPositions();
            //place starting markers
            else if (!markersSet)
                markersSet = placeStartingMarkers();
            //check to see if everyone has finised their turn
            else if( allDone() )
                endPhase();
        }

        private bool placeStartingMarkers()
        {
            if (_players.IndexOf(currentPlayer) != _players.Capacity - 1 &&
                !currentPlayer.placedAllMarkers())
            {
                changePlayer();
                return false;
            }
            else if (_players.IndexOf(currentPlayer) == _players.Capacity - 1 &&
                currentPlayer.placedAllMarkers())
            {
                currentPlayer.donePhase();
                return true;
            }

            changePlayer();

            return false;
        }

        private bool setPositions()
        {
            if (_players.IndexOf(currentPlayer) != _players.Capacity - 1 &&
                currentPlayer.getDiceRoll() != 0)
            {
                changePlayer();

                return false;
            }
            else if (_players.IndexOf(currentPlayer) == _players.Capacity - 1 &&
                currentPlayer.getDiceRoll() != 0)
            {
                if (GameBoard.Game.setPlayerOrder())
                    return true;
                else
                {
                    //retry rolls
                    foreach (Player p in _players)
                        p.setDiceRoll(0);
                    currentPlayer = _players[0];
                    return false;
                }
            }

            return false;
        }

        bool positionsSet,
             markersSet;
    }
}
