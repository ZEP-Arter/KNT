using GameLogic.Managers;
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
            towersSet = false;
            towerPlacementPhase = false;
        }

        public override void playPhase(List<Player> players)
        {
            _players = players;
            if( currentPlayer == null)
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
            else if (!towersSet)
                towersSet = placeStartingTower();
            //else if (!fortSet)
            //check to see if everyone has finised their turn
            if (allDone())
                endPhase();
        }

        private bool placeStartingTower()
        {
            towerPlacementPhase = true;
            if (_players.IndexOf(currentPlayer) == _players.Capacity - 1 &&
                currentPlayer.towerPlaced == 1)
            {
                foreach (Player p in _players)
                    p.donePhase();
                changePlayer();
                return true;
            }
            else if (_players.IndexOf(currentPlayer) != _players.Capacity - 1 &&
                currentPlayer.towerPlaced == 1)
            {
                currentPlayer.donePhase();
                changePlayer();
                return false;
            }
            return false;
        }

        private bool placeStartingMarkers()
        {
            if (_players.IndexOf(currentPlayer) == _players.Capacity - 1 &&
                currentPlayer.placedAllMarkers())
            {
                Console.WriteLine("4th");
                //foreach (Player p in _players)
                    //p.donePhase();
                changePlayer();
                return true;
            }
            else if (_players.IndexOf(currentPlayer) != _players.Capacity - 1 &&
                currentPlayer.placedCurrentMarker())
            {
                if (currentPlayer.placedAllMarkers())
                {
                    Console.WriteLine("Once");
                    currentPlayer.donePhase();
                }
                changePlayer();
                return false;
            }
            else if (_players.IndexOf(currentPlayer) == _players.Capacity - 1 &&
                currentPlayer.placedCurrentMarker())
            {
                changePlayer();
                return false;
            }

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
                {
                    currentPlayer = GameBoard.Game.getPlayers()[0];
                    return true;
                }
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
             markersSet,
             towersSet,
             towerPlacementPhase;

        public bool getTowerPlacementPhase()
        { return towerPlacementPhase; }
    }
}
