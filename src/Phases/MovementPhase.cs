using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameLogic.Managers;

namespace GameLogic.Phases
{
    public class MovementPhase : Phase
    {
        public MovementPhase() :
            base("Movement")
        {
            //map = GameBoard.Game.getMap();
        }

        public override void playPhase(KNT_Client.Networkable.Player player)
        {
            _player = player;

            if (currentState != Phase.State.IN_PROGRESS)
                this.beginPhase();

            movement();
        }

        private void movement()
        {
        }
        
        public void checkMovement(int hexNum, int moveLeft)
        {
            //Tile currentTile = getTileFromNum(hexNum);
            //currentTile.traversed = true;
            //if(!currentTile.getFaceUp())
            //{
            //    currentTile.flipTile();
            //    return;
            //}
            //if(moveLeft <= 0)
            //    return;
            //foreach(int n in currentTile.getSurrounding())
            //{
            //    Tile _t = getTileFromNum(n);
            //    if(_t == null)
            //        break;
            //    if(!_t.traversed)
            //    {
            //        if(_t.isRough() && moveLeft >= 2)
            //        {
            //            checkMovement(n, moveLeft-2);
            //        }
            //        checkMovement(n, moveLeft-1);
            //    }
            //}
        }

        private KNT_Client.Networkable.Tile getTileFromNum(int n)
        {
            //map = GameBoard.Game.getMap();
            //if(n == 0)
            //    return null;
            //foreach (Tile t in map.getHexList())
            //{
            //    if(t.getHexNum() == n)
            //        return t;
            //}

            return null;
        }
        
        private void resetMovementLogic()
        {
            //foreach (Tile t in map.getHexList())
            //{
            //    t.resetMovementLogic();
            //}
        }

        private Board map;
    }
}
