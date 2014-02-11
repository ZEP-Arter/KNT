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
        private Texture2D[] hexTexture = new Texture2D[9];
        private Texture2D[] goldTexture = new Texture2D[6];
        private Texture2D[] markerTexture = new Texture2D[4];
        private Texture2D[] scripttileTexture = new Texture2D[40];
        //Button hex1, hex2, hex3, hex4, hex5, hex6, hex7, hex8, hex9, hex10, hex11, hex12, hex13, hex14, hex15, hex16, hex17, hex18, hex19, hex20, hex21, hex22, hex23, hex24, hex25, hex26, hex27, hex28, hex29, hex30, hex31, hex32, hex33, hex34, hex35, hex36, hex37;
        Button rollbutton;
        Button endButton;
        List<Button> P1Tiles = new List<Button>();
        List<Button> P2Tiles = new List<Button>();
        List<Button> P3Tiles = new List<Button>();
        List<Button> P4Tiles = new List<Button>();
        List<Button> hex = new List<Button>();
        static List<Button> marker = new List<Button>();
        SpriteFont font;
        Texture2D rack;
        GameBoard _theGameBoard;
        public static Player me;
        bool positionsSet;
        bool markersSet;
        Phase currentPhase;

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

            marker.Add(new Button(markerTexture[0], _theGameBoard.getPlayers()[0], spriteBatch, 30, 30, 3, 645, 570));
            marker.Add(new Button(markerTexture[1], _theGameBoard.getPlayers()[1], spriteBatch, 30, 30, 3, 645, 610));
            marker.Add(new Button(markerTexture[2], _theGameBoard.getPlayers()[2], spriteBatch, 30, 30, 3, 645, 650));
            marker.Add(new Button(markerTexture[3], _theGameBoard.getPlayers()[3], spriteBatch, 30, 30, 3, 645, 690));

            marker.Add(new Button(markerTexture[0], _theGameBoard.getPlayers()[0], spriteBatch, 30, 30, 3, 685, 570));
            marker.Add(new Button(markerTexture[1], _theGameBoard.getPlayers()[1], spriteBatch, 30, 30, 3, 685, 610));
            marker.Add(new Button(markerTexture[2], _theGameBoard.getPlayers()[2], spriteBatch, 30, 30, 3, 685, 650));
            marker.Add(new Button(markerTexture[3], _theGameBoard.getPlayers()[3], spriteBatch, 30, 30, 3, 685, 690));

            marker.Add(new Button(markerTexture[0], _theGameBoard.getPlayers()[0], spriteBatch, 30, 30, 3, 725, 570));
            marker.Add(new Button(markerTexture[1], _theGameBoard.getPlayers()[1], spriteBatch, 30, 30, 3, 725, 610));
            marker.Add(new Button(markerTexture[2], _theGameBoard.getPlayers()[2], spriteBatch, 30, 30, 3, 725, 650));
            marker.Add(new Button(markerTexture[3], _theGameBoard.getPlayers()[3], spriteBatch, 30, 30, 3, 725, 690));
            
            hex.Add(new Button(hexTexture, spriteBatch, 110, 100, 1, 260, 400, _theGameBoard.getMap().getHexList()[0]));
            hex.Add(new Button(hexTexture, spriteBatch, 110, 100, 1, 260, 300, _theGameBoard.getMap().getHexList()[1]));
            hex.Add(new Button(hexTexture, spriteBatch, 110, 100, 1, 340, 350, _theGameBoard.getMap().getHexList()[2]));
            hex.Add(new Button(hexTexture, spriteBatch, 110, 100, 1, 340, 450, _theGameBoard.getMap().getHexList()[3]));
            hex.Add(new Button(hexTexture, spriteBatch, 110, 100, 1, 260, 500, _theGameBoard.getMap().getHexList()[4]));
            hex.Add(new Button(hexTexture, spriteBatch, 110, 100, 1, 180, 450, _theGameBoard.getMap().getHexList()[5]));
            hex.Add(new Button(hexTexture, spriteBatch, 110, 100, 1, 180, 350, _theGameBoard.getMap().getHexList()[6]));
            hex.Add(new Button(hexTexture, spriteBatch, 110, 100, 1, 180, 250, _theGameBoard.getMap().getHexList()[7]));
            hex.Add(new Button(hexTexture, spriteBatch, 110, 100, 1, 260, 200, _theGameBoard.getMap().getHexList()[8]));
            hex.Add(new Button(hexTexture, spriteBatch, 110, 100, 1, 340, 250, _theGameBoard.getMap().getHexList()[9]));
            hex.Add(new Button(hexTexture, spriteBatch, 110, 100, 1, 420, 300, _theGameBoard.getMap().getHexList()[10]));
            hex.Add(new Button(hexTexture, spriteBatch, 110, 100, 1, 420, 400, _theGameBoard.getMap().getHexList()[11]));
            hex.Add(new Button(hexTexture, spriteBatch, 110, 100, 1, 420, 500, _theGameBoard.getMap().getHexList()[12]));
            hex.Add(new Button(hexTexture, spriteBatch, 110, 100, 1, 340, 550, _theGameBoard.getMap().getHexList()[13]));
            hex.Add(new Button(hexTexture, spriteBatch, 110, 100, 1, 260, 600, _theGameBoard.getMap().getHexList()[14]));
            hex.Add(new Button(hexTexture, spriteBatch, 110, 100, 1, 180, 550, _theGameBoard.getMap().getHexList()[15]));
            hex.Add(new Button(hexTexture, spriteBatch, 110, 100, 1, 100, 500, _theGameBoard.getMap().getHexList()[16]));
            hex.Add(new Button(hexTexture, spriteBatch, 110, 100, 1, 100, 400, _theGameBoard.getMap().getHexList()[17]));
            hex.Add(new Button(hexTexture, spriteBatch, 110, 100, 1, 100, 300, _theGameBoard.getMap().getHexList()[18]));
            hex.Add(new Button(hexTexture, spriteBatch, 110, 100, 1, 100, 200, _theGameBoard.getMap().getHexList()[19]));
            hex.Add(new Button(hexTexture, spriteBatch, 110, 100, 1, 180, 150, _theGameBoard.getMap().getHexList()[20]));
            hex.Add(new Button(hexTexture, spriteBatch, 110, 100, 1, 260, 100, _theGameBoard.getMap().getHexList()[21]));
            hex.Add(new Button(hexTexture, spriteBatch, 110, 100, 1, 340, 150, _theGameBoard.getMap().getHexList()[22]));
            hex.Add(new Button(hexTexture, spriteBatch, 110, 100, 1, 420, 200, _theGameBoard.getMap().getHexList()[23]));
            hex.Add(new Button(hexTexture, spriteBatch, 110, 100, 1, 500, 250, _theGameBoard.getMap().getHexList()[24]));
            hex.Add(new Button(hexTexture, spriteBatch, 110, 100, 1, 500, 350, _theGameBoard.getMap().getHexList()[25]));
            hex.Add(new Button(hexTexture, spriteBatch, 110, 100, 1, 500, 450, _theGameBoard.getMap().getHexList()[26]));
            hex.Add(new Button(hexTexture, spriteBatch, 110, 100, 1, 500, 550, _theGameBoard.getMap().getHexList()[27]));
            hex.Add(new Button(hexTexture, spriteBatch, 110, 100, 1, 420, 600, _theGameBoard.getMap().getHexList()[28]));
            hex.Add(new Button(hexTexture, spriteBatch, 110, 100, 1, 340, 650, _theGameBoard.getMap().getHexList()[29]));
            hex.Add(new Button(hexTexture, spriteBatch, 110, 100, 1, 260, 700, _theGameBoard.getMap().getHexList()[30]));
            hex.Add(new Button(hexTexture, spriteBatch, 110, 100, 1, 180, 650, _theGameBoard.getMap().getHexList()[31]));
            hex.Add(new Button(hexTexture, spriteBatch, 110, 100, 1, 100, 600, _theGameBoard.getMap().getHexList()[32]));
            hex.Add(new Button(hexTexture, spriteBatch, 110, 100, 1, 20, 550, _theGameBoard.getMap().getHexList()[33]));
            hex.Add(new Button(hexTexture, spriteBatch, 110, 100, 1, 20, 450, _theGameBoard.getMap().getHexList()[34]));
            hex.Add(new Button(hexTexture, spriteBatch, 110, 100, 1, 20, 350, _theGameBoard.getMap().getHexList()[35]));
            hex.Add(new Button(hexTexture, spriteBatch, 110, 100, 1, 20, 250, _theGameBoard.getMap().getHexList()[36]));

            rollbutton = new Button(roll, spriteBatch, 140, 60, 4, 460, 20);
            endButton = new Button(endTexture, spriteBatch, 140, 60, 4, 300, 20);
            //P1Tiles.Add(new Button(
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

            switch(_theGameBoard.getCurrentPhase())
            {
                case "Setup":
                    currentPhase.playPhase(_theGameBoard.getPlayers());
                    me = currentPhase.getCurrentPlayer();
                    //Console.WriteLine(me.getName());
                    break;
            }

            if (currentPhase.getCurrentState() == Phase.State.END)
                currentPhase = _theGameBoard.play();

            UpdateButtons();
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


            marker[0].Update();
            marker[1].Update();
            marker[2].Update();
            marker[3].Update();
            marker[4].Update();
            marker[5].Update();
            marker[6].Update();
            marker[7].Update();
            marker[8].Update();
            marker[9].Update();
            marker[10].Update();
            marker[11].Update();

            rollbutton.Update();
            endButton.Update();
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

            marker[0].Draw();
            marker[1].Draw();
            marker[2].Draw();
            marker[3].Draw();
            marker[4].Draw();
            marker[5].Draw();
            marker[6].Draw();
            marker[7].Draw();
            marker[8].Draw();
            marker[9].Draw();
            marker[10].Draw();
            marker[11].Draw();

            rollbutton.Draw();
            endButton.Draw();
        }

        private void DrawText()
        {
            MouseState mouse = Mouse.GetState();
            spriteBatch.DrawString(font, "MouseX = " + mouse.X, new Vector2(20, 45), Color.Blue);
            spriteBatch.DrawString(font, "MouseY = " + mouse.Y, new Vector2(20, 70), Color.Blue);
            spriteBatch.DrawString(font, String.Format("Phase : {0}", _theGameBoard.getCurrentPhase()), new Vector2(20, 20), Color.Black);


            foreach (Player p in _theGameBoard.getPlayers())
            {
                if( me != null && p.getName() == me.getName() )
                    spriteBatch.DrawString(font, String.Format("{0} Gold : {1}", p.getName(), p.getGold()), new Vector2(Player.goldX, p.goldY), Color.Blue);
                else
                    spriteBatch.DrawString(font, String.Format("{0} Gold : {1}", p.getName(), p.getGold()), new Vector2(Player.goldX, p.goldY), Color.Black);
            }
            
            if(me != null && me.getDiceRoll() != 0 && !positionsSet)
                spriteBatch.DrawString(font, String.Format("{0} rolled {1}", me.getName(), me.getDiceRoll()), new Vector2(420, 100), Color.Blue);

        }

        public static Button getMyMarker()
        {
            foreach(Button b in marker)
            {
                if (me.containsMarkerID(b.getButtonID()))
                    return b;
            }

            return null;
        }
             
    }
}