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
using KNT_Service;

namespace KingsNThings
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class KNT_Game : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        KNTNet client;
        SpriteBatch spriteBatch;
        private Texture2D board;
        private Texture2D[] hexTexture = new Texture2D[9];
        Button hex1, hex2, hex3, hex4, hex5, hex6, hex7, hex8, hex9, hex10, hex11, hex12, hex13, hex14, hex15, hex16, hex17, hex18, hex19, hex20, hex21, hex22, hex23, hex24, hex25, hex26, hex27, hex28, hex29, hex30, hex31, hex32, hex33, hex34, hex35, hex36, hex37;
        //SpriteFont font;
        public KNT_Game()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferHeight = 800;
            graphics.PreferredBackBufferWidth = 1000;
            graphics.ApplyChanges();
            client = new KNTNet();
            Services.AddService(typeof(IKNTNet), client);
            client.setupGame();
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
            //font = Content.Load<SpriteFont>("test");
            board = Content.Load<Texture2D>("images/board");
            
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

            /////////////////////////////////HEX BUTTONS\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
            hex37 = new Button(hexTexture[1], spriteBatch, 110, 100, 1, 20, 250, 37); //37 Buttons
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

            hex25 = new Button(hexTexture[2], spriteBatch, 110, 100, 1, 500, 250, 25); //25 Buttons
            hex26 = new Button(hexTexture[6], spriteBatch, 110, 100, 1, 500, 350, 26);//26
            hex27 = new Button(hexTexture[2], spriteBatch, 110, 100, 1, 500, 450, 27);//27
            hex28 = new Button(hexTexture[3], spriteBatch, 110, 100, 1, 500, 550, 28);//28
            // TODO: use this.Content to load your game content here
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

            // TODO: Add your update logic here

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
            spriteBatch.Begin();

            spriteBatch.Draw(board, new Rectangle(0, 0, 1000, 800), Color.White);

            
         //  DrawText();
            spriteBatch.End();
            DrawBoard();



            base.Draw(gameTime);
        }

        private void UpdateButtons()
        {
            
            hex1.Update();
            hex2.Update();
            hex3.Update();
            hex4.Update();
            hex5.Update();
            hex6.Update();
            hex7.Update();
            hex8.Update();
            hex9.Update();
            hex10.Update();
            hex11.Update();
            hex12.Update();
            hex13.Update();
            hex14.Update();
            hex15.Update();
            hex16.Update();
            hex17.Update();
            hex18.Update();
            hex19.Update();
            hex20.Update();
            hex21.Update();
            hex22.Update();
            hex23.Update();
            hex24.Update();
            hex25.Update();
            hex26.Update();
            hex27.Update();
            hex28.Update();
            hex29.Update();
            hex30.Update();
            hex31.Update();
            hex32.Update();
            hex33.Update();
            hex34.Update();
            hex35.Update();
            hex36.Update();
            hex37.Update();
        }

        private void DrawBoard()
        {

            
            hex1.Draw();
            hex2.Draw();
            hex3.Draw();
            hex4.Draw();
            hex5.Draw();
            hex6.Draw();
            hex7.Draw();
            hex8.Draw();
            hex9.Draw();
            hex10.Draw();
            hex11.Draw();
            hex12.Draw();
            hex13.Draw();
            hex14.Draw();
            hex15.Draw();
            hex16.Draw();
            hex17.Draw();
            hex18.Draw();
            hex19.Draw();
            hex20.Draw();
            hex21.Draw();
            hex22.Draw();
            hex23.Draw();
            hex24.Draw();
            hex25.Draw();
            hex26.Draw();
            hex27.Draw();
            hex28.Draw();
            hex29.Draw();
            hex30.Draw();
            hex31.Draw();
            hex32.Draw();
            hex33.Draw();
            hex34.Draw();
            hex35.Draw();
            hex36.Draw();
            hex37.Draw();
        }
        private void DrawText()
        {
            MouseState mouse = Mouse.GetState();
            //spriteBatch.DrawString(font, "MouseX = " + mouse.X, new Vector2(20, 45), Color.Blue);
            //spriteBatch.DrawString(font, "MouseY = " + mouse.Y, new Vector2(20, 70), Color.Blue);
        }
    }
}