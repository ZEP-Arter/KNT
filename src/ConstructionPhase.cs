using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic
{
    public class ConstructionPhase : Phase
    {
        public ConstructionPhase() :
            base("Construction")
        {
            
        }

        public override void playPhase(List<Player> players)
        {
            _players = players;
            if (currentState != State.IN_PROGRESS)
                beginPhase();
            if (currentPlayer == null)
                currentPlayer = _players[0];
            if (currentPlayer.getInPhase())
            {
                changePlayer();
            }

            if (allDone())
            {
                checkWinner();
                builtCitadel = false;
                this.endPhase();
            }
        }

        private void checkWinner()
        {
            int c = 0;
            if (builtCitadel == false)
            {
                for (int i = 0; i < 37; i++)
                {
                    if (GameBoard.Game.getMap().getHexList()[i].getFort() == 4)
                        c++;
                }
                if (c == 1)
                {
                    //Player win
                    //if (GameBoard.Game.getMap().getHexList()[i].getFort() == 4)
                    //GameBoard.Game.win(GameBoard.Game.getMap().getHexList()[i].getPlayer());
                }
            }
        }

        public void citadelBuilt()
        { builtCitadel = true; }

        bool builtCitadel = false;

        public override Player getCurrentPlayer()
        {
            return currentPlayer;
        }
    }
}
