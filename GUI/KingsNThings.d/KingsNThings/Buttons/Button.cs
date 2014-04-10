using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using GameLogic;

namespace KingsNThings.Buttons
{
    public abstract class Button
    {
        //protected Tile _hex;

        protected Texture2D image;
        //protected Texture2D backside;
        public Rectangle location;
        protected SpriteBatch spriteBatch;
        //protected int buttonType;
        protected MouseState mouse;
        protected MouseState oldMouse;
        //protected int hexNumber = 0;
        public bool clicked = false;
        public string clickText = "Button was Clicked!";
        protected Point topleft, topright, midleft, midright, botleft, botright;
        protected Rectangle middle;
        protected Texture2D back;

        //Button marker;

        //int buttonID;

        //Player owner;

        //bool markerSelected, isSet, needDice;

        /*
        public Button(Texture2D texture, Player p, SpriteBatch sBatch, int width, int height, int number, int x, int y)
        {
            image = texture;
            location = new Rectangle(x, y, width, height);
            spriteBatch = sBatch;
            buttonType = number;
            topleft = new Point(25 + x, 0 + y);
            midleft = new Point(0 + x, 50 + y);
            botleft = new Point(25 + x, 100 + y);
            topright = new Point(85 + x, 0 + y);
            midright = new Point(110 + x, 50 + y);
            botright = new Point(85 + x, 100 + y);
            middle = new Rectangle(topleft.X, topleft.Y, 60, 100);
            markerSelected = false;
            isSet = false;
            needDice = false;
            owner = p;

            Random r = new Random();

            buttonID = r.Next(System.DateTime.Now.Millisecond * 1000, System.DateTime.Now.Millisecond * 10000);
            System.Threading.Thread.Sleep(1000);

            while (p.containsMarkerID(buttonID))
            {
                buttonID = r.Next(System.DateTime.Now.Millisecond);
                System.Threading.Thread.Sleep(1000);
            }

                p.addMarkerID(buttonID);

                Console.WriteLine(buttonID);
            
        }
         * */

        // maybe not using
        public Button(Texture2D texture, SpriteBatch sBatch, int width, int height, int x, int y)
        {
            image = texture;
            location = new Rectangle(x, y, width, height);
            spriteBatch = sBatch;
            //buttonType = number;
            topleft = new Point(25 + x, 0 + y);
            midleft = new Point(0 + x, 50 + y);
            botleft = new Point(25 + x, 100 + y);
            topright = new Point(85 + x, 0 + y);
            midright = new Point(110 + x, 50 + y);
            botright = new Point(85 + x, 100 + y);
            middle = new Rectangle(topleft.X, topleft.Y, 60, 100);
            //needDice = false;
            
        }

        //hexes
        public Button(Texture2D[] texture, SpriteBatch sBatch, int width, int height, int x, int y, Tile t)
        {
            //_hex = t;
            //backside = texture[0];
            //hexNumber = _hex.getHexNum();
            switch (t.getType())
            {
                case "Desert":          image = texture[1];
                                        break;

                case "Forest":          image = texture[2];
                                        break;

                case "Frozen Waste":    image = texture[3];
                                        break;

                case "Jungle":          image = texture[4]; 
                                        break;

                case "Mountain":        image = texture[5]; 
                                        break;

                case "Plains":          image = texture[6]; 
                                        break;

                case "Sea":             image = texture[7]; 
                                        break;

                case "Swamp":           image = texture[8]; 
                                        break;
            }

            location = new Rectangle(x, y, width, height);
            spriteBatch = sBatch;
            //buttonType = number;
            topleft = new Point(25 + x, 0 + y);
            midleft = new Point(0 + x, 50 + y);
            botleft = new Point(25 + x, 100 + y);
            topright = new Point(85 + x, 0 + y);
            midright = new Point(110 + x, 50 + y);
            botright = new Point(85 + x, 100 + y);
            middle = new Rectangle(topleft.X, topleft.Y, 60, 100);
            //needDice = false;
        }
        /*
        public int getButtonID()
        {
            return this.buttonID;
        }
        */
        protected abstract void isClicked();
        protected abstract void draw();
        
        public void Location(int x, int y)
        {
            this.location.X = x;
            this.location.Y = y;
            topleft = new Point(25 + x, 0 + y);
            midleft = new Point(0 + x, 50 + y);
            botleft = new Point(25 + x, 100 + y);
            topright = new Point(85 + x, 0 + y);
            midright = new Point(110 + x, 50 + y);
            botright = new Point(85 + x, 100 + y);
            middle = new Rectangle(topleft.X, topleft.Y, 60, 100);
        }

        public virtual void Update()
        {
            mouse = Mouse.GetState();

            if (mouse.LeftButton == ButtonState.Released && oldMouse.LeftButton == ButtonState.Pressed)
            {
                isClicked();
            }

            //Text = "Click Me";
            oldMouse = mouse;
        }

        public virtual void Draw()
        {
            spriteBatch.Begin();

            draw();

            spriteBatch.End();
        }
    }
}