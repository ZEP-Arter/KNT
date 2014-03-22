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
using KNT_Client.Networkable;
using KingsNThings.Buttons;

namespace KingsNThings.GUI
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public abstract class KNT_Game : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont font;

        #region Textures
        // Textures \\
        private Texture2D board;
        private Texture2D roll;
        private Texture2D rack;
        private Texture2D endTexture;
        private static Texture2D stackTexture;
        private Texture2D[] hexTexture = new Texture2D[9];
        private Texture2D[] goldTexture = new Texture2D[6];
        private Texture2D[] markerTexture = new Texture2D[4];
        public static Texture2D[] scripttileTexture = new Texture2D[40];
        // end Textures \\ 
        #endregion

        #region Buttons
        //Button hex1, hex2, hex3, hex4, hex5, hex6, hex7, hex8, hex9, hex10, hex11, hex12, hex13, hex14, hex15, hex16, hex17, hex18, hex19, hex20, hex21, hex22, hex23, hex24, hex25, hex26, hex27, hex28, hex29, hex30, hex31, hex32, hex33, hex34, hex35, hex36, hex37;
        Button rollbutton;
        Button endButton;

        public static List<Button> StackButtons = new List<Button>();

        static List<Button> marker = new List<Button>();

        public static List<Button> P1Tiles = new List<Button>();
        public static List<Button> P2Tiles = new List<Button>();
        public static List<Button> P3Tiles = new List<Button>();
        public static List<Button> P4Tiles = new List<Button>();

        List<Button> hex = new List<Button>();

        Button recruitButton;
        public static Button buttonInHand;
        #endregion


        public static Player me;

        public static KNT_Client.KNT_ServiceReference.KNTNetClient client;

        bool positionsSet;
        bool markersSet;
        GameLogic.Phases.Phase currentPhase;

        protected static Board gameBoard;

        public KNT_Game()
        {

            client = new KNT_Client.KNT_ServiceReference.KNTNetClient();
            KNT_Client.KNT_ServiceReference.Player player = client.connect("Eric");
            GameController.CreateGame(client.getPlayers(), client.getMap(), client.getCup(), client.getBank());
            me = GameController.Game.getPlayer(player);

            gameBoard = GameController.Game.getMap();

            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferHeight = 800;
            graphics.PreferredBackBufferWidth = 1000;
            graphics.ApplyChanges();
            positionsSet = false;
            markersSet = false;
            currentPhase = GameLogic.Managers.PhaseManager.PhManager.getCurrentPhase();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            this.IsMouseVisible = true;

            base.Initialize();
        }

        protected void init()
        {
            int[] markerLocations = new int[] { 570, 610, 650, 690 };

            int playerNumber = me.getPlayerNumber() - 1;

            marker.Add(new MarkerButton(markerTexture[playerNumber], me, spriteBatch, 30, 30, 645, markerLocations[playerNumber]));
            marker.Add(new MarkerButton(markerTexture[playerNumber], me, spriteBatch, 30, 30, 685, markerLocations[playerNumber]));
            marker.Add(new MarkerButton(markerTexture[playerNumber], me, spriteBatch, 30, 30, 725, markerLocations[playerNumber]));
  
            //marker.Add(new MarkerButton(markerTexture[1], GameBoard.Game.getPlayers()[1], spriteBatch, 30, 30, 645, 610));
            //marker.Add(new MarkerButton(markerTexture[2], GameBoard.Game.getPlayers()[2], spriteBatch, 30, 30, 645, 650));
            //marker.Add(new MarkerButton(markerTexture[3], GameBoard.Game.getPlayers()[3], spriteBatch, 30, 30, 645, 690));

            //marker.Add(new MarkerButton(markerTexture[1], GameBoard.Game.getPlayers()[1], spriteBatch, 30, 30, 685, 610));
            //marker.Add(new MarkerButton(markerTexture[2], GameBoard.Game.getPlayers()[2], spriteBatch, 30, 30, 685, 650));
            //marker.Add(new MarkerButton(markerTexture[3], GameBoard.Game.getPlayers()[3], spriteBatch, 30, 30, 685, 690));

            //marker.Add(new MarkerButton(markerTexture[1], GameBoard.Game.getPlayers()[1], spriteBatch, 30, 30, 725, 610));
            //marker.Add(new MarkerButton(markerTexture[2], GameBoard.Game.getPlayers()[2], spriteBatch, 30, 30, 725, 650));
            //marker.Add(new MarkerButton(markerTexture[3], GameBoard.Game.getPlayers()[3], spriteBatch, 30, 30, 725, 690));
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

            scripttileTexture[0] = Content.Load<Texture2D>("images/cyclops_mountain_5");
            scripttileTexture[1] = Content.Load<Texture2D>("images/mountainmen_mountain_1");
            scripttileTexture[2] = Content.Load<Texture2D>("images/goblins_mountain_1");
            scripttileTexture[3] = Content.Load<Texture2D>("images/giantspider_desert_1");
            scripttileTexture[4] = Content.Load<Texture2D>("images/elephant_jungle_c4");
            scripttileTexture[5] = Content.Load<Texture2D>("images/brownknight_mountain_c4");
            scripttileTexture[6] = Content.Load<Texture2D>("images/giant_mountain_r4");
            scripttileTexture[7] = Content.Load<Texture2D>("images/dwarves_mountain_r2");
            scripttileTexture[8] = Content.Load<Texture2D>("images/skeletons_desert_1");
            scripttileTexture[9] = Content.Load<Texture2D>("images/watusi_jungle_2");
            scripttileTexture[10] = Content.Load<Texture2D>("images/ogre_mountain_2");

            scripttileTexture[11] = Content.Load<Texture2D>("images/pterodactylwarriors_jungle_r2");
            scripttileTexture[12] = Content.Load<Texture2D>("images/sandworm_desert_3");
            scripttileTexture[13] = Content.Load<Texture2D>("images/greenknight_forest_c4");
            scripttileTexture[14] = Content.Load<Texture2D>("images/dervish_desert_2");
            scripttileTexture[15] = Content.Load<Texture2D>("images/crocodiles_jungle_2");
            scripttileTexture[16] = Content.Load<Texture2D>("images/nomads_desert_1");
            scripttileTexture[17] = Content.Load<Texture2D>("images/druid_forest_3");
            scripttileTexture[18] = Content.Load<Texture2D>("images/crawlingvines_jungle_6");
            scripttileTexture[19] = Content.Load<Texture2D>("images/bandits_forest_2");
            scripttileTexture[20] = Content.Load<Texture2D>("images/goblins_mountain_1");

            scripttileTexture[21] = Content.Load<Texture2D>("images/centaur_plains_2");
            scripttileTexture[22] = Content.Load<Texture2D>("images/camelcorps_desert_3");
            scripttileTexture[23] = Content.Load<Texture2D>("images/farmers_plains_1_1");
            scripttileTexture[24] = Content.Load<Texture2D>("images/genie_desert_4");
            scripttileTexture[25] = Content.Load<Texture2D>("images/skeletons_desert_1");
            scripttileTexture[26] = Content.Load<Texture2D>("images/pygmies_jungle_2");
            scripttileTexture[27] = Content.Load<Texture2D>("images/greathunter_plains_r4");
            scripttileTexture[28] = Content.Load<Texture2D>("images/witchdoctor_jungle_2");
            scripttileTexture[29] = Content.Load<Texture2D>("images/tribesmen_plains_2");
            scripttileTexture[30] = Content.Load<Texture2D>("images/giantlizard_swamp_2");

            scripttileTexture[31] = Content.Load<Texture2D>("images/villains_plains_2");
            scripttileTexture[32] = Content.Load<Texture2D>("images/tigers_jungle_3");
            scripttileTexture[33] = Content.Load<Texture2D>("images/darkwizard_swamp_1");
            scripttileTexture[34] = Content.Load<Texture2D>("images/blackknight_swamp_c3");
            scripttileTexture[35] = Content.Load<Texture2D>("images/giantape_jungle_5");
            scripttileTexture[36] = Content.Load<Texture2D>("images/buffaloherd_plains_3");
            scripttileTexture[37] = Content.Load<Texture2D>("images/vampirebat_swamp_4");
            scripttileTexture[38] = Content.Load<Texture2D>("images/olddragon_desert_4");
            scripttileTexture[39] = Content.Load<Texture2D>("images/walkingtree_forest_5");
            //need Old Dragon, Walking Tree, vampirebat
            /////////////////////////////////HEX BUTTONS\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
            /*hex37 = new Button(hexTexture[1], spriteBatch, 110, 100, 1, 20, 250, 37); //37 Buttons
            hex36 = new Button(hexTexture[3], spriteBatch, 110, 100, 1, 20, 350, 36);//36
            hex35 = new Button(hexTexture[2], spriteBatch, 110, 100, 1, 20, 450, 35);//35
            hex34 = new Button(hexTexture[5], spriteBatch, 110, 100, 1, 20, 550, 34);//34

            hex20 = new Button(hexTexture[8], spriteBatch, 110, 100, 1, 100, 200, 20);//20
            hex19 = new Button(hexTexture[4], spriteBatch, 110, 100, 1, 100, 300, 19);//19
            hex18 = new Button(hexTexture[5], spriteBatch, 110, 100, 1, 100, 400, 18);//18
            hex17 = new Button(hexTexture[6], spriteBatch, 110, 100, 1, 100, 500, 17);//17
            hex33 = new Button(hexTexture[4], spriteBatch, 110, 100, 1, 100, 600, 33);//33

            hex21 = new Button(hexTexture[5], spriteBatch, 110, 100, 1, 180, 150, 21);//21
            hex8 = new Button(hexTexture[6], spriteBatch, 110, 100, 1, 180, 250, 8);//8
            hex7 = new Button(hexTexture[8], spriteBatch, 110, 100, 1, 180, 350, 7);//7
            hex6 = new Button(hexTexture[2], spriteBatch, 110, 100, 1, 180, 450, 6);//6
            hex16 = new Button(hexTexture[1], spriteBatch, 110, 100, 1, 180, 550, 16);//16
            hex32 = new Button(hexTexture[6], spriteBatch, 110, 100, 1, 180, 650, 32);//32

            hex22 = new Button(hexTexture[4], spriteBatch, 110, 100, 1, 260, 100, 22);//22
            hex9 = new Button(hexTexture[3], spriteBatch, 110, 100, 1, 260, 200, 9);//9
            hex2 = new Button(hexTexture[2], spriteBatch, 110, 100, 1, 260, 300, 2);//2
            hex1 = new Button(hexTexture[3], spriteBatch, 110, 100, 1, 260, 400, 1);//1
            hex5 = new Button(hexTexture[7], spriteBatch, 110, 100, 1, 260, 500, 5);//5
            hex15 = new Button(hexTexture[2], spriteBatch, 110, 100, 1, 260, 600, 15);//15
            hex31 = new Button(hexTexture[1], spriteBatch, 110, 100, 1, 260, 700, 31);//31

            hex23 = new Button(hexTexture[8], spriteBatch, 110, 100, 1, 340, 150, 23);//23
            hex10 = new Button(hexTexture[5], spriteBatch, 110, 100, 1, 340, 250, 10);//10
            hex3 = new Button(hexTexture[4], spriteBatch, 110, 100, 1, 340, 350, 3);//3
            hex4 = new Button(hexTexture[6], spriteBatch, 110, 100, 1, 340, 450, 4);//4
            hex14 = new Button(hexTexture[8], spriteBatch, 110, 100, 1, 340, 550, 14);//14
            hex30 = new Button(hexTexture[5], spriteBatch, 110, 100, 1, 340, 650, 30);//30

            hex24 = new Button(hexTexture[1], spriteBatch, 110, 100, 1, 420, 200, 24);//24
            hex11 = new Button(hexTexture[3], spriteBatch, 110, 100, 1, 420, 300, 11);//11
            hex12 = new Button(hexTexture[8], spriteBatch, 110, 100, 1, 420, 400, 12);//12
            hex13 = new Button(hexTexture[1], spriteBatch, 110, 100, 1, 420, 500, 13);//13
            hex29 = new Button(hexTexture[4], spriteBatch, 110, 100, 1, 420, 600, 29);//29

            hex25 = new Button(hexTexture[2], spriteBatch, 110, 100, 1, 500, 250, 25); //25 
            hex26 = new Button(hexTexture[6], spriteBatch, 110, 100, 1, 500, 350, 26);//26
            hex27 = new Button(hexTexture[2], spriteBatch, 110, 100, 1, 500, 450, 27);//27
            hex28 = new Button(hexTexture[3], spriteBatch, 110, 100, 1, 500, 550, 28);//28
            // TODO: use this.Content to load your game content here*/

            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 260, 400, gameBoard.getHexList()[0]));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 260, 300, gameBoard.getHexList()[1]));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 340, 350, gameBoard.getHexList()[2]));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 340, 450, gameBoard.getHexList()[3]));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 260, 500, gameBoard.getHexList()[4]));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 180, 450, gameBoard.getHexList()[5]));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 180, 350, gameBoard.getHexList()[6]));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 180, 250, gameBoard.getHexList()[7]));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 260, 200, gameBoard.getHexList()[8]));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 340, 250, gameBoard.getHexList()[9]));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 420, 300, gameBoard.getHexList()[10]));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 420, 400, gameBoard.getHexList()[11]));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 420, 500, gameBoard.getHexList()[12]));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 340, 550, gameBoard.getHexList()[13]));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 260, 600, gameBoard.getHexList()[14]));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 180, 550, gameBoard.getHexList()[15]));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 100, 500, gameBoard.getHexList()[16]));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 100, 400, gameBoard.getHexList()[17]));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 100, 300, gameBoard.getHexList()[18]));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 100, 200, gameBoard.getHexList()[19]));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 180, 150, gameBoard.getHexList()[20]));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 260, 100, gameBoard.getHexList()[21]));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 340, 150, gameBoard.getHexList()[22]));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 420, 200, gameBoard.getHexList()[23]));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 500, 250, gameBoard.getHexList()[24]));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 500, 350, gameBoard.getHexList()[25]));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 500, 450, gameBoard.getHexList()[26]));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 500, 550, gameBoard.getHexList()[27]));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 420, 600, gameBoard.getHexList()[28]));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 340, 650, gameBoard.getHexList()[29]));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 260, 700, gameBoard.getHexList()[30]));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 180, 650, gameBoard.getHexList()[31]));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 100, 600, gameBoard.getHexList()[32]));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 20, 550, gameBoard.getHexList()[33]));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 20, 450, gameBoard.getHexList()[34]));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 20, 350, gameBoard.getHexList()[35]));
            hex.Add(new HexButton(hexTexture, spriteBatch, 110, 100, 20, 250, gameBoard.getHexList()[36]));

            rollbutton = new DiceRollButton(roll, spriteBatch, 140, 50, 500, 25, font);
            endButton = new EndButton(endTexture, spriteBatch, 140, 50, 340, 25);
            recruitButton = new RecruitButton(Content.Load<Texture2D>("images/recruit"), spriteBatch, 140, 50, 180, 25);

            //P1Tiles.Add(new ThingButton(scripttileTexture[38], _theGameBoard.getPlayers()[0], spriteBatch, GameBoard.Game.getRandomThingFromCup(), 30, 30, 675, 5));
            //P1Tiles.Add(new ThingButton(scripttileTexture[3], _theGameBoard.getPlayers()[0], spriteBatch, GameBoard.Game.getRandomThingFromCup(), 30, 30, 735, 5));
            //P1Tiles.Add(new ThingButton(scripttileTexture[4], _theGameBoard.getPlayers()[0], spriteBatch, GameBoard.Game.getRandomThingFromCup(), 30, 30, 785, 5));
            //P1Tiles.Add(new ThingButton(scripttileTexture[5], _theGameBoard.getPlayers()[0], spriteBatch, GameBoard.Game.getRandomThingFromCup(), 30, 30, 845, 5));
            //P1Tiles.Add(new ThingButton(scripttileTexture[6], _theGameBoard.getPlayers()[0], spriteBatch, GameBoard.Game.getRandomThingFromCup(), 30, 30, 905, 5));

            //P1Tiles.Add(new ThingButton(scripttileTexture[7], _theGameBoard.getPlayers()[0], spriteBatch, GameBoard.Game.getRandomThingFromCup(), 30, 30, 675, 55));
            //P1Tiles.Add(new ThingButton(scripttileTexture[8], _theGameBoard.getPlayers()[0], spriteBatch, GameBoard.Game.getRandomThingFromCup(), 30, 30, 735, 55));
            //P1Tiles.Add(new ThingButton(scripttileTexture[9], _theGameBoard.getPlayers()[0], spriteBatch, GameBoard.Game.getRandomThingFromCup(), 30, 30, 785, 55));
            //P1Tiles.Add(new ThingButton(scripttileTexture[2], _theGameBoard.getPlayers()[0], spriteBatch, GameBoard.Game.getRandomThingFromCup(), 30, 30, 845, 55));
            //P1Tiles.Add(new ThingButton(scripttileTexture[10], _theGameBoard.getPlayers()[0], spriteBatch, GameBoard.Game.getRandomThingFromCup(), 30, 30, 905, 55));

            //P2Tiles.Add(new ThingButton(scripttileTexture[11], _theGameBoard.getPlayers()[1], spriteBatch, GameBoard.Game.getRandomThingFromCup(), 30, 30, 675, 140));
            //P2Tiles.Add(new ThingButton(scripttileTexture[12], _theGameBoard.getPlayers()[1], spriteBatch, GameBoard.Game.getRandomThingFromCup(), 30, 30, 735, 140));
            //P2Tiles.Add(new ThingButton(scripttileTexture[13], _theGameBoard.getPlayers()[1], spriteBatch, GameBoard.Game.getRandomThingFromCup(), 30, 30, 785, 140));
            //P2Tiles.Add(new ThingButton(scripttileTexture[14], _theGameBoard.getPlayers()[1], spriteBatch, GameBoard.Game.getRandomThingFromCup(), 30, 30, 845, 140));
            //P2Tiles.Add(new ThingButton(scripttileTexture[15], _theGameBoard.getPlayers()[1], spriteBatch, GameBoard.Game.getRandomThingFromCup(), 30, 30, 905, 140));

            //P2Tiles.Add(new ThingButton(scripttileTexture[16], _theGameBoard.getPlayers()[1], spriteBatch, GameBoard.Game.getRandomThingFromCup(), 30, 30, 675, 190));
            //P2Tiles.Add(new ThingButton(scripttileTexture[17], _theGameBoard.getPlayers()[1], spriteBatch, GameBoard.Game.getRandomThingFromCup(), 30, 30, 735, 190));
            //P2Tiles.Add(new ThingButton(scripttileTexture[39], _theGameBoard.getPlayers()[1], spriteBatch, GameBoard.Game.getRandomThingFromCup(), 30, 30, 785, 190));
            //P2Tiles.Add(new ThingButton(scripttileTexture[18], _theGameBoard.getPlayers()[1], spriteBatch, GameBoard.Game.getRandomThingFromCup(), 30, 30, 845, 190));
            //P2Tiles.Add(new ThingButton(scripttileTexture[19], _theGameBoard.getPlayers()[1], spriteBatch, GameBoard.Game.getRandomThingFromCup(), 30, 30, 905, 190));

            //P3Tiles.Add(new ThingButton(scripttileTexture[21], _theGameBoard.getPlayers()[2], spriteBatch, GameBoard.Game.getRandomThingFromCup(), 30, 30, 675, 275));
            //P3Tiles.Add(new ThingButton(scripttileTexture[22], _theGameBoard.getPlayers()[2], spriteBatch, GameBoard.Game.getRandomThingFromCup(), 30, 30, 735, 275));
            //P3Tiles.Add(new ThingButton(scripttileTexture[23], _theGameBoard.getPlayers()[2], spriteBatch, GameBoard.Game.getRandomThingFromCup(), 30, 30, 785, 275));
            //P3Tiles.Add(new ThingButton(scripttileTexture[23], _theGameBoard.getPlayers()[2], spriteBatch, GameBoard.Game.getRandomThingFromCup(), 30, 30, 845, 275));
            //P3Tiles.Add(new ThingButton(scripttileTexture[24], _theGameBoard.getPlayers()[2], spriteBatch, GameBoard.Game.getRandomThingFromCup(), 30, 30, 905, 275));

            //P3Tiles.Add(new ThingButton(scripttileTexture[25], _theGameBoard.getPlayers()[2], spriteBatch, GameBoard.Game.getRandomThingFromCup(), 30, 30, 675, 325));
            //P3Tiles.Add(new ThingButton(scripttileTexture[26], _theGameBoard.getPlayers()[2], spriteBatch, GameBoard.Game.getRandomThingFromCup(), 30, 30, 735, 325));
            //P3Tiles.Add(new ThingButton(scripttileTexture[27], _theGameBoard.getPlayers()[2], spriteBatch, GameBoard.Game.getRandomThingFromCup(), 30, 30, 785, 325));
            //P3Tiles.Add(new ThingButton(scripttileTexture[16], _theGameBoard.getPlayers()[2], spriteBatch, GameBoard.Game.getRandomThingFromCup(), 30, 30, 845, 325));
            //P3Tiles.Add(new ThingButton(scripttileTexture[28], _theGameBoard.getPlayers()[2], spriteBatch, GameBoard.Game.getRandomThingFromCup(), 30, 30, 905, 325));

            //P4Tiles.Add(new ThingButton(scripttileTexture[29], _theGameBoard.getPlayers()[3], spriteBatch, GameBoard.Game.getRandomThingFromCup(), 30, 30, 675, 410));
            //P4Tiles.Add(new ThingButton(scripttileTexture[30], _theGameBoard.getPlayers()[3], spriteBatch, GameBoard.Game.getRandomThingFromCup(), 30, 30, 735, 410));
            //P4Tiles.Add(new ThingButton(scripttileTexture[31], _theGameBoard.getPlayers()[3], spriteBatch, GameBoard.Game.getRandomThingFromCup(), 30, 30, 785, 410));
            //P4Tiles.Add(new ThingButton(scripttileTexture[32], _theGameBoard.getPlayers()[3], spriteBatch, GameBoard.Game.getRandomThingFromCup(), 30, 30, 845, 410));
            //P4Tiles.Add(new ThingButton(scripttileTexture[37], _theGameBoard.getPlayers()[3], spriteBatch, GameBoard.Game.getRandomThingFromCup(), 30, 30, 905, 410));

            //P4Tiles.Add(new ThingButton(scripttileTexture[29], _theGameBoard.getPlayers()[3], spriteBatch, GameBoard.Game.getRandomThingFromCup(), 30, 30, 675, 460));
            //P4Tiles.Add(new ThingButton(scripttileTexture[33], _theGameBoard.getPlayers()[3], spriteBatch, GameBoard.Game.getRandomThingFromCup(), 30, 30, 735, 460));
            //P4Tiles.Add(new ThingButton(scripttileTexture[34], _theGameBoard.getPlayers()[3], spriteBatch, GameBoard.Game.getRandomThingFromCup(), 30, 30, 785, 460));
            //P4Tiles.Add(new ThingButton(scripttileTexture[35], _theGameBoard.getPlayers()[3], spriteBatch, GameBoard.Game.getRandomThingFromCup(), 30, 30, 845, 460));
            //P4Tiles.Add(new ThingButton(scripttileTexture[36], _theGameBoard.getPlayers()[3], spriteBatch, GameBoard.Game.getRandomThingFromCup(), 30, 30, 905, 460));
            //P1Tiles.Add(new Button(
            init();
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

            switch (GameLogic.Managers.PhaseManager.PhManager.getCurrentPhase().getName())
            {
                case "Setup":
                    currentPhase.playPhase(me);
                    me = currentPhase.getCurrentPlayer();
                    Console.WriteLine(me.getName());
                    break;
                case "Gold Collection":
                    currentPhase.playPhase(me);
                    me = currentPhase.getCurrentPlayer();
                    Console.WriteLine(me.getName());
                    break;
                case "Recruit Things":
                    currentPhase.playPhase(me);
                        if( me.isInPhase() )
                            ((GameLogic.Phases.RecruitThingsPhase)currentPhase).recruitThings();
                    me = currentPhase.getCurrentPlayer();
                    Console.WriteLine(me.getName());
                    break;
                case "Movement":
                    Console.WriteLine("Movement");
                    currentPhase.playPhase(me);
                    me = currentPhase.getCurrentPlayer();
                    Console.WriteLine(me.getName());
                    break;
            }

            if (currentPhase.getCurrentState() == GameLogic.Phases.Phase.State.END)
                currentPhase = GameLogic.Managers.PhaseManager.PhManager.play();

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

            foreach (Button b in hex)
                b.Update();
            
            foreach (Button b in marker)
                b.Update();

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

            foreach( Button mark in marker ) 
                mark.Draw();

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
            spriteBatch.DrawString(font, String.Format("Phase : {0}", currentPhase.getName()), new Vector2(10, 1), Color.Black);


            foreach (Player p in GameController.Game.getPlayers())
            {
                if( me != null && p.getName() == me.getName() )
                    spriteBatch.DrawString(font, String.Format("{0} Gold : {1}", p.getName(), p.getGold()), new Vector2(p.getDrawingPosition().X, p.getDrawingPosition().Y), Color.Blue);
                else
                    spriteBatch.DrawString(font, String.Format("{0} Gold : {1}", p.getName(), p.getGold()), new Vector2(p.getDrawingPosition().X, p.getDrawingPosition().Y), Color.Black);
            }

        }

        public static MarkerButton getMyMarker()
        {
            foreach(MarkerButton b in marker)
            {
                if (me.containsMarkerID(b.getButtonID()) &&
                    me.isHoldingMarker() &&
                    b.getMarkerSelected())
                    return b;
            }

            return null;
        }

        public abstract void setButtonInHand(Button b);
        //{
        //    buttonInHand = b;
        //    me.setHandsFull(true);
        //}

        public abstract void emptyHand();
        //{
        //    buttonInHand = null;
        //    me.setHandsFull(false);
        //}

        public abstract Button getButtonInHand();
        //{
        //    return buttonInHand;
        //}

        public abstract StackButton createStack(Tile hex, Thing t, SpriteBatch s);
        //{
        //    StackButton stackB = new StackButton(stackTexture, me, s, t, hex, 30, 30, 0, 0);
        //    StackButtons.Add(stackB);
        //    return stackB;
        //}
             
    }
}