using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Threading;

namespace GameLogic.Managers
{
    [DataContract(IsReference=false)]
	public class GameBoard
	{
		
		//public
            
            public Phase play() 
            {
                return PhaseManager.PhManager.play();
            }

            public void addPlayer(string name)
            {
                Managers.PlayerManager.PManager.addPlayer(name);
            }

            public Player changePlayerName(string name)
            {
                return Managers.PlayerManager.PManager.changePlayerName(name);
            }

            public Thing getRandomThingFromCup()
            {
                return Managers.ThingManager.TManager.getRandomThingFromCup();
            }

            public Thing getThingFromBank(string type)
            {
                return Managers.ThingManager.TManager.getThingFromBank(type);
            }

            public bool setPlayerOrder()
            {
                return Managers.PlayerManager.PManager.setPlayerOrder();
            }

            public List<Player> getPlayers()
            {
                return Managers.PlayerManager.PManager.getPlayers();
            }

            public Phase getCurrentPhase()
            {
                return Managers.PhaseManager.PhManager.getCurrentPhase();
            }

            public Player getPlayer(string name)
            {
                return Managers.PlayerManager.PManager.getPlayer(name);
            }
		
		//private
		
			//ctor
			private GameBoard () 
            {
                theBoard = new Board();

                List<Player> players = Managers.PlayerManager.PManager.getPlayers();

                int n = 1;

                while (players.Count != players.Capacity)
                {
                   addPlayer(String.Format("Player {0}", n++));
                }

                init();
            }

            //private void playTurn(Phase phase)
            //{
            //    phase.playPhase(players);
            //}

            private void init()
            {
                //init things, characters, gold and other things that need to be set up. ie . the board, the bank, the playing cup (whatever that is :p)
                // init bank
				initBank();
                // init cup
                initCup();
                // init players ( this may need a lot of logic )
                // init board
                theBoard.initBoard();
            }

			private void initBank()
			{
				TestCode.initSpecialCharacters(Managers.ThingManager.TManager.getBank());
			}
        
            private void initCup()
            {
                TestCode.initCreatures(Managers.ThingManager.TManager.getCup());   
            }

            public Board getMap() { return theBoard; }
		
		// private members

            [DataMember]
            private static Semaphore gSemaphore = new Semaphore(1, 1);

            [DataMember]
            private static GameBoard game;

            [DataMember]
            public static GameBoard Game
            {
                get
                {
                    gSemaphore.WaitOne();

                    if (game == null)
                        game = new GameBoard();

                    gSemaphore.Release();

                    return game;
                }
            }
		
			// Board Obj
            [DataMember]
            Board theBoard;
		
		
	} // end GameBorad Class    
    
    [DataContract]
    static class TestCode
    {
        public static void initSpecialCharacters(Dictionary<string, List<Thing>> bank)
        {
            string type = "SpecialCharacters";

            if (!bank.ContainsKey(type))
            {
                bank.Add(type, new List<Thing>());
            }

            List<Thing> sc = bank[type];
            List<Attributes.CombatAttributes> attr = new List<Attributes.CombatAttributes>();

            sc.Add(new SpecialCharacter("Sword Master", 4, attr));

            //MAGIC\\

            attr.Add(Attributes.CombatAttributes.MAGIC);

            //ctor for special characters (name, path_to_image, combat_score, list_of_attributes)

            sc.Add(new SpecialCharacter("Arch Cleric", 5, attr));

            sc.Add(new SpecialCharacter("Arch Mage", 6, attr));

            //SPECIAL\\

            attr.Clear();

            attr.Add(Attributes.CombatAttributes.SPECIAL);

            sc.Add(new SpecialCharacter("Assassin Primus", 4, attr));

            sc.Add(new SpecialCharacter("Baurn Munchausen", 4, attr));

            sc.Add(new SpecialCharacter("DeerHunter", 4, attr));

            sc.Add(new SpecialCharacter("Desert Master", 4, attr));

            sc.Add(new SpecialCharacter("Dwarf King", 5, attr));

            sc.Add(new SpecialCharacter("Forest King", 4, attr));

            sc.Add(new SpecialCharacter("Grand Duke", 4, attr));

            sc.Add(new SpecialCharacter("Ice Lord", 4, attr));

            sc.Add(new SpecialCharacter("Jungle Lord", 4, attr));

            sc.Add(new SpecialCharacter("Master Thief", 4, attr));

            sc.Add(new SpecialCharacter("Mountain King", 4, attr));

            sc.Add(new SpecialCharacter("Plains Lord", 4, attr));

            sc.Add(new SpecialCharacter("Swamp King", 4, attr));

            sc.Add(new SpecialCharacter("Warlord", 5, attr));

            //RANGED\\

            attr.Clear();

            attr.Add(Attributes.CombatAttributes.RANGED);

            sc.Add(new SpecialCharacter("Elf Lord", 6, attr));

            sc.Add(new RangedCharacter("Marksman", 5, attr, 2));

            //FLYING\\

            attr.Clear();

            attr.Add(Attributes.CombatAttributes.FLYING);

            sc.Add(new SpecialCharacter("Ghaog II", 6, attr));

            sc.Add(new SpecialCharacter("Lord of the Eagles", 5, attr));

            //CHARGE\\

            attr.Clear();

            attr.Add(Attributes.CombatAttributes.CHARGE);

            sc.Add(new SpecialCharacter("Sir Lance-a-Lot", 5, attr));
        }

