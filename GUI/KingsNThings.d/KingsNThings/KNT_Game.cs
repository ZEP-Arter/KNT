using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using GameLogic;

namespace KingsNThings
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class KNT_Game : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Texture2D board;
        private Texture2D roll;
        private Texture2D endTexture;
        private static Texture2D stackTexture;
        private Texture2D[] hexTexture = new Texture2D[9];
        private Texture2D[] goldTexture = new Texture2D[6];
        private Texture2D[] fortTexture = new Texture2D[4];
        private static Texture2D[] markerTexture = new Texture2D[4];
        public static Texture2D[] thingTexture = new Texture2D[200];
        public static Texture2D[] specialThingTexture = new Texture2D[25];
        
        //Button hex1, hex2, hex3, hex4, hex5, hex6, hex7, hex8, hex9, hex10, hex11, hex12, hex13, hex14, hex15, hex16, hex17, hex18, hex19, hex20, hex21, hex22, hex23, hex24, hex25, hex26, hex27, hex28, hex29, hex30, hex31, hex32, hex33, hex34, hex35, hex36, hex37;
        Button rollbutton;
        Button endButton;

        public static List<Button> StackButtons = new List<Button>();

        Button recruitButton;
        public static List<Button> P1Tiles = new List<Button>();
        public static List<Button> P2Tiles = new List<Button>();
        public static List<Button> P3Tiles = new List<Button>();
        public static List<Button> P4Tiles = new List<Button>();

        List<Button> hex = new List<Button>();
        static List<Button> marker = new List<Button>();
        SpriteFont font;
        Texture2D rack;
        GameBoard _theGameBoard;
        public static Player me;
        bool positionsSet;
        bool markersSet;
        Phase currentPhase;
        public static Button buttonInHand;
        public static List<Thing> stackInHand;

        Button tempButton;

        public KNT_Game()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferHeight = 800;
            graphics.PreferredBackBufferWidth = 1000;
            graphics.ApplyChanges();
            positionsSet = false;
            markersSet = false;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _theGameBoard = GameBoard.Game;
            me = _theGameBoard.getPlayers()[0];
            currentPhase = _theGameBoard.play();
            //testPlay();
            this.IsMouseVisible = true;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("test");
            board = Content.Load<Texture2D>("images/board");
            rack = Content.Load<Texture2D>("images/rack");
            roll = Content.Load<Texture2D>("images/roll");
            endTexture = Content.Load<Texture2D>("images/end");
            stackTexture = Content.Load<Texture2D>("images/back");
            /////////////////////////////////HEX TEXTURES\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
            hexTexture[0] = Content.Load<Texture2D>("images/back2");
            hexTexture[1] = Content.Load<Texture2D>("images/desert");
            hexTexture[2] = Content.Load<Texture2D>("images/forest");
            hexTexture[3] = Content.Load<Texture2D>("images/frozenwaste");
            hexTexture[4] = Content.Load<Texture2D>("images/jungle");
            hexTexture[5] = Content.Load<Texture2D>("images/mountain");
            hexTexture[6] = Content.Load<Texture2D>("images/plains");
            hexTexture[7] = Content.Load<Texture2D>("images/sea");
            hexTexture[8] = Content.Load<Texture2D>("images/swamp");


            /////////////////////////////////GOLD TEXTURES\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
            goldTexture[0] = Content.Load<Texture2D>("images/gold1");
            goldTexture[1] = Content.Load<Texture2D>("images/gold2");
            goldTexture[2] = Content.Load<Texture2D>("images/gold5");
            goldTexture[3] = Content.Load<Texture2D>("images/gold10");
            goldTexture[4] = Content.Load<Texture2D>("images/gold15");
            goldTexture[5] = Content.Load<Texture2D>("images/gold20");

            /////////////////////////////////MARKER TEXTURES\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
            markerTexture[0] = Content.Load<Texture2D>("images/marker1");
            markerTexture[1] = Content.Load<Texture2D>("images/marker2");
            markerTexture[2] = Content.Load<Texture2D>("images/marker3");
            markerTexture[3] = Content.Load<Texture2D>("images/marker4");

            /////////////////////////////////SCRIPT TILE TEXTURES\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

            specialThingTexture[0] = Content.Load<Texture2D>("images/swordmaster");
            specialThingTexture[1] = Content.Load<Texture2D>("images/archcleric");
            specialThingTexture[2] = Content.Load<Texture2D>("images/archmage");
            specialThingTexture[3] = Content.Load<Texture2D>("images/assassinprimus");
            specialThingTexture[4] = Content.Load<Texture2D>("images/baronmunchausen");
            specialThingTexture[5] = Content.Load<Texture2D>("images/deerhunter");
            specialThingTexture[6] = Content.Load<Texture2D>("images/desertmaster");
            specialThingTexture[7] = Content.Load<Texture2D>("images/dwarfking");
            specialThingTexture[8] = Content.Load<Texture2D>("images/forestking");
            specialThingTexture[9] = Content.Load<Texture2D>("images/grandduke");
            specialThingTexture[10] = Content.Load<Texture2D>("images/icelord");
            specialThingTexture[11] = Content.Load<Texture2D>("images/junglelord");
            specialThingTexture[12] = Content.Load<Texture2D>("images/masterthief");
            specialThingTexture[13] = Content.Load<Texture2D>("images/mountainking");
            specialThingTexture[14] = Content.Load<Texture2D>("images/plainslord");
            specialThingTexture[15] = Content.Load<Texture2D>("images/swampking");
            specialThingTexture[16] = Content.Load<Texture2D>("images/warlord");
            specialThingTexture[17] = Content.Load<Texture2D>("images/elflord");
            specialThingTexture[18] = Content.Load<Texture2D>("images/marksman");
            specialThingTexture[19] = Content.Load<Texture2D>("images/ghaog2");
            specialThingTexture[20] = Content.Load<Texture2D>("images/lordoftheeagles");
            specialThingTexture[21] = Content.Load<Texture2D>("images/sirlancealot");

            thingTexture[0] = Content.Load<Texture2D>("images/babydragon_desert_3");
            thingTexture[1] = Content.Load<Texture2D>("images/bandits_forest_2");
            thingTexture[2] = Content.Load<Texture2D>("images/basilisk_swamp_3");
            thingTexture[3] = Content.Load<Texture2D>("images/bears_forest_2");
            thingTexture[4] = Content.Load<Texture2D>("images/bigfoot_forest_5");
            thingTexture[5] = Content.Load<Texture2D>("images/birdofparadise_jungle_1");
            thingTexture[6] = Content.Load<Texture2D>("images/blackknight_swamp_c3");
            thingTexture[7] = Content.Load<Texture2D>("images/browndragon_mountain_3");
            thingTexture[8] = Content.Load<Texture2D>("images/brownknight_mountain_c4");
            thingTexture[9] = Content.Load<Texture2D>("images/buffaloherd_plains_3");
            thingTexture[10] = Content.Load<Texture2D>("images/buffaloherd_plains_4");

            thingTexture[11] = Content.Load<Texture2D>("images/buzzard_desert_1");
            thingTexture[12] = Content.Load<Texture2D>("images/camelcorps_desert_3");
            thingTexture[13] = Content.Load<Texture2D>("images/centaur_plains_2");
            thingTexture[14] = Content.Load<Texture2D>("images/crawlingvines_jungle_6");
            thingTexture[15] = Content.Load<Texture2D>("images/crocodiles_jungle_2");
            thingTexture[16] = Content.Load<Texture2D>("images/crocodiles_swamp_2");
            thingTexture[17] = Content.Load<Texture2D>("images/cyclops_mountain_5");
            thingTexture[18] = Content.Load<Texture2D>("images/darkwizard_swamp_1");
            thingTexture[19] = Content.Load<Texture2D>("images/dervish_desert_2");
            thingTexture[20] = Content.Load<Texture2D>("images/dervish_desert_2_1");
            
            thingTexture[21] = Content.Load<Texture2D>("images/desertbat_desert_1");
            thingTexture[22] = Content.Load<Texture2D>("images/dinosaur_jungle_4");
            thingTexture[23] = Content.Load<Texture2D>("images/dragonfly_plains_2");
            thingTexture[24] = Content.Load<Texture2D>("images/dragonrider_frozenwaste_r3");
            thingTexture[25] = Content.Load<Texture2D>("images/druid_forest_3");
            thingTexture[26] = Content.Load<Texture2D>("images/dryad_forest_1");
            thingTexture[27] = Content.Load<Texture2D>("images/dustdevil_desert_4");
            thingTexture[28] = Content.Load<Texture2D>("images/dwarves_mountain_c3");
            thingTexture[29] = Content.Load<Texture2D>("images/dwarves_mountain_r2");
            thingTexture[30] = Content.Load<Texture2D>("images/dwarves_mountain_r3");
            
            thingTexture[31] = Content.Load<Texture2D>("images/eagles_plains_2");
            thingTexture[32] = Content.Load<Texture2D>("images/elephant_jungle_c4");
            thingTexture[33] = Content.Load<Texture2D>("images/elfmage_forest_2");
            thingTexture[34] = Content.Load<Texture2D>("images/elkherd_frozenwaste_2");
            thingTexture[35] = Content.Load<Texture2D>("images/elves_forest_r2");
            thingTexture[36] = Content.Load<Texture2D>("images/elves_forest_r2_2");
            thingTexture[37] = Content.Load<Texture2D>("images/elves_forest_r3");
            thingTexture[38] = Content.Load<Texture2D>("images/eskimos_frozenwaste_2_1");
            thingTexture[39] = Content.Load<Texture2D>("images/eskimos_frozenwaste_2_2");
            thingTexture[40] = Content.Load<Texture2D>("images/eskimos_frozenwaste_2_3");
            
            thingTexture[41] = Content.Load<Texture2D>("images/eskimos_frozenwaste_2_4");
            thingTexture[42] = Content.Load<Texture2D>("images/farmers_plains_1_1");
            thingTexture[43] = Content.Load<Texture2D>("images/farmers_plains_1_2");
            thingTexture[44] = Content.Load<Texture2D>("images/farmers_plains_1_3");
            thingTexture[45] = Content.Load<Texture2D>("images/farmers_plains_1_4");
            thingTexture[46] = Content.Load<Texture2D>("images/flyingbuffalo_plains_2");
            thingTexture[47] = Content.Load<Texture2D>("images/flyingsquirrel_forest_1");
            thingTexture[48] = Content.Load<Texture2D>("images/flyingsquirrel_forest_1_2");
            thingTexture[49] = Content.Load<Texture2D>("images/forester_forest_r2");
            thingTexture[50] = Content.Load<Texture2D>("images/genie_desert_4");
            
            thingTexture[51] = Content.Load<Texture2D>("images/ghost_swamp_1");
            thingTexture[52] = Content.Load<Texture2D>("images/giant_mountain_r4");
            thingTexture[53] = Content.Load<Texture2D>("images/giantape_jungle_5");
            thingTexture[54] = Content.Load<Texture2D>("images/giantape_jungle_5_2");
            thingTexture[55] = Content.Load<Texture2D>("images/giantbeetle_plains_2");
            thingTexture[56] = Content.Load<Texture2D>("images/giantcondor_mountain_3");
            thingTexture[57] = Content.Load<Texture2D>("images/giantlizard_swamp_2");
            thingTexture[58] = Content.Load<Texture2D>("images/giantmosquito_swamp_2");
            thingTexture[59] = Content.Load<Texture2D>("images/giantroc_mountain_3");
            thingTexture[60] = Content.Load<Texture2D>("images/giantsnake_jungle_3");

            thingTexture[61] = Content.Load<Texture2D>("images/giantsnake_swamp_3");
            thingTexture[62] = Content.Load<Texture2D>("images/giantspider_desert_1");
            thingTexture[63] = Content.Load<Texture2D>("images/giantwasp_desert_4");
            thingTexture[64] = Content.Load<Texture2D>("images/giantwasp_desert_4_2");
            thingTexture[65] = Content.Load<Texture2D>("images/goblins_mountain_1");
            thingTexture[66] = Content.Load<Texture2D>("images/goblins_mountain_1_2");
            thingTexture[67] = Content.Load<Texture2D>("images/goblins_mountain_1_3");
            thingTexture[68] = Content.Load<Texture2D>("images/goblins_mountain_1_4");
            thingTexture[69] = Content.Load<Texture2D>("images/greateagle_mountain_2");
            thingTexture[70] = Content.Load<Texture2D>("images/greathawk_mountain_1");

            thingTexture[71] = Content.Load<Texture2D>("images/greathawk_plains_2");
            thingTexture[72] = Content.Load<Texture2D>("images/greathunter_plains_r4");
            thingTexture[73] = Content.Load<Texture2D>("images/greatowl_forest_2");
            thingTexture[74] = Content.Load<Texture2D>("images/greenknight_forest_c4");
            thingTexture[75] = Content.Load<Texture2D>("images/griffon_desert_2");
            thingTexture[76] = Content.Load<Texture2D>("images/gypsies_plains_1");
            thingTexture[77] = Content.Load<Texture2D>("images/gypsies_plains_2");
            thingTexture[78] = Content.Load<Texture2D>("images/headhunter_jungle_r2");
            thingTexture[79] = Content.Load<Texture2D>("images/hugeleech_swamp_2");
            thingTexture[80] = Content.Load<Texture2D>("images/hunters_plains_r1");

            thingTexture[81] = Content.Load<Texture2D>("images/icebats_frozenwaste_1");            
            thingTexture[82] = Content.Load<Texture2D>("images/icegiant_frozenwaste_r5");
            thingTexture[83] = Content.Load<Texture2D>("images/iceworm_frozenwaste_4");
            thingTexture[84] = Content.Load<Texture2D>("images/killerpenguins_frozenwaste_3");
            thingTexture[85] = Content.Load<Texture2D>("images/killerpuffins_frozenwaste_2");
            thingTexture[86] = Content.Load<Texture2D>("images/killerracoon_forest_2");
            thingTexture[87] = Content.Load<Texture2D>("images/lionpride_plains_3");
            thingTexture[88] = Content.Load<Texture2D>("images/littleroc_mountain_2");
            thingTexture[89] = Content.Load<Texture2D>("images/mammoth_frozenwaste_c5");
            thingTexture[90] = Content.Load<Texture2D>("images/mountainlion_mountain_2");

            thingTexture[91] = Content.Load<Texture2D>("images/mountainmen_mountain_1");
            thingTexture[92] = Content.Load<Texture2D>("images/mountainmen_mountain_1_2");
            thingTexture[93] = Content.Load<Texture2D>("images/nomads_desert_1");
            thingTexture[94] = Content.Load<Texture2D>("images/nomads_desert_1_2");
            thingTexture[95] = Content.Load<Texture2D>("images/northwind_frozenwaste_2");
            thingTexture[96] = Content.Load<Texture2D>("images/ogre_mountain_2");
            thingTexture[97] = Content.Load<Texture2D>("images/oilfield_frozenwaste_3g");
            thingTexture[98] = Content.Load<Texture2D>("images/olddragon_desert_4");
            thingTexture[99] = Content.Load<Texture2D>("images/pegasus_plains_2");
            thingTexture[100] = Content.Load<Texture2D>("images/pirates_swamp_2");

            thingTexture[101] = Content.Load<Texture2D>("images/pixies_forest_1");
            thingTexture[102] = Content.Load<Texture2D>("images/pixies_forest_1_2");
            thingTexture[103] = Content.Load<Texture2D>("images/poisonfrog_swamp_1");
            thingTexture[104] = Content.Load<Texture2D>("images/pterodactyl_plains_3");
            thingTexture[105] = Content.Load<Texture2D>("images/pterodactylwarriors_jungle_r2");
            thingTexture[106] = Content.Load<Texture2D>("images/pterodactylwarriors_jungle_r2_2");
            thingTexture[107] = Content.Load<Texture2D>("images/pygmies_jungle_2");
            thingTexture[108] = Content.Load<Texture2D>("images/sandworm_desert_3");
            thingTexture[109] = Content.Load<Texture2D>("images/skeletons_desert_1");
            thingTexture[110] = Content.Load<Texture2D>("images/slimebeast_swamp_3");

            thingTexture[111] = Content.Load<Texture2D>("images/sphinx_desert_4");
            thingTexture[112] = Content.Load<Texture2D>("images/spirit_swamp_2");
            thingTexture[113] = Content.Load<Texture2D>("images/sprite_swamp_1");
            thingTexture[114] = Content.Load<Texture2D>("images/swampgas_swamp_1");
            thingTexture[115] = Content.Load<Texture2D>("images/swamprat_swamp_1");
            thingTexture[116] = Content.Load<Texture2D>("images/thing_swamp_2");
            thingTexture[117] = Content.Load<Texture2D>("images/tigers_jungle_3");
            thingTexture[118] = Content.Load<Texture2D>("images/tigers_jungle_3_2");
            thingTexture[119] = Content.Load<Texture2D>("images/tribesmen_plains_2");
            thingTexture[120] = Content.Load<Texture2D>("images/tribesmen_plains_2_2");

            thingTexture[121] = Content.Load<Texture2D>("images/tribesmen_plains_r1");         
            thingTexture[122] = Content.Load<Texture2D>("images/troll_mountain_4");
            thingTexture[123] = Content.Load<Texture2D>("images/unicorn_forest_4");
            thingTexture[124] = Content.Load<Texture2D>("images/vampirebat_swamp_4");
            thingTexture[125] = Content.Load<Texture2D>("images/villains_plains_2");
            thingTexture[126] = Content.Load<Texture2D>("images/vultures_desert_1");
            thingTexture[127] = Content.Load<Texture2D>("images/walkingtree_forest_5");
            thingTexture[128] = Content.Load<Texture2D>("images/walrus_frozenwaste_4");
            thingTexture[129] = Content.Load<Texture2D>("images/watersnake_swamp_1");
            thingTexture[130] = Content.Load<Texture2D>("images/watusi_jungle_2");

            thingTexture[131] = Content.Load<Texture2D>("images/whitebear_frozenwaste_4");
            thingTexture[132] = Content.Load<Texture2D>("images/whitedragon_frozenwaste_5");
            thingTexture[133] = Content.Load<Texture2D>("images/whiteknight_plains_c3");
            thingTexture[134] = Content.Load<Texture2D>("images/wildcat_forest_2");
            thingTexture[135] = Content.Load<Texture2D>("images/willowisp_swamp_2");
            thingTexture[136] = Content.Load<Texture2D>("images/wingedpirhana_swamp_3");
            thingTexture[137] = Content.Load<Texture2D>("images/witchdoctor_jungle_2");
            thingTexture[138] = Content.Load<Texture2D>("images/wolfpack_plains_3");
            thingTexture[139] = Content.Load<Texture2D>("images/wolves_frozenwaste_3");
            thingTexture[140] = Content.Load<Texture2D>("images/wyvern_forest_3");

            thingTexture[141] = Content.Load<Texture2D>("images/yellowknight_desert_c3");
            thingTexture[142] = Content.Load<Texture2D>("images/whitedragon_frozenwaste_5");
            thingTexture[143] = Content.Load<Texture2D>("images/whiteknight_plains_c3");
            thingTexture[144] = Content.Load<Texture2D>("images/wildcat_forest_2");

            fortTexture[0] = Content.Load<Texture2D>("images/tower");
            fortTexture[1] = Content.Load<Texture2D>("images/keep");
            fortTexture[2] = Content.Load<Texture2D>("images/castle");
            fortTexture[3] = Content.Load<Texture2D>("images/citadel");

            marker.Add(new MarkerButton(markerTexture[0], _theGameBoard.getPlayers()[0], spriteBatch, 30, 30, 645, 570));
            marker.Add(new MarkerButton(markerTexture[1], _theGameBoard.getPlayers()[1], spriteBatch, 30, 30, 645, 610));
            marker.Add(new MarkerButton(markerTexture[2], _theGameBoard.getPlayers()[2], spriteBatch, 30, 30, 645, 650));
            marker.Add(new MarkerButton(markerTexture[3], _theGameBoard.getPlayers()[3], spriteBatch, 30, 30, 645, 690));

            marker.Add(new MarkerButton(markerTexture[0], _theGameBoard.getPlayers()[0], spriteBatch, 30, 30, 685, 570));
            marker.Add(new MarkerButton(markerTexture[1], _theGameBoard.getPlayers()[1], spriteBatch, 30, 30, 685, 610));
            marker.Add(new MarkerButton(markerTexture[2], _theGameBoard.getPlayers()[2], spriteBatch, 30, 30, 685, 650));
            marker.Add(new MarkerButton(markerTexture[3], _theGameBoard.getPlayers()[3], spriteBatch, 30, 30, 685, 690));

            marker.Add(new MarkerButton(markerTexture[0], _theGameBoard.getPlayers()[0], spriteBatch, 30, 30, 725, 570));
            marker.Add(new MarkerButton(markerTexture[1], _theGameBoard.getPlayers()[1], spriteBatch, 30, 30, 725, 610));
            marker.Add(new MarkerButton(markerTexture[2], _theGameBoard.getPlayers()[2], spriteBatch, 30, 30, 725, 650));
            marker.Add(new MarkerButton(markerTexture[3], _theGameBoard.getPlayers()[3], spriteBatch, 30, 30, 725, 690));

            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 260, 400, _theGameBoard.getMap().getHexList()[0], fortTexture));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 260, 300, _theGameBoard.getMap().getHexList()[1], fortTexture));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 340, 350, _theGameBoard.getMap().getHexList()[2], fortTexture));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 340, 450, _theGameBoard.getMap().getHexList()[3], fortTexture));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 260, 500, _theGameBoard.getMap().getHexList()[4], fortTexture));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 180, 450, _theGameBoard.getMap().getHexList()[5], fortTexture));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 180, 350, _theGameBoard.getMap().getHexList()[6], fortTexture));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 180, 250, _theGameBoard.getMap().getHexList()[7], fortTexture));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 260, 200, _theGameBoard.getMap().getHexList()[8], fortTexture));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 340, 250, _theGameBoard.getMap().getHexList()[9], fortTexture));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 420, 300, _theGameBoard.getMap().getHexList()[10], fortTexture));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 420, 400, _theGameBoard.getMap().getHexList()[11], fortTexture));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 420, 500, _theGameBoard.getMap().getHexList()[12], fortTexture));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 340, 550, _theGameBoard.getMap().getHexList()[13], fortTexture));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 260, 600, _theGameBoard.getMap().getHexList()[14], fortTexture));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 180, 550, _theGameBoard.getMap().getHexList()[15], fortTexture));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 100, 500, _theGameBoard.getMap().getHexList()[16], fortTexture));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 100, 400, _theGameBoard.getMap().getHexList()[17], fortTexture));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 100, 300, _theGameBoard.getMap().getHexList()[18], fortTexture));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 100, 200, _theGameBoard.getMap().getHexList()[19], fortTexture));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 180, 150, _theGameBoard.getMap().getHexList()[20], fortTexture));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 260, 100, _theGameBoard.getMap().getHexList()[21], fortTexture));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 340, 150, _theGameBoard.getMap().getHexList()[22], fortTexture));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 420, 200, _theGameBoard.getMap().getHexList()[23], fortTexture));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 500, 250, _theGameBoard.getMap().getHexList()[24], fortTexture));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 500, 350, _theGameBoard.getMap().getHexList()[25], fortTexture));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 500, 450, _theGameBoard.getMap().getHexList()[26], fortTexture));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 500, 550, _theGameBoard.getMap().getHexList()[27], fortTexture));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 420, 600, _theGameBoard.getMap().getHexList()[28], fortTexture));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 340, 650, _theGameBoard.getMap().getHexList()[29], fortTexture));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 260, 700, _theGameBoard.getMap().getHexList()[30], fortTexture));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 180, 650, _theGameBoard.getMap().getHexList()[31], fortTexture));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 100, 600, _theGameBoard.getMap().getHexList()[32], fortTexture));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 20, 550, _theGameBoard.getMap().getHexList()[33], fortTexture));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 20, 450, _theGameBoard.getMap().getHexList()[34], fortTexture));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 20, 350, _theGameBoard.getMap().getHexList()[35], fortTexture));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 20, 250, _theGameBoard.getMap().getHexList()[36], fortTexture));

            rollbutton = new DiceRollButton(roll, spriteBatch, 140, 50, 500, 25, font);
            endButton = new EndButton(endTexture, spriteBatch, 140, 50, 340, 25);
            recruitButton = new RecruitButton(Content.Load<Texture2D>("images/recruit"), spriteBatch, 140, 50, 180, 25);

            Thing thing = GameBoard.Game.getRandomThingFromCup();
            P1Tiles.Add(new ThingButton(thingTexture[thing.getTextureID()], _theGameBoard.getPlayers()[0], spriteBatch, thing, 30, 30, 675, 5));
            thing = GameBoard.Game.getRandomThingFromCup();
            P1Tiles.Add(new ThingButton(thingTexture[thing.getTextureID()], _theGameBoard.getPlayers()[0], spriteBatch, thing, 30, 30, 735, 5));
            thing = GameBoard.Game.getRandomThingFromCup();
            P1Tiles.Add(new ThingButton(thingTexture[thing.getTextureID()], _theGameBoard.getPlayers()[0], spriteBatch, thing, 30, 30, 785, 5));
            thing = GameBoard.Game.getRandomThingFromCup();
            P1Tiles.Add(new ThingButton(thingTexture[thing.getTextureID()], _theGameBoard.getPlayers()[0], spriteBatch, thing, 30, 30, 845, 5));
            thing = GameBoard.Game.getRandomThingFromCup();
            P1Tiles.Add(new ThingButton(thingTexture[thing.getTextureID()], _theGameBoard.getPlayers()[0], spriteBatch, thing, 30, 30, 905, 5));

            thing = GameBoard.Game.getRandomThingFromCup();
            P1Tiles.Add(new ThingButton(thingTexture[thing.getTextureID()], _theGameBoard.getPlayers()[0], spriteBatch, thing, 30, 30, 675, 55));
            thing = GameBoard.Game.getRandomThingFromCup();
            P1Tiles.Add(new ThingButton(thingTexture[thing.getTextureID()], _theGameBoard.getPlayers()[0], spriteBatch, thing, 30, 30, 735, 55));
            thing = GameBoard.Game.getRandomThingFromCup();
            P1Tiles.Add(new ThingButton(thingTexture[thing.getTextureID()], _theGameBoard.getPlayers()[0], spriteBatch, thing, 30, 30, 785, 55));
            thing = GameBoard.Game.getRandomThingFromCup();
            P1Tiles.Add(new ThingButton(thingTexture[thing.getTextureID()], _theGameBoard.getPlayers()[0], spriteBatch, thing, 30, 30, 845, 55));
            thing = GameBoard.Game.getRandomThingFromCup();
            P1Tiles.Add(new ThingButton(thingTexture[thing.getTextureID()], _theGameBoard.getPlayers()[0], spriteBatch, thing, 30, 30, 905, 55));

            thing = GameBoard.Game.getRandomThingFromCup();
            P2Tiles.Add(new ThingButton(thingTexture[thing.getTextureID()], _theGameBoard.getPlayers()[1], spriteBatch, thing, 30, 30, 675, 140));
            thing = GameBoard.Game.getRandomThingFromCup();
            P2Tiles.Add(new ThingButton(thingTexture[thing.getTextureID()], _theGameBoard.getPlayers()[1], spriteBatch, thing, 30, 30, 735, 140));
            thing = GameBoard.Game.getRandomThingFromCup();
            P2Tiles.Add(new ThingButton(thingTexture[thing.getTextureID()], _theGameBoard.getPlayers()[1], spriteBatch, thing, 30, 30, 785, 140));
            thing = GameBoard.Game.getRandomThingFromCup();
            P2Tiles.Add(new ThingButton(thingTexture[thing.getTextureID()], _theGameBoard.getPlayers()[1], spriteBatch, thing, 30, 30, 845, 140));
            thing = GameBoard.Game.getRandomThingFromCup();
            P2Tiles.Add(new ThingButton(thingTexture[thing.getTextureID()], _theGameBoard.getPlayers()[1], spriteBatch, thing, 30, 30, 905, 140));

            thing = GameBoard.Game.getRandomThingFromCup();
            P2Tiles.Add(new ThingButton(thingTexture[thing.getTextureID()], _theGameBoard.getPlayers()[1], spriteBatch, thing, 30, 30, 675, 190));
            thing = GameBoard.Game.getRandomThingFromCup();
            P2Tiles.Add(new ThingButton(thingTexture[thing.getTextureID()], _theGameBoard.getPlayers()[1], spriteBatch, thing, 30, 30, 735, 190));
            thing = GameBoard.Game.getRandomThingFromCup();
            P2Tiles.Add(new ThingButton(thingTexture[thing.getTextureID()], _theGameBoard.getPlayers()[1], spriteBatch, thing, 30, 30, 785, 190));
            thing = GameBoard.Game.getRandomThingFromCup();
            P2Tiles.Add(new ThingButton(thingTexture[thing.getTextureID()], _theGameBoard.getPlayers()[1], spriteBatch, thing, 30, 30, 845, 190));
            thing = GameBoard.Game.getRandomThingFromCup();
            P2Tiles.Add(new ThingButton(thingTexture[thing.getTextureID()], _theGameBoard.getPlayers()[1], spriteBatch, thing, 30, 30, 905, 190));

            thing = GameBoard.Game.getRandomThingFromCup();
            P3Tiles.Add(new ThingButton(thingTexture[thing.getTextureID()], _theGameBoard.getPlayers()[2], spriteBatch, thing, 30, 30, 675, 275));
            thing = GameBoard.Game.getRandomThingFromCup();
            P3Tiles.Add(new ThingButton(thingTexture[thing.getTextureID()], _theGameBoard.getPlayers()[2], spriteBatch, thing, 30, 30, 735, 275));
            thing = GameBoard.Game.getRandomThingFromCup();
            P3Tiles.Add(new ThingButton(thingTexture[thing.getTextureID()], _theGameBoard.getPlayers()[2], spriteBatch, thing, 30, 30, 785, 275));
            thing = GameBoard.Game.getRandomThingFromCup();
            P3Tiles.Add(new ThingButton(thingTexture[thing.getTextureID()], _theGameBoard.getPlayers()[2], spriteBatch, thing, 30, 30, 845, 275));
            thing = GameBoard.Game.getRandomThingFromCup();
            P3Tiles.Add(new ThingButton(thingTexture[thing.getTextureID()], _theGameBoard.getPlayers()[2], spriteBatch, thing, 30, 30, 905, 275));

            thing = GameBoard.Game.getRandomThingFromCup();
            P3Tiles.Add(new ThingButton(thingTexture[thing.getTextureID()], _theGameBoard.getPlayers()[2], spriteBatch, thing, 30, 30, 675, 325));
            thing = GameBoard.Game.getRandomThingFromCup();
            P3Tiles.Add(new ThingButton(thingTexture[thing.getTextureID()], _theGameBoard.getPlayers()[2], spriteBatch, thing, 30, 30, 735, 325));
            thing = GameBoard.Game.getRandomThingFromCup();
            P3Tiles.Add(new ThingButton(thingTexture[thing.getTextureID()], _theGameBoard.getPlayers()[2], spriteBatch, thing, 30, 30, 785, 325));
            thing = GameBoard.Game.getRandomThingFromCup();
            P3Tiles.Add(new ThingButton(thingTexture[thing.getTextureID()], _theGameBoard.getPlayers()[2], spriteBatch, thing, 30, 30, 845, 325));
            thing = GameBoard.Game.getRandomThingFromCup();
            P3Tiles.Add(new ThingButton(thingTexture[thing.getTextureID()], _theGameBoard.getPlayers()[2], spriteBatch, thing, 30, 30, 905, 325));

            thing = GameBoard.Game.getRandomThingFromCup();
            P4Tiles.Add(new ThingButton(thingTexture[thing.getTextureID()], _theGameBoard.getPlayers()[3], spriteBatch, thing, 30, 30, 675, 410));
            thing = GameBoard.Game.getRandomThingFromCup();
            P4Tiles.Add(new ThingButton(thingTexture[thing.getTextureID()], _theGameBoard.getPlayers()[3], spriteBatch, thing, 30, 30, 735, 410));
            thing = GameBoard.Game.getRandomThingFromCup();
            P4Tiles.Add(new ThingButton(thingTexture[thing.getTextureID()], _theGameBoard.getPlayers()[3], spriteBatch, thing, 30, 30, 785, 410));
            thing = GameBoard.Game.getRandomThingFromCup();
            P4Tiles.Add(new ThingButton(thingTexture[thing.getTextureID()], _theGameBoard.getPlayers()[3], spriteBatch, thing, 30, 30, 845, 410));
            thing = GameBoard.Game.getRandomThingFromCup();
            P4Tiles.Add(new ThingButton(thingTexture[thing.getTextureID()], _theGameBoard.getPlayers()[3], spriteBatch, thing, 30, 30, 905, 410));

            thing = GameBoard.Game.getRandomThingFromCup();
            P4Tiles.Add(new ThingButton(thingTexture[thing.getTextureID()], _theGameBoard.getPlayers()[3], spriteBatch, thing, 30, 30, 675, 460));
            thing = GameBoard.Game.getRandomThingFromCup();
            P4Tiles.Add(new ThingButton(thingTexture[thing.getTextureID()], _theGameBoard.getPlayers()[3], spriteBatch, thing, 30, 30, 735, 460));
            thing = GameBoard.Game.getRandomThingFromCup();
            P4Tiles.Add(new ThingButton(thingTexture[thing.getTextureID()], _theGameBoard.getPlayers()[3], spriteBatch, thing, 30, 30, 785, 460));
            thing = GameBoard.Game.getRandomThingFromCup();
            P4Tiles.Add(new ThingButton(thingTexture[thing.getTextureID()], _theGameBoard.getPlayers()[3], spriteBatch, thing, 30, 30, 845, 460));
            thing = GameBoard.Game.getRandomThingFromCup();
            P4Tiles.Add(new ThingButton(thingTexture[thing.getTextureID()], _theGameBoard.getPlayers()[3], spriteBatch, thing, 30, 30, 905, 460));//P1Tiles.Add(new Button(
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            KeyboardState state = Keyboard.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || state.IsKeyDown(Keys.Escape))
                this.Exit();

            UpdateButtons();

            switch(_theGameBoard.getCurrentPhase())
            {
                case "Setup":
                    currentPhase.playPhase(_theGameBoard.getPlayers());
                    me = currentPhase.getCurrentPlayer();
                    //Console.WriteLine(me.getName());
                    break;
                case "Gold Collection":
                    currentPhase.playPhase(_theGameBoard.getPlayers());
                    me = currentPhase.getCurrentPlayer();
                    //Console.WriteLine(me.getName());
                    break;
                case "Recruit Things":
                    currentPhase.playPhase(_theGameBoard.getPlayers());
                        if( me.getInPhase() )
                            ((RecruitThingsPhase)currentPhase).recruitThings();
                    me = currentPhase.getCurrentPlayer();
                    //Console.WriteLine(me.getName());
                    break;
                case "Movement":
                    Console.WriteLine("Movement");
                    currentPhase.playPhase(_theGameBoard.getPlayers());
                    me = currentPhase.getCurrentPlayer();
                    //Console.WriteLine(me.getName());
                    break;
                case "Combat":
                    currentPhase.playPhase(_theGameBoard.getPlayers());
                    me = currentPhase.getCurrentPlayer();
                    break;
                case "Construction":
                    currentPhase.playPhase(_theGameBoard.getPlayers());
                    me = currentPhase.getCurrentPlayer();
                    break;
            }

            if (currentPhase.getCurrentState() == Phase.State.END)
                currentPhase = _theGameBoard.play();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            
            DrawBoard();



            base.Draw(gameTime);
        }

        private void UpdateButtons()
        {
            foreach (Button b in P1Tiles)
                b.Update();

            foreach (Button b in P2Tiles)
                b.Update();

            foreach (Button b in P3Tiles)
                b.Update();

            foreach (Button b in P4Tiles)
                b.Update();
            
            hex[0].Update();
            hex[1].Update();
            hex[2].Update();
            hex[3].Update();
            hex[4].Update();
            hex[5].Update();
            hex[6].Update();
            hex[7].Update();
            hex[8].Update();
            hex[9].Update();
            hex[10].Update();
            hex[11].Update();
            hex[12].Update();
            hex[13].Update();
            hex[14].Update();
            hex[15].Update();
            hex[16].Update();
            hex[17].Update();
            hex[18].Update();
            hex[19].Update();
            hex[20].Update();
            hex[21].Update();
            hex[22].Update();
            hex[23].Update();
            hex[24].Update();
            hex[25].Update();
            hex[26].Update();
            hex[27].Update();
            hex[28].Update();
            hex[29].Update();
            hex[30].Update();
            hex[31].Update();
            hex[32].Update();
            hex[33].Update();
            hex[34].Update();
            hex[35].Update();
            hex[36].Update();

            foreach (Button m in marker)
                m.Update();

            foreach (Button b in StackButtons)
                b.Update();

            rollbutton.Update();
            endButton.Update();
            recruitButton.Update();

        }

        private void DrawBoard()
        {
            spriteBatch.Begin();

            spriteBatch.Draw(board, new Rectangle(0, 0, 1000, 800), Color.White);
            spriteBatch.Draw(rack, new Rectangle(630, 0, 350, 100), Color.White);
            spriteBatch.Draw(rack, new Rectangle(630, 135, 350, 100), Color.White);
            spriteBatch.Draw(rack, new Rectangle(630, 270, 350, 100), Color.White);
            spriteBatch.Draw(rack, new Rectangle(630, 405, 350, 100), Color.White);

            DrawText();
            spriteBatch.End();
            
            hex[0].Draw();
            hex[1].Draw();
            hex[2].Draw();
            hex[3].Draw();
            hex[4].Draw();
            hex[5].Draw();
            hex[6].Draw();
            hex[7].Draw();
            hex[8].Draw();
            hex[9].Draw();
            hex[10].Draw();
            hex[11].Draw();
            hex[12].Draw();
            hex[13].Draw();
            hex[14].Draw();
            hex[15].Draw();
            hex[16].Draw();
            hex[17].Draw();
            hex[18].Draw();
            hex[19].Draw();
            hex[20].Draw();
            hex[21].Draw();
            hex[22].Draw();
            hex[23].Draw();
            hex[24].Draw();
            hex[25].Draw();
            hex[26].Draw();
            hex[27].Draw();
            hex[28].Draw();
            hex[29].Draw();
            hex[30].Draw();
            hex[31].Draw();
            hex[32].Draw();
            hex[33].Draw();
            hex[34].Draw();
            hex[35].Draw();
            hex[36].Draw();

            foreach (Button m in marker)
                m.Draw();

            rollbutton.Draw();
            endButton.Draw();
            recruitButton.Draw();

            foreach (Button b in StackButtons)
                b.Draw();

            foreach (Button b in P1Tiles)
                b.Draw();

            foreach (Button b in P2Tiles)
                b.Draw();

            foreach (Button b in P3Tiles)
                b.Draw();

            foreach (Button b in P4Tiles)
                b.Draw();
        }

        private void DrawText()
        {
            MouseState mouse = Mouse.GetState();
            spriteBatch.DrawString(font, "MouseX = " + mouse.X, new Vector2(20, 45), Color.Black);
            spriteBatch.DrawString(font, "MouseY = " + mouse.Y, new Vector2(20, 70), Color.Black);
            spriteBatch.DrawString(font, String.Format("Phase : {0}", _theGameBoard.getCurrentPhase()), new Vector2(10, 1), Color.Black);


            foreach (Player p in _theGameBoard.getPlayers())
            {
                if( me != null && p.getName() == me.getName() )
                    spriteBatch.DrawString(font, String.Format("{0} Gold : {1}", p.getName(), p.getGold()), new Vector2(Player.goldX, p.goldY), Color.Blue);
                else
                    spriteBatch.DrawString(font, String.Format("{0} Gold : {1}", p.getName(), p.getGold()), new Vector2(Player.goldX, p.goldY), Color.Black);
            }

        }

        public static MarkerButton getMyMarker()
        {
            foreach(MarkerButton b in marker)
            {
                if (me.containsMarkerID(b.getButtonID()) &&
                    me.handsFull() &&
                    b.getMarkerSelected())
                    return b;
            }

            return null;
        }

        public static void setButtonInHand(Button b)
        {
            buttonInHand = b;
            me.setHandsFull(true);
        }

        public static void emptyHand()
        {
            buttonInHand = null;
            me.setHandsFull(false);
        }

        public static Button getButtonInHand()
        {
            return buttonInHand;
        }

        public static void createMarker(Point topLeft, int p, SpriteBatch s)
        {
            MarkerButton markerB;
            markerB = new MarkerButton(markerTexture[p - 1], GameBoard.Game.getPlayers()[p - 1], s, 30, 30, topLeft.X + 25, topLeft.Y + 5);
            marker.Add(markerB);
            KNT_Game.me.placeMarker(markerB.getButtonID());
        }

        public static StackButton createStack(Tile hex, Thing t, SpriteBatch s)
        {
            StackButton stackB = new StackButton(stackTexture, me, s, t, hex, 30, 30, 0, 0);
            StackButtons.Add(stackB);
            return stackB;
        }

        public static StackButton createStack(Tile hex, List<Thing> t, SpriteBatch s)
        {
            StackButton stackB = new StackButton(stackTexture, me, s, t, hex, 30, 30, 0, 0);
            StackButtons.Add(stackB);
            return stackB;
        }

        public static void removeStack(StackButton s)
        {
            StackButtons.Remove(s);
        }

        public static void putStackInHand(List<Thing> s)
        {
            stackInHand = new List<Thing>();
            foreach(Thing t in s)
            {
                stackInHand.Add(t);
            }
            me.setHandsFull(true);
        }

        public static List<Thing> getStackInHand()
        {
            me.setHandsFull(false);
            return stackInHand;
        }
             
    }
}