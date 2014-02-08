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
        //protected SpriteFont font;
        protected Rectangle location;
        protected SpriteBatch spriteBatch;
        protected MouseState mouse;
        protected MouseState oldMouse;
        public bool clicked = false;
        public string clickText = "Button was Clicked!";

        public Button(Texture2D texture, SpriteBatch sBatch, int width, int height)
        {
            image = texture;
            location = new Rectangle(0, 0, width, height);
            spriteBatch = sBatch;
        }

        public void Location(int x, int y)
        {
            location.X = x;
            location.Y = y;
        }

        public virtual void Update()
        {
            mouse = Mouse.GetState();

            if (mouse.LeftButton == ButtonState.Released && oldMouse.LeftButton == ButtonState.Pressed)
            {
                if (location.Contains(new Point(mouse.X, mouse.Y)))
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

            if (location.Contains(new Point(mouse.X, mouse.Y)))
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

            

            if (clicked)
            {
                //tekst, mis ilmub peale nupule klikkimist
                Vector2 position = new Vector2(10, 75);
                
            }

            spriteBatch.End();
        }

    }
}