        public static void initCreatures( List<Thing> playingCup )
        {
            List<Attributes.CombatAttributes> attr = new List<Attributes.CombatAttributes>();

            playingCup.Add(new Creature("Goblin", "Mountain", 1, attr));
            playingCup.Add(new Creature("Goblin", "Mountain", 1, attr));
            playingCup.Add(new Creature("Goblin", "Mountain", 1, attr));
            playingCup.Add(new Creature("Goblin", "Mountain", 1, attr));
            playingCup.Add(new Creature("Dwarves", "Mountain", 3, attr)); //Charge
            playingCup.Add(new Creature("Dwarves", "Mountain", 2, attr)); //Ranged
            playingCup.Add(new Creature("Dwarves", "Mountain", 3, attr)); //Ranged
            playingCup.Add(new Creature("Troll", "Mountain", 4, attr));
            playingCup.Add(new Creature("Great Eagle", "Mountain", 2, attr)); //Flying
            playingCup.Add(new Creature("Brown Dragon", "Mountain", 3, attr)); //Flying
            playingCup.Add(new Creature("Mountain Men", "Mountain", 1, attr));
            playingCup.Add(new Creature("Mountain Men", "Mountain", 1, attr));
            playingCup.Add(new Creature("Giant Roc", "Mountain", 3, attr)); //Flying
            playingCup.Add(new Creature("Giant Condor", "Mountain", 3, attr)); //Flying
            playingCup.Add(new Creature("Cyclops", "Mountain", 5, attr));
            playingCup.Add(new Creature("Giant Hawk", "Mountain", 1, attr)); //Flying
            playingCup.Add(new Creature("Ogre", "Mountain", 2, attr));
            playingCup.Add(new Creature("Brown Knight", "Mountain", 4, attr)); //Charge
            playingCup.Add(new Creature("Little Roc", "Mountain", 2, attr)); //Flying
            playingCup.Add(new Creature("Giant", "Mountain", 4, attr)); //Ranged
            playingCup.Add(new Creature("Mountain Lion", "Mountain", 2, attr));

            playingCup.Add(new Creature("Villains", "Plains", 2, attr));
            playingCup.Add(new Creature("Gypsies", "Plains", 2, attr)); //Magic
            playingCup.Add(new Creature("White Knight", "Plains", 3, attr)); //Charge
            playingCup.Add(new Creature("Tribesmen", "Plains", 2, attr));
            playingCup.Add(new Creature("Greathunter", "Plains", 2, attr)); //Ranged
            playingCup.Add(new Creature("Wolf Pack", "Plains", 3, attr));
            playingCup.Add(new Creature("Lion Pride", "Plains", 3, attr));
            playingCup.Add(new Creature("Farmers", "Plains", 1, attr));
            playingCup.Add(new Creature("Farmers", "Plains", 1, attr));
            playingCup.Add(new Creature("Farmers", "Plains", 1, attr));
            playingCup.Add(new Creature("Farmers", "Plains", 1, attr));
            playingCup.Add(new Creature("Buffalo Herd", "Plains", 3, attr));
            playingCup.Add(new Creature("Buffalo Herd", "Plains", 4, attr));
            playingCup.Add(new Creature("Giant Beetle", "Plains", 2, attr)); //Flying
            playingCup.Add(new Creature("Giant Hawk", "Plains", 2, attr)); //Flying
            playingCup.Add(new Creature("Centaur", "Plains", 2, attr));
            playingCup.Add(new Creature("Pegusus", "Plains", 3, attr)); //Flying
            playingCup.Add(new Creature("Pterodactyl", "Plains", 3, attr)); //Flying
            playingCup.Add(new Creature("Dragonfly", "Plains", 2, attr)); //Flying
            playingCup.Add(new Creature("Hunters", "Plains", 1, attr)); //Ranged
            playingCup.Add(new Creature("Eagles", "Plains", 2, attr)); //Flying

            playingCup.Add(new Creature("Crawling Vines", "Jungle", 6, attr));
            playingCup.Add(new Creature("Giant Ape", "Jungle", 5, attr));
            playingCup.Add(new Creature("Giant Ape", "Jungle", 5, attr));
            playingCup.Add(new Creature("Headhunter", "Jungle", 2, attr)); //Ranged
            playingCup.Add(new Creature("Dinosaur", "Jungle", 4, attr));
            playingCup.Add(new Creature("Pygmies", "Jungle", 2, attr));
            playingCup.Add(new Creature("Witch Doctor", "Jungle", 2, attr)); //Magic
            playingCup.Add(new Creature("Tigers", "Jungle", 3, attr));
            playingCup.Add(new Creature("Tigers", "Jungle", 3, attr));
            playingCup.Add(new Creature("Pterodactyl Warriors", "Jungle", 2, attr)); //Flying Ranged
            playingCup.Add(new Creature("Pterodactyl Warriors", "Jungle", 2, attr)); //Flying Ranged
            playingCup.Add(new Creature("Crocodiles", "Jungle", 2, attr));
            playingCup.Add(new Creature("Watusi", "Jungle", 2, attr));
            playingCup.Add(new Creature("Elephant", "Jungle", 4, attr)); //Charge
            playingCup.Add(new Creature("Giant Snake", "Jungle", 3, attr));
            playingCup.Add(new Creature("Bird of Paradise", "Jungle", 1, attr)); //Flying

            playingCup.Add(new Creature("Killer Puffin", "Frozen Waste", 2, attr)); //Flying
            playingCup.Add(new Creature("Ice giant", "Frozen Waste", 5, attr)); //Ranged
            playingCup.Add(new Creature("Eskimos", "Frozen Waste", 2, attr));
            playingCup.Add(new Creature("Eskimos", "Frozen Waste", 2, attr));
            playingCup.Add(new Creature("Eskimos", "Frozen Waste", 2, attr));
            playingCup.Add(new Creature("Eskimos", "Frozen Waste", 2, attr));
            playingCup.Add(new Creature("White Bear", "Frozen Waste", 4, attr));
            playingCup.Add(new Creature("Walrus", "Frozen Waste", 4, attr));
            playingCup.Add(new Creature("Dragon Rider", "Frozen Waste", 3, attr)); //Flying Ranged
            playingCup.Add(new Creature("Iceworm", "Frozen Waste", 4, attr)); //Magic
            playingCup.Add(new Creature("Mammoth", "Frozen Waste", 5, attr)); //Charge
            playingCup.Add(new Creature("Killer Penguins", "Frozen Waste", 3, attr));
            playingCup.Add(new Creature("Wolves", "Frozen Waste", 3, attr));
            playingCup.Add(new Creature("Ice Bats", "Frozen Waste", 1, attr)); //Flying
            playingCup.Add(new Creature("North Wind", "Frozen Waste", 2, attr)); //Flying Magic
            playingCup.Add(new Creature("Elk Herd", "Frozen Waste", 2, attr));
            playingCup.Add(new Creature("White Dragon", "Frozen Waste", 5, attr)); //Magic

            playingCup.Add(new Creature("Giant Lizard", "Swamp", 2, attr));
            playingCup.Add(new Creature("Giant Lizard", "Swamp", 2, attr));
            playingCup.Add(new Creature("Crocodiles", "Swamp", 2, attr));
            playingCup.Add(new Creature("Ghost", "Swamp", 1, attr)); //Flying
            playingCup.Add(new Creature("Ghost", "Swamp", 1, attr)); //Flying
            playingCup.Add(new Creature("Ghost", "Swamp", 1, attr)); //Flying
            playingCup.Add(new Creature("Ghost", "Swamp", 1, attr)); //Flying
            playingCup.Add(new Creature("Vampire Bat", "Swamp", 4, attr)); //Flying
            playingCup.Add(new Creature("Swamp Rat", "Swamp", 1, attr));
            playingCup.Add(new Creature("Sprite", "Swamp", 1, attr)); //Magic
            playingCup.Add(new Creature("Giant Snake", "Swamp", 3, attr));
            playingCup.Add(new Creature("Swamp Gas", "Swamp", 1, attr)); //Flying
            playingCup.Add(new Creature("Slime Beast", "Swamp", 3, attr));
            playingCup.Add(new Creature("Will-O-Wisp", "Swamp", 2, attr)); //Magic
            playingCup.Add(new Creature("Watersnake", "Swamp", 1, attr));
            playingCup.Add(new Creature("Dark Wizard", "Swamp", 1, attr)); //Flying Magic
            playingCup.Add(new Creature("Poison Frog", "Swamp", 1, attr));
            playingCup.Add(new Creature("Pirates", "Swamp", 2, attr));
            playingCup.Add(new Creature("Basilisk", "Swamp", 3, attr)); //Magic
            playingCup.Add(new Creature("Winged Pirhana", "Swamp", 3, attr)); //Flying
            playingCup.Add(new Creature("Spirit", "Swamp", 2, attr)); //Magic
            playingCup.Add(new Creature("Thing", "Swamp", 2, attr));
            playingCup.Add(new Creature("Black Knight", "Swamp", 3, attr)); //Charge
            playingCup.Add(new Creature("Huge Leech", "Swamp", 2, attr));
            playingCup.Add(new Creature("Giant Mosquito", "Swamp", 2, attr)); //Flying

            playingCup.Add(new Creature("Sandworm", "Desert", 3, attr));
            playingCup.Add(new Creature("Giant Spider", "Desert", 1, attr));
            playingCup.Add(new Creature("Nomads", "Desert", 1, attr));
            playingCup.Add(new Creature("Nomads", "Desert", 1, attr));
            playingCup.Add(new Creature("Baby Dragon", "Desert", 3, attr)); //Flying
            playingCup.Add(new Creature("Skeletons", "Desert", 1, attr));
            playingCup.Add(new Creature("Skeletons", "Desert", 1, attr));
            playingCup.Add(new Creature("Griffon", "Desert", 2, attr)); //Flying
            playingCup.Add(new Creature("Dervish", "Desert", 2, attr)); //Magic
            playingCup.Add(new Creature("Dervish", "Desert", 2, attr)); //Magic
            playingCup.Add(new Creature("Giant Wasp", "Desert", 4, attr)); //Flying
            playingCup.Add(new Creature("Giant Wasp", "Desert", 4, attr)); //Flying
            playingCup.Add(new Creature("Desert Bat", "Desert", 1, attr)); //Flying
            playingCup.Add(new Creature("Genie", "Desert", 4, attr)); //Magic
            playingCup.Add(new Creature("Camel Corps", "Desert", 3, attr));
            playingCup.Add(new Creature("Vultures", "Desert", 1, attr)); //Flying
            playingCup.Add(new Creature("Buzzard", "Desert", 1, attr)); //Flying
            playingCup.Add(new Creature("Dust Devil", "Desert", 4, attr)); //Flying
            playingCup.Add(new Creature("Sphinx", "Desert", 4, attr)); //Magic
            playingCup.Add(new Creature("Yellow Knight", "Desert", 3, attr)); //Charge
            playingCup.Add(new Creature("Old Dragon", "Desert", 4, attr)); //Flying Magic

            playingCup.Add(new Creature("Pixies", "Forest", 1, attr)); //Flying
            playingCup.Add(new Creature("Pixies", "Forest", 1, attr)); //Flying
            playingCup.Add(new Creature("Killer Racoon", "Forest", 2, attr));
            playingCup.Add(new Creature("Druid", "Forest", 3, attr)); //Magic
            playingCup.Add(new Creature("Elf Mage", "Forest", 2, attr)); //Magic
            playingCup.Add(new Creature("Bandits", "Forest", 2, attr));
            playingCup.Add(new Creature("Flying Squirrel", "Forest", 1, attr)); //Flying
            playingCup.Add(new Creature("Flying Squirrel", "Forest", 2, attr)); //Flying
            playingCup.Add(new Creature("Green Knight", "Forest", 4, attr)); //Charge
            playingCup.Add(new Creature("Dryad", "Forest", 1, attr)); //Magic
            playingCup.Add(new Creature("Elves", "Forest", 3, attr)); //Ranged
            playingCup.Add(new Creature("Elves", "Forest", 2, attr)); //Ranged
            playingCup.Add(new Creature("Elves", "Forest", 2, attr)); //Ranged
            playingCup.Add(new Creature("Bears", "Forest", 2, attr));
            playingCup.Add(new Creature("Great Owl", "Forest", 2, attr)); //Flying
            playingCup.Add(new Creature("Wild Cat", "Forest", 2, attr));
            playingCup.Add(new Creature("Wyvern", "Forest", 3, attr)); //Flying
            playingCup.Add(new Creature("Big Foot", "Forest", 5, attr));
            playingCup.Add(new Creature("Unicorn", "Forest", 4, attr));
            playingCup.Add(new Creature("Forester", "Forest", 2, attr)); //Ranged
            playingCup.Add(new Creature("Walking Tree", "Forest", 5, attr));
        }
    }

} // end namespace