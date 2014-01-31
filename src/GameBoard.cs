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
				initBank();
                // init cup
                // init players ( this may need a lot of logic )
                // init board
            }

			private void initBank()
			{
				initSpecialCharacters();
			}

			private void initSpecialCharacters()
			{
				string type = "SpecialCharacters";
				
				if( !bank.ContainsKey(type) )
				{
					bank.Add(type, new List<Things>());
				}
				
				List<Things> sc = bank[type];
				List<Attributes> attr = new List<Attributes>();
				
				sc.Add(new SpecialCharacter("Sword Master", "", 4, attr));
				
				//MAGIC\\
				
				attr.Add(Attributes.MAGIC);
				
				//ctor for special characters (name, path_to_image, combat_score, list_of_attributes)
				
				sc.Add(new SpecialCharacter("Arch Cleric", "", 5, attr));
				
				sc.Add(new SpecialCharacter("Arch Mage", "", 6, attr));
				
				//SPECIAL\\
				
				attr.clear();
				
				attr.Add(Attributes.SPECIAL);
				
				sc.Add(new SpecialCharacter("Assassin Primus", "", 4, attr));
				
				sc.Add(new SpecialCharacter("Baurn Munchausen", "", 4, attr));
				
				sc.Add(new SpecialCharacter("DeerHunter", "", 4, attr));
				
				sc.Add(new SpecialCharacter("Desert Master", "", 4, attr));
				
				sc.Add(new SpecialCharacter("Dwarf King", "", 5, attr));
				
				sc.Add(new SpecialCharacter("Forest King", "", 4, attr));
				
				sc.Add(new SpecialCharacter("Grand Duke", "", 4, attr));
				
				sc.Add(new SpecialCharacter("Ice Lord", "", 4, attr));
				
				sc.Add(new SpecialCharacter("Jungle Lord", "", 4, attr));
				
				sc.Add(new SpecialCharacter("Master Thief", "", 4, attr));
				
				sc.Add(new SpecialCharacter("Mountain King", "", 4, attr));
				
				sc.Add(new SpecialCharacter("Plains Lord", "", 4, attr));
				
			    sc.Add(new SpecialCharacter("Swamp King", "", 4, attr));
			
				sc.Add(new SpecialCharacter("Warlord", "", 5, attr));
				
				//RANGED\\
				
				attr.clear();
				
				attr.Add(Attributes.RANGED);
				
				sc.Add(new SpecialCharacter("Elf Lord", "", 6, attr));
				
				sc.Add(new RangedCharacter("Marksman", "", 5, attr, 2));
				
				//FLYING\\
				
				attr.clear();
				
				attr.Add(Attributes.FLYING);
				
				sc.Add(new SpecialCharacter("Ghaog II", "", 6, attr));
				
				sc.Add(new SpecialCharacter("Lord of the Eagles", "", 5, attr));
				
				//CHARGE\\
				
				attr.clear();
				
				attr.Add(Attributes.CHARGE);
				
				sc.Add(new SpecialCharacter("Sir Lance-a-Lot", "", 5, attr));
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