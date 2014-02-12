using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic
{
    public class MovementPhase : Phase
    {
        public MovementPhase() :
            base("Movement")
        {
            map = GameBoard.Game.getMap();
        }

        public override void playPhase(List<Player> players)
        {
            _players = players;
        }

        private void movement()
        {
            this.beginPhase();

            foreach (Player p in _players)
            {
                //prompt to skip phase?
                //if skip break;
                
            }
            if (allDone())
                endPhase();
        }
        
        private void checkMovement(int hexNum, int moveLeft)
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
                if(_t == null)
                    break;
                if(!_t.traversed)
                {
                    if(_t.isRough() && moveLeft >= 2)
                    {
                        checkMovement(n, moveLeft-2);
                    }
                    checkMovement(n, moveLeft-1);
                }
            }
        }
                
        private Tile getTileFromNum(int n)
        {
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
            return null;
        }

        private List<Player> _players;
        private Board map;
    }
}
