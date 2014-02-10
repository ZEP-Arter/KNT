using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace KingsNThings
{
    class Button
    {
        protected Texture2D image;
        protected SpriteFont font;
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
            
        }

        public Button(Texture2D texture, SpriteBatch sBatch, int width, int height, int number, int x, int y, int hexnum)
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
            hexNumber = hexnum;
        }
        public bool isClickedMarker(bool clickedTile, int number)
        {
            if (clickedTile == true && number == 3)
            {
                return true;
            }
            else return false;

        }
        
        public void Location(int x, int y)
        {
            location.X = x;
            location.Y = y;
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

            if (mouse.LeftButton == ButtonState.Released && oldMouse.LeftButton == ButtonState.Pressed)
            {
                
                if ((IsInsideTriangle(topleft, midleft, botleft, new Point(mouse.X, mouse.Y)) ||
                    middle.Contains(new Point(mouse.X, mouse.Y)) ||
                    IsInsideTriangle(topright, midright, botright, new Point(mouse.X, mouse.Y))) && buttonType == 1) //HEX TILES
                {
                    clicked = true;
                }

                if (location.Contains(new Point(mouse.X, mouse.Y)) && buttonType == 3) //MARKER TILES
                {
                    clicked = true;

                }
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
            else
            {
                spriteBatch.Draw(image,
                    location,
                    Color.White);
            }



            if (clicked && buttonType == 3)
            {
                
                
            }

            spriteBatch.End();
        }

    }
}