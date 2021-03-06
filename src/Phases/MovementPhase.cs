using GameLogic.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic.Phases
{
    public class MovementPhase : Phase
    {
        public MovementPhase() :
            base("Movement")
        {
            //map = GameBoard.Game.getMap();
        }

        public override void playPhase(List<Player> players)
        {
            _players = players;
            if (currentState != State.IN_PROGRESS)
            {
                beginPhase();
                resetStackMovement();
            }
            if (currentPlayer == null)
                currentPlayer = _players[0];

            movement();
        }

        private void movement()
        {

            if (currentPlayer.getInPhase())
            {
                changePlayer();
            }

            if (allDone())
                this.endPhase();
        }

        private void resetStackMovement()
        {
            foreach (Tile aTile in GameBoard.Game.getMap().getHexList())
            {
                for (int i = 0; i < 5; i++)
                {
                    aTile.movePossible[i] = true;
                }
            }
        }
        
        public void checkMovement(int hexNum, int moveLeft)
        {
            Tile currentTile = getTileFromNum(hexNum);
            currentTile.traversed = true;
            if(!currentTile.getFaceUp())
            {
                currentTile.flipTile();
                return;
            }
            if(moveLeft <= 0)
                return;
            foreach(int n in currentTile.getSurrounding())
            {
                Tile _t = getTileFromNum(n);
                if (_t != null)
                {
                    if (!_t.traversed)
                    {
                        if (_t.getType() != "Sea")
                        {
                            if (_t.isRough() && moveLeft >= 2)
                            {
                                checkMovement(n, moveLeft - 2);
                            }
                            else if( moveLeft >= 1)
                            {
                                checkMovement(n, moveLeft - 1);
                            }
                        }
                    }
                }
            }
        }
                
        private Tile getTileFromNum(int n)
        {
            map = GameBoard.Game.getMap();
            if(n == 0)
                return null;
            foreach (Tile t in map.getHexList())
            {
                if(t.getHexNum() == n)
                    return t;
            }

            return null;
        }
        
        private void resetMovementLogic()
        {
            foreach (Tile t in map.getHexList())
            {
                t.resetMovementLogic();
            }
        }

        public override Player getCurrentPlayer()
        {
            return currentPlayer;
        }

        private Board map;
    }
}
