using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic
{

	public class GameBoard
	{
		
		//public

            public Phase play() 
            {
                if (currentPhase.getCurrentState() != Phase.State.END)
                    return currentPhase;
                else
                {
                    return getNextPhase();
                }
            }

            public void addPlayer(string name)
            {
                if (players.Count == 0)
                    players.Add(new Player(name, 110, 1));
                else if( players.Count == 1 )
                    players.Add(new Player(name, NetworkPosition.CLIENT, 245, 2));
                else if (players.Count == 2)
                    players.Add(new Player(name, NetworkPosition.CLIENT, 380, 3));
                else if (players.Count == 3)
                    players.Add(new Player(name, NetworkPosition.CLIENT, 515, 4));
            }

            public Phase getNextPhase()
            {
                if( gamePhases.IndexOf(currentPhase) != gamePhases.Capacity - 1)
                    currentPhase = gamePhases[gamePhases.IndexOf(currentPhase) + 1];
                else
                    currentPhase = gamePhases[1];

                return currentPhase;
            }

            public Thing getRandomThingFromCup()
            {
                if (playingCup.Count == 0)
                    return null;

                Random r = new Random();

                int nxt = r.Next(playingCup.Count);

                Thing retVal = playingCup[nxt];

                removeFromCup(retVal);

                return retVal;
            }

            public Thing getThingFromBank(string type)
            {
                List<Thing> typeList = bank[type];

                if (typeList.Count == 0)
                    return null;

                Thing thing = typeList[0];

                removeFromBank(type, thing);

                return thing;
            }

            public bool setPlayerOrder()
            {
                //ask players to roll dice
                SortedDictionary<int, Player> order = new SortedDictionary<int, Player>();

                foreach (Player p in players)
                {
                    Console.WriteLine(p.getDiceRoll());
                    if (!order.ContainsKey(p.getDiceRoll()))
                        order.Add(p.getDiceRoll(), p);
                    else
                        return false;
                }
                    
                /*
                int diceroll = 0;

                while (true)
                {
                    foreach (Player p in players)
                    {
                        diceroll = DiceRoller.Roll.rollDice();
                        Console.WriteLine(diceroll);
                        if (!order.ContainsKey(diceroll) && order.Count < 4)
                            order.Add(diceroll, p);
                        else
                            break;
                    }

                    if (order.Count < 4)
                        order.Clear();
                    else
                        break;
                }
                */

                players = order.Values.ToList<Player>();
                players.Reverse();

                return true;
            }

            public List<Player> getPlayers()
            {
                return players;
            }

            public Player getPlayerByNumber(int i)
            {
                Player p = null;

                foreach (Player aPlayer in players)
                {
                    if (aPlayer.getPlayerNumber() == i)
                        p = aPlayer;
                }

                return p;
            }

            public string getCurrentPhase()
            {
                return currentPhase.getName();
            }

            public Phase getCurrentPhaseObject()
            {
                return currentPhase;
            }
		
		//private
		
			//ctor
			private GameBoard () 
            {
                theBoard = new Board();
                players = new List<Player>(4);

                int n = 1;

                while (players.Count != players.Capacity)
                {
                    addPlayer(String.Format("Player {0}", n++));
                }

                bank = new Dictionary<string, List<Thing>>();
                playingCup = new List<Thing>();
                init();
                initGamePhases();
                currentPhase = gamePhases[0];
            }

            private void orderPlayers()
            {
                List<Player> reOrder = new List<Player>(4);

                reOrder.Add(players[players.Count - 1]);
                reOrder.Add(players[0]);
                reOrder.Add(players[1]);
                reOrder.Add(players[2]);

                players = reOrder;

            }

            private void playTurn(Phase phase)
            {
                phase.playPhase(players);
            }

            private void removeFromBank(string type, Thing thing)
            {
                bank[type].Remove(thing);
            }

            private void removeFromCup(Thing thing)
            {
                playingCup.Remove(thing);
            }

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
				initSpecialCharacters();
			}

			private void initSpecialCharacters()
			{
				string type = "SpecialCharacters";
				
				if( !bank.ContainsKey(type) )
				{
					bank.Add(type, new List<Thing>());
				}
				
				List<Thing> sc = bank[type];
				List<Attributes.CombatAttributes> attr = new List<Attributes.CombatAttributes>();

                sc.Add(new SpecialCharacter("Sword Master", 4, attr, 0, "images/swordmaster"));

                //MAGIC\\

                attr.Add(Attributes.CombatAttributes.MAGIC);

                //ctor for special characters (name, path_to_image, combat_score, list_of_attributes)

                sc.Add(new SpecialCharacter("Arch Cleric", 5, attr, 1, "images/archcleric"));

                sc.Add(new SpecialCharacter("Arch Mage", 6, attr, 2, "images/archmage"));

                //SPECIAL\\

                attr.Clear();

                attr.Add(Attributes.CombatAttributes.SPECIAL);

                sc.Add(new SpecialCharacter("Assassin Primus", 4, attr, 3, "images/assassinprimus"));

                sc.Add(new SpecialCharacter("Baurn Munchausen", 4, attr, 4, "images/baurnmunchausen"));

                sc.Add(new SpecialCharacter("DeerHunter", 4, attr, 5, "images/deerhunter"));

                sc.Add(new SpecialCharacter("Desert Master", 4, attr, 6, "images/desertmaster"));

                sc.Add(new SpecialCharacter("Dwarf King", 5, attr, 7, "images/dwarfking"));

                sc.Add(new SpecialCharacter("Forest King", 4, attr, 8, "images/forestking"));

                sc.Add(new SpecialCharacter("Grand Duke", 4, attr, 9, "images/grandduke"));

                sc.Add(new SpecialCharacter("Ice Lord", 4, attr, 10, "images/icelord"));

                sc.Add(new SpecialCharacter("Jungle Lord", 4, attr, 11, "images/junglelord"));

                sc.Add(new SpecialCharacter("Master Thief", 4, attr, 12, "images/masterthief"));

                sc.Add(new SpecialCharacter("Mountain King", 4, attr, 13, "images/mountainking"));

                sc.Add(new SpecialCharacter("Plains Lord", 4, attr, 14, "images/plainslord"));

                sc.Add(new SpecialCharacter("Swamp King", 4, attr, 15, "images/swampking"));

                sc.Add(new SpecialCharacter("Warlord", 5, attr, 16, "images/warlord"));

                //RANGED\\

                attr.Clear();

                attr.Add(Attributes.CombatAttributes.RANGED);

                sc.Add(new SpecialCharacter("Elf Lord", 6, attr, 17, "images/elflord"));

                sc.Add(new SpecialCharacter("Marksman", 5, attr, 18, "images/marksman"));

                //FLYING\\

                attr.Clear();

                attr.Add(Attributes.CombatAttributes.FLYING);

                sc.Add(new SpecialCharacter("Ghaog II", 6, attr, 19, "images/ghaog2"));

                sc.Add(new SpecialCharacter("Lord of the Eagles", 5, attr, 20, "images/lordoftheeagles"));

                //CHARGE\\

                attr.Clear();

                attr.Add(Attributes.CombatAttributes.CHARGE);

                sc.Add(new SpecialCharacter("Sir Lance-a-Lot", 5, attr, 21, "images/sirlancealot"));
			}

            private void initGamePhases()
            {
                // capacity should be 10
                gamePhases = new List<Phase>(6);
                gamePhases.Add(new SetupPhase());
                gamePhases.Add(new GoldCollectionPhase());
                gamePhases.Add(new RecruitThingsPhase());
                gamePhases.Add(new MovementPhase());
                gamePhases.Add(new CombatPhase());
                gamePhases.Add(new ConstructionPhase());
            }
        
            private void initCup()
            {
                initCreatures();   
            }
        
            private void initCreatures()
            {
                List<Attributes.CombatAttributes> attr = new List<Attributes.CombatAttributes>();

                playingCup.Add(new Creature("Goblin", "Mountain", 1, attr, 65, "images\\goblins_mountain_1.png"));
                playingCup.Add(new Creature("Goblin", "Mountain", 1, attr, 66, "images\\goblins_mountain_1_2.png"));
                playingCup.Add(new Creature("Goblin", "Mountain", 1, attr, 67, "images\\goblins_mountain_1_3.png"));
                playingCup.Add(new Creature("Goblin", "Mountain", 1, attr, 68, "images\\goblins_mountain_1_4.png"));
                playingCup.Add(new Creature("Dwarves", "Mountain", 3, attr, 28, "images\\dwarves_mountain_c3.png")); //Charge
                playingCup.Add(new Creature("Dwarves", "Mountain", 2, attr, 29, "images\\dwarves_mountain_r2.png")); //Ranged
                playingCup.Add(new Creature("Dwarves", "Mountain", 3, attr, 30, "images\\dwarves_mountain_r3.png")); //Ranged
                playingCup.Add(new Creature("Troll", "Mountain", 4, attr, 121, "images\\troll_mountain_4.png"));
                playingCup.Add(new Creature("Great Eagle", "Mountain", 2, attr, 69, "images\\greateagle_mountain_2.png")); //Flying
                playingCup.Add(new Creature("Brown Dragon", "Mountain", 3, attr, 7, "images\\browndragon_mountain_3.png")); //Flying
                playingCup.Add(new Creature("Mountain Men", "Mountain", 1, attr, 91, "images\\mountainmen_mountain_1.png"));
                playingCup.Add(new Creature("Mountain Men", "Mountain", 1, attr, 92, "images\\mountainmen_mountain_1_2.png"));
                playingCup.Add(new Creature("Giant Roc", "Mountain", 3, attr, 59, "images\\giantroc_mountain_3.png")); //Flying
                playingCup.Add(new Creature("Giant Condor", "Mountain", 3, attr, 56, "images\\giantcondor_mountain_3.png")); //Flying
                playingCup.Add(new Creature("Cyclops", "Mountain", 5, attr, 17, "images\\cyclops_mountain_5.png"));
                playingCup.Add(new Creature("Great Hawk", "Mountain", 1, attr, 70, "images\\greathawk_mountain_1.png")); //Flying
                playingCup.Add(new Creature("Ogre", "Mountain", 2, attr, 96, "images\\ogre_mountain_2.png"));
                playingCup.Add(new Creature("Brown Knight", "Mountain", 4, attr, 8, "images\\brownknight_mountain_c4.png")); //Charge
                playingCup.Add(new Creature("Little Roc", "Mountain", 2, attr, 88, "images\\littleroc_mountain_2.png")); //Flying
                playingCup.Add(new Creature("Giant", "Mountain", 4, attr, 52, "images\\giant_mountain_r4.png")); //Ranged
                playingCup.Add(new Creature("Mountain Lion", "Mountain", 2, attr, 90, "images\\mountainlion_mountain_2.png"));

                playingCup.Add(new Creature("Villains", "Plains", 2, attr, 124, "images\\villains_plains_2.png"));
                playingCup.Add(new Creature("Gypsies", "Plains", 1, attr, 76, "images\\gypsies_plains_1.png")); //Magic
                playingCup.Add(new Creature("Gypsies", "Plains", 2, attr, 77, "images\\gypsies_plains_2.png")); //Magic
                playingCup.Add(new Creature("White Knight", "Plains", 3, attr, 142, "images\\whiteknight_plains_c3.png")); //Charge
                playingCup.Add(new Creature("Tribesmen", "Plains", 2, attr, 118, "images\\tribesmen_plains_2.png"));
                playingCup.Add(new Creature("Tribesmen", "Plains", 2, attr, 119, "images\\tribesmen_plains_2_2.png"));
                playingCup.Add(new Creature("Tribesmen", "Plains", 1, attr, 120, "images\\tribesmen_plains_r1.png")); //Ranged
                playingCup.Add(new Creature("Greathunter", "Plains", 4, attr, 72, "images\\greathunter_plains_r4.png")); //Ranged
                playingCup.Add(new Creature("Wolf Pack", "Plains", 3, attr, 137, "images\\wolfpack_plains_3.png"));
                playingCup.Add(new Creature("Lion Pride", "Plains", 3, attr, 87, "images\\lionpride_plains_3.png"));
                playingCup.Add(new Creature("Farmers", "Plains", 1, attr, 42, "images\\farmers_plains_1_1.png"));
                playingCup.Add(new Creature("Farmers", "Plains", 1, attr, 43, "images\\farmers_plains_1_2.png"));
                playingCup.Add(new Creature("Farmers", "Plains", 1, attr, 44, "images\\farmers_plains_1_3.png"));
                playingCup.Add(new Creature("Farmers", "Plains", 1, attr, 45, "images\\farmers_plains_1_4.png"));
                playingCup.Add(new Creature("Buffalo Herd", "Plains", 3, attr, 9, "images\\buffaloherd_plains_3.png"));
                playingCup.Add(new Creature("Buffalo Herd", "Plains", 4, attr, 10, "images\\buffaloherd_plains_4.png"));
                playingCup.Add(new Creature("Giant Beetle", "Plains", 2, attr, 55, "images\\giantbeetle_plains_2.png")); //Flying
                playingCup.Add(new Creature("Great Hawk", "Plains", 2, attr, 70, "images\\greathawk_plains_2.png")); //Flying
                playingCup.Add(new Creature("Centaur", "Plains", 2, attr, 13, "images\\centaur_plains_2.png"));
                playingCup.Add(new Creature("Pegusus", "Plains", 2, attr, 98, "images\\pegasus_plains_2.png")); //Flying
                playingCup.Add(new Creature("Pterodactyl", "Plains", 3, attr, 103, "images\\pterodactyl_plains_3.png")); //Flying
                playingCup.Add(new Creature("Dragonfly", "Plains", 2, attr, 23, "images\\dragonfly_plains_2.png")); //Flying
                playingCup.Add(new Creature("Hunters", "Plains", 1, attr, 80, "images\\hunters_plains_r1.png")); //Ranged
                playingCup.Add(new Creature("Eagles", "Plains", 2, attr, 31, "images\\eagles_plains_2.png")); //Flying

                playingCup.Add(new Creature("Crawling Vines", "Jungle", 6, attr, 14, "images\\crawlingvines_jungle_6.png"));
                playingCup.Add(new Creature("Giant Ape", "Jungle", 5, attr, 53, "images\\giantape_jungle_5.png"));
                playingCup.Add(new Creature("Giant Ape", "Jungle", 5, attr, 54, "images\\giantape_jungle_5_2.png"));
                playingCup.Add(new Creature("Headhunter", "Jungle", 2, attr, 78, "images\\headhunter_jungle_r2.png")); //Ranged
                playingCup.Add(new Creature("Dinosaur", "Jungle", 4, attr, 22, "images\\dinosaur_jungle_4.png"));
                playingCup.Add(new Creature("Pygmies", "Jungle", 2, attr, 106, "images\\pygmies_jungle_2.png"));
                playingCup.Add(new Creature("Witch Doctor", "Jungle", 2, attr, 136, "images\\witchdoctor_jungle_2.png")); //Magic
                playingCup.Add(new Creature("Tigers", "Jungle", 3, attr, 116, "images\\tigers_jungle_3.png"));
                playingCup.Add(new Creature("Tigers", "Jungle", 3, attr, 117, "images\\tigers_jungle_3_2.png"));
                playingCup.Add(new Creature("Pterodactyl Warriors", "Jungle", 2, attr, 104, "images\\pterodactylwarriors_jungle_r2.png")); //Flying Ranged
                playingCup.Add(new Creature("Pterodactyl Warriors", "Jungle", 2, attr, 105, "images\\pterodactylwarriors_jungle_r2_2.png")); //Flying Ranged
                playingCup.Add(new Creature("Crocodiles", "Jungle", 2, attr, 15, "images\\crocodiles_jungle_2.png"));
                playingCup.Add(new Creature("Watusi", "Jungle", 2, attr, 129, "images\\watusi_jungle_2.png"));
                playingCup.Add(new Creature("Elephant", "Jungle", 4, attr, 32, "images\\elephant_jungle_c4.png")); //Charge
                playingCup.Add(new Creature("Giant Snake", "Jungle", 3, attr, 59, "images\\giantsnake_jungle_3.png"));
                playingCup.Add(new Creature("Bird of Paradise", "Jungle", 1, attr, 5, "images\\birdofparadise_jungle_1.png")); //Flying

                playingCup.Add(new Creature("Killer Puffin", "Frozen Waste", 2, attr, 85, "images\\killerpuffins_frozenwaste_2.png")); //Flying
                playingCup.Add(new Creature("Ice giant", "Frozen Waste", 5, attr, 82, "images\\icegiant_frozenwaste_r5.png")); //Ranged
                playingCup.Add(new Creature("Eskimos", "Frozen Waste", 2, attr, 38, "images\\eskimos_frozenwaste_2_1.png"));
                playingCup.Add(new Creature("Eskimos", "Frozen Waste", 2, attr, 39, "images\\eskimos_frozenwaste_2_2.png"));
                playingCup.Add(new Creature("Eskimos", "Frozen Waste", 2, attr, 40, "images\\eskimos_frozenwaste_2_3.png"));
                playingCup.Add(new Creature("Eskimos", "Frozen Waste", 2, attr, 41, "images\\eskimos_frozenwaste_2_4.png"));
                playingCup.Add(new Creature("White Bear", "Frozen Waste", 4, attr, 130, "images\\whitebear_frozenwaste_4.png"));
                playingCup.Add(new Creature("Walrus", "Frozen Waste", 4, attr, 127, "images\\walrus_frozenwaste_4.png"));
                playingCup.Add(new Creature("Dragon Rider", "Frozen Waste", 3, attr, 24, "images\\dragonrider_frozenwaste_r3.png")); //Flying Ranged
                playingCup.Add(new Creature("Iceworm", "Frozen Waste", 4, attr, 83, "images\\iceworm_frozenwaste_4.png")); //Magic
                playingCup.Add(new Creature("Mammoth", "Frozen Waste", 5, attr, 89, "images\\mammoth_frozenwaste_c5.png")); //Charge
                playingCup.Add(new Creature("Killer Penguins", "Frozen Waste", 3, attr, 84, "images\\killerpenguins_frozenwaste_3.png"));
                playingCup.Add(new Creature("Wolves", "Frozen Waste", 3, attr, 138, "images\\wolves_frozenwaste_3.png"));
                playingCup.Add(new Creature("Ice Bats", "Frozen Waste", 1, attr, 81, "images\\icebats_frozenwaste_1.png")); //Flying
                playingCup.Add(new Creature("North Wind", "Frozen Waste", 2, attr, 95, "images\\northwind_frozenwaste_2.png")); //Flying Magic
                playingCup.Add(new Creature("Elk Herd", "Frozen Waste", 2, attr, 34, "images\\elkherd_frozenwaste_2.png"));
                playingCup.Add(new Creature("White Dragon", "Frozen Waste", 5, attr, 131, "images\\whitedragon_frozenwaste_5.png")); //Magic

                playingCup.Add(new Creature("Giant Lizard", "Swamp", 2, attr, 57, "images\\giantlizard_swamp_2.png"));
                playingCup.Add(new Creature("Giant Lizard", "Swamp", 2, attr, 57, "images\\giantlizard_swamp_2.png"));
                playingCup.Add(new Creature("Crocodiles", "Swamp", 2, attr, 16, "images\\crocodiles_swamp_2.jpg"));
                playingCup.Add(new Creature("Ghost", "Swamp", 1, attr, 51, "images\\ghost_swamp_1.png")); //Flying
                playingCup.Add(new Creature("Ghost", "Swamp", 1, attr, 51, "images\\ghost_swamp_1.png")); //Flying
                playingCup.Add(new Creature("Ghost", "Swamp", 1, attr, 51, "images\\ghost_swamp_1.png")); //Flying
                playingCup.Add(new Creature("Ghost", "Swamp", 1, attr, 51, "images\\ghost_swamp_1.png")); //Flying
                playingCup.Add(new Creature("Vampire Bat", "Swamp", 4, attr, 123, "images\\vampirebat_swamp_4.jpg")); //Flying
                playingCup.Add(new Creature("Swamp Rat", "Swamp", 1, attr, 114, "images\\swamprat_swamp_1.jpg"));
                playingCup.Add(new Creature("Sprite", "Swamp", 1, attr, 112, "images\\sprite_swamp_1.jpg")); //Magic
                playingCup.Add(new Creature("Giant Snake", "Swamp", 3, attr, 61, "images\\giantsnake_swamp_3.png"));
                playingCup.Add(new Creature("Swamp Gas", "Swamp", 1, attr, 113, "images\\swampgas_swamp_1.jpg")); //Flying
                playingCup.Add(new Creature("Slime Beast", "Swamp", 3, attr, 109, "images\\slimebeast_swamp_3.jpg"));
                playingCup.Add(new Creature("Will-O-Wisp", "Swamp", 2, attr, 134, "images\\willowisp_swamp_2.jpg")); //Magic
                playingCup.Add(new Creature("Watersnake", "Swamp", 1, attr, 128, "images\\watersnake_swamp_1.png"));
                playingCup.Add(new Creature("Dark Wizard", "Swamp", 1, attr, 18, "images\\darkwizard_swamp_1.png")); //Flying Magic
                playingCup.Add(new Creature("Poison Frog", "Swamp", 1, attr, 102, "images\\poisonfrog_swamp_1.png"));
                playingCup.Add(new Creature("Pirates", "Swamp", 2, attr, 99, "images\\pirates_swamp_2.png"));
                playingCup.Add(new Creature("Basilisk", "Swamp", 3, attr, 2, "images\\basilisk_swamp_3.png")); //Magic
                playingCup.Add(new Creature("Winged Pirhana", "Swamp", 3, attr, 135, "images\\wingedpirhana_swamp_3.png")); //Flying
                playingCup.Add(new Creature("Spirit", "Swamp", 2, attr, 111, "images\\spirit_swamp_2.png")); //Magic
                playingCup.Add(new Creature("Thing", "Swamp", 2, attr, 115, "images\\thing_swamp_2.png"));
                playingCup.Add(new Creature("Black Knight", "Swamp", 3, attr, 6, "images\\blackknight_swamp_c3.png")); //Charge
                playingCup.Add(new Creature("Huge Leech", "Swamp", 2, attr, 79, "images\\hugeleech_swamp_2.png"));
                playingCup.Add(new Creature("Giant Mosquito", "Swamp", 2, attr, 58, "images\\giantmosquito_swamp_2.png")); //Flying

                playingCup.Add(new Creature("Sandworm", "Desert", 3, attr, 107, "images\\sandworm_desert_3.png"));
                playingCup.Add(new Creature("Giant Spider", "Desert", 1, attr, 62, "images\\giantspider_desert_1.png"));
                playingCup.Add(new Creature("Nomads", "Desert", 1, attr, 93, "images\\nomads_desert_1.png"));
                playingCup.Add(new Creature("Nomads", "Desert", 1, attr, 94, "images\\nomads_desert_1_2.png"));
                playingCup.Add(new Creature("Baby Dragon", "Desert", 3, attr, 0, "images\\babydragon_desert_3.png")); //Flying
                playingCup.Add(new Creature("Skeletons", "Desert", 1, attr, 108, "images\\skeletons_desert_1.png"));
                playingCup.Add(new Creature("Skeletons", "Desert", 1, attr, 108, "images\\skeletons_desert_1.png"));
                playingCup.Add(new Creature("Griffon", "Desert", 2, attr, 75, "images\\griffon_desert_2.png")); //Flying
                playingCup.Add(new Creature("Dervish", "Desert", 2, attr, 19, "images\\dervish_desert_2.png")); //Magic
                playingCup.Add(new Creature("Dervish", "Desert", 2, attr, 20, "images\\dervish_desert_2_1.png")); //Magic
                playingCup.Add(new Creature("Giant Wasp", "Desert", 4, attr, 63, "images\\giantwasp_desert_4.png")); //Flying
                playingCup.Add(new Creature("Giant Wasp", "Desert", 4, attr, 64, "images\\giantwasp_desert_4_2.png")); //Flying
                playingCup.Add(new Creature("Desert Bat", "Desert", 1, attr, 21, "images\\desertbat_desert_1.png")); //Flying
                playingCup.Add(new Creature("Genie", "Desert", 4, attr, 50, "images\\genie_desert_4.png")); //Magic
                playingCup.Add(new Creature("Camel Corps", "Desert", 3, attr, 12, "images\\camelcorps_desert_3.png"));
                playingCup.Add(new Creature("Vultures", "Desert", 1, attr, 125, "images\\vultures_desert_1.png")); //Flying
                playingCup.Add(new Creature("Buzzard", "Desert", 1, attr, 11, "images\\buzzard_desert_1.png")); //Flying
                playingCup.Add(new Creature("Dust Devil", "Desert", 4, attr, 27, "images\\dustdevil_desert_4.jpg")); //Flying
                playingCup.Add(new Creature("Sphinx", "Desert", 4, attr, 110, "images\\sphinx_desert_4.jpg")); //Magic
                playingCup.Add(new Creature("Yellow Knight", "Desert", 3, attr, 140, "images\\yellowknight_desert_c3.jpg")); //Charge
                playingCup.Add(new Creature("Old Dragon", "Desert", 4, attr, 97, "images\\olddragon_desert_4.jpg")); //Flying Magic

                playingCup.Add(new Creature("Pixies", "Forest", 1, attr, 100, "images\\pixies_forest_1.png")); //Flying
                playingCup.Add(new Creature("Pixies", "Forest", 1, attr, 101, "images\\pixies_forest_1_2.png")); //Flying
                playingCup.Add(new Creature("Killer Racoon", "Forest", 2, attr, 86, "images\\killerracoon_forest_2.png"));
                playingCup.Add(new Creature("Druid", "Forest", 3, attr, 25, "images\\druid_forest_3.png")); //Magic
                playingCup.Add(new Creature("Elf Mage", "Forest", 2, attr, 33, "images\\elfmage_forest_2.png")); //Magic
                playingCup.Add(new Creature("Bandits", "Forest", 2, attr, 1, "images\\bandits_forest_2.png"));
                playingCup.Add(new Creature("Flying Squirrel", "Forest", 1, attr, 47, "images\\flyingsquirrel_forest_1.png")); //Flying
                playingCup.Add(new Creature("Flying Squirrel", "Forest", 2, attr, 48, "images\\flyingsquirrel_forest_1_2.png")); //Flying
                playingCup.Add(new Creature("Green Knight", "Forest", 4, attr, 74, "images\\greenknight_forest_4.png")); //Charge
                playingCup.Add(new Creature("Dryad", "Forest", 1, attr, 26, "images\\dryad_forest_1.png")); //Magic
                playingCup.Add(new Creature("Elves", "Forest", 3, attr, 37, "images\\elves_forest_r3.png")); //Ranged
                playingCup.Add(new Creature("Elves", "Forest", 2, attr, 35, "images\\elves_forest_r2.png")); //Ranged
                playingCup.Add(new Creature("Elves", "Forest", 2, attr, 36, "images\\elves_forest_r2.png")); //Ranged
                playingCup.Add(new Creature("Bears", "Forest", 2, attr, 3, "images\\bears_forest_2.png"));
                playingCup.Add(new Creature("Great Owl", "Forest", 2, attr, 73, "images\\greatowl_forest_2.png")); //Flying
                playingCup.Add(new Creature("Wild Cat", "Forest", 2, attr, 133, "images\\wildcat_forest_2.png"));
                playingCup.Add(new Creature("Wyvern", "Forest", 3, attr, 139, "images\\wyvern_forest_3.png")); //Flying
                playingCup.Add(new Creature("Big Foot", "Forest", 5, attr, 4, "images\\bigfoot_forest_5.png"));
                playingCup.Add(new Creature("Unicorn", "Forest", 4, attr, 122, "images\\unicorn_forest_4.png"));
                playingCup.Add(new Creature("Forester", "Forest", 2, attr, 49, "images\\forester_forest_r2.png")); //Ranged
                playingCup.Add(new Creature("Walking Tree", "Forest", 5, attr, 126, "images\\walkingtree_forest_5.jpg"));
            
            }

            public Board getMap() { return theBoard; }
		
		// private members
		
			// singleton Access
			private static GameBoard game;


            public static GameBoard Game
            {
                get
                {
                    if (game == null)
                        game = new GameBoard();
                    return game;
                }
            }
		
			// List of Players
            List<Player> players;
		
			// Board Obj
            Board theBoard;

            // person who is currently playing their turn
            Player currentPlayer;
		
			// the Bank
            Dictionary<string, List<Thing>> bank;
		
			// the Playing cup // IMPORTANT, this musn't be sorted!! // its random :)
            List<Thing> playingCup;

            // GamePhases
            List<Phase> gamePhases;

            // current phase;
            Phase currentPhase;
		
		
	} // end GameBorad Class

} // end namespace