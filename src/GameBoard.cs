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

            public Things getRanodmThingFromCup()
            {
                Random r = new Random();

                int nxt = r.Next(playingCup.Count);

                Things retVal = playingCup[nxt];

                removeFromCup(retVal);

                return retVal;
            }

            public Things getThingFromBank(string type)
            {
                Things thing = bank[type][0];

                removeFromBank(type, thing);

                return thing;
            }
		
		//private
		
			//ctor
			private GameBoard () 
            {
                theBoard = new Board();
                players = new List<Player>(4);
                init();
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

            private void removeFromBank(string type, Things thing)
            {
                bank[type].Remove(thing);
            }

            private void removeFromCup(Things thing)
            {
                playingCup.Remove(thing);
            }

            private void init()
            {
                //init things, characters, gold and other things that need to be set up. ie . the board, the bank, the playing cup (whatever that is :p)
                // init bank
                // init cup
                // init players ( this may need a lot of logic )
                // init board
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
            private Dictionary<string, List<Things>> bank;
		
			// the Playing cup // IMPORTANT, this musn't be sorted!! // its random :)
            private List<Things> playingCup;
		
		
	} // end GameBorad Class

} // end namespace