using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic
{
    public class MovementPhase : Phase
    {
        public MovementPhase(List<Player> players, Board b) :
            base("Movement")
        {
            _players = players;
            map = b;
        }

        private void movement()
        {
            this.beginPhase();

            foreach (Player p in _players)
            {
                //prompt to skip phase?
                //if skip break;
                
            }

            this.endPhase();
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
                    if(_t.isRough() && moveleft >= 2)
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
            foreach(Tile t in map.getMap())
            {
                if(t.getHexNum() == n)
                    return t;
            }
        }
        
        private void resetMovementLogic()
        {
            foreach(Tile t in map.getMap())
            {
                t.resetMovementLogic();
            }
        }

        private List<Player> _players;
        private Board map;
    }
}
