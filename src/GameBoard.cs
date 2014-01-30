using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic
{

	class GameBoard
	{
		
		// @ericadamski : I think this should be a singleton.
		
		//public
		
			public GameBoard getGame() { return game; }
		
			public void createGame(string hostName) 
            { 
                game = new GameBoard();

                addPlayer(hostName);

                currentPlayer = players[0];
            }

            public void play() { }

            public void addPlayer(string name)
            {
                if (players.Count == 0)
                    players.Add(new Player(name));
                else
                    players.Add(new Player(name, NetworkPosition.CLIENT));
            }
		
		//private
		
			//ctor
			private GameBoard () 
            {
                theBoard = new Board();
                players = new List<Player>(4);
            }

            private void playTurn( Player p )
            {
                    
            }

            private void nextTurn()
            {
                foreach (Player p in players)
                {
                    if (p.getTurn() == (currentPlayer.getTurn() + 1))
                    {
                        playTurn(p);
                        break;
                    }
                }
            }
		
		// private members
		
			// singleton Access
			private GameBoard game;
		
			// List of Players
            List<Player> players;
		
			// Board Obj
            private Board theBoard;

            // person who is currently playing their turn
            private Player currentPlayer;
		
			// the Bank
			//
		
			// the Playing cup
			//
		
		
	} // end GameBorad Class

} // end namespace