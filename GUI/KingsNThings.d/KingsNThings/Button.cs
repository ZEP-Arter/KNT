using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using GameLogic;

namespace KingsNThings
{
    public class Button
    {
        protected Tile _hex;

        protected Texture2D image;
        protected Texture2D backside;
        protected Rectangle location;
        protected SpriteBatch spriteBatch;
        protected int buttonType;
        protected MouseState mouse;
        protected MouseState oldMouse;
        protected int hexNumber = 0;
        public bool clicked = false;
        public string clickText = "Button was Clicked!";
        protected Point topleft, topright, midleft, midright, botleft, botright;
        protected Rectangle middle;
        protected Texture2D back;

        Button marker;

        int buttonID;

        Player owner;

        bool markerSelected, isSet, needDice;

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

            buttonID = r.Next(System.DateTime.Now.Millisecond);
            System.Threading.Thread.Sleep(1000);

            p.setMarkerID(buttonID);
            
        }

        // maybe not using
        public Button(Texture2D texture, SpriteBatch sBatch, int width, int height, int number, int x, int y)
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
            needDice = false;
            
        }

        //hexes
        public Button(Texture2D[] texture, SpriteBatch sBatch, int width, int height, int number, int x, int y, Tile t)
        {
            _hex = t;
            backside = texture[0];
            hexNumber = _hex.getHexNum();
            switch (_hex.getType())
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
            //image = texture[1];
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
            needDice = false;
        }

        public int getButtonID()
        {
            return this.buttonID;
        }

        public bool isClickedMarker(bool clickedTile, int number)
        {
            if (clickedTile == true && number == 3)
            {
                return true;
            }
            else return false;

        }

        private bool isMarkedSelected(Button _marker)
        {
            if (KNT_Game.me.getMarkerID() == _marker.buttonID && !isSet && KNT_Game.me.getDiceRoll() != 0)
            {
                if (location.Contains(new Point(mouse.X, mouse.Y)) && buttonType == 3) //MARKER TILES
                {
                    return true;
                }
            }

            return false;
        }

        private bool rollClicked()
        {
            if (location.Contains(new Point(mouse.X, mouse.Y)) && buttonType == 4)
                return true;

            return false;
        }
        
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

        private bool IsInsideTriangle(Point A, Point B, Point C, Point P)
        {
            int planeAB = (A.X - P.X) * (B.Y - P.Y) - (B.X - P.X) * (A.Y - P.Y);
            int planeBC = (B.X - P.X) * (C.Y - P.Y) - (C.X - P.X) * (B.Y - P.Y);
            int planeCA = (C.X - P.X) * (A.Y - P.Y) - (A.X - P.X) * (C.Y - P.Y);
            return sign(planeAB) == sign(planeBC) && sign(planeBC) == sign(planeCA);

        }

        private int sign(int n)
        {
            if (n != 0)
            {
                return Math.Abs(n) / n;
            }
            else return 0;
        }

        public virtual void Update()
        {
            mouse = Mouse.GetState();

            if (KNT_Game.me.getDiceRoll() == 0)
                needDice = true;

            if (mouse.LeftButton == ButtonState.Released && oldMouse.LeftButton == ButtonState.Pressed)
            {
                
                if ((IsInsideTriangle(topleft, midleft, botleft, new Point(mouse.X, mouse.Y)) ||
                    middle.Contains(new Point(mouse.X, mouse.Y)) ||
                    IsInsideTriangle(topright, midright, botright, new Point(mouse.X, mouse.Y))) && buttonType == 1) //HEX TILES
                {
                    marker = KNT_Game.getMyMarker();

                    if (marker.markerSelected && this._hex.getStart() &&
                        (this._hex.getPlayerAble() == null || this._hex.getPlayerAble() == KNT_Game.me))
                    {
                        this._hex.selectedAsStarting(KNT_Game.me);
                        marker.isSet = true;
                        marker.markerSelected = false;
                        marker.Location(25 + topleft.X, 5 + topleft.Y);
                        KNT_Game.me.placedMarker = true;
                    }
                }

                if (isMarkedSelected(this))
                        markerSelected = true;

                if (rollClicked() && needDice)
                {
                    KNT_Game.me.setDiceRoll(DiceRoller.Roll.rollDice());
                    needDice = false;
                }

            }

            if (markerSelected)
            {
                this.location.X = mouse.X;
                this.location.Y = mouse.Y;
            }
           

            //Text = "Click Me";
            oldMouse = mouse;
        }

        public virtual void Draw()
        {
            spriteBatch.Begin();
            
            if ((IsInsideTriangle(topleft, midleft, botleft, new Point(mouse.X, mouse.Y)) ||
                middle.Contains(new Point(mouse.X, mouse.Y)) ||
                IsInsideTriangle(topright, midright, botright, new Point(mouse.X, mouse.Y))) && buttonType == 1)
            {
                spriteBatch.Draw(image,
                    location,
                    Color.Silver);
            }
            
            else if (location.Contains(new Point(mouse.X, mouse.Y)) && buttonType == 3)
            {
                spriteBatch.Draw(image,
                    location,
                    Color.Silver);

            }
            else if (location.Contains(new Point(mouse.X, mouse.Y)) && buttonType == 4)
            {
                spriteBatch.Draw(image,
                    location,
                    Color.DimGray);

            }
            else if (!needDice && buttonType == 4)
            {
                spriteBatch.Draw(image,
                    location,
                    Color.DimGray);
            }
            else
            {
                spriteBatch.Draw(image,
                    location,
                    Color.White);
            }

            spriteBatch.End();
        }
    }
}