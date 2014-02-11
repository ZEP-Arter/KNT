using GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace KingsNThings
{
    public class MarkerButton : Button
    {
        public MarkerButton(Texture2D texture, Player p, SpriteBatch sBatch, int width, int height, int x, int y) :
            base(texture, sBatch, width, height, x, y)
        {
            markerSelected = false;
            isSet = false;
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

        public int getButtonID()
        {
            return buttonID;
        }

        protected override void isClicked()
        {
            if (isMarkedSelected())
            {
                if (!markerSelected)
                    KNT_Game.me.setHandsFull();
                markerSelected = true;
            }
        }

        protected override void draw()
        {
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
        }

        public override void Update()
        {
            if (markerSelected)
            {
                this.location.X = mouse.X;
                this.location.Y = mouse.Y;
            }

            base.Update();
        }

        public bool isMarkedSelected()
        {
            if (KNT_Game.me.containsMarkerID(buttonID) &&
                !isSet &&
                KNT_Game.me.getDiceRoll() != 0 &&
                !KNT_Game.me.handsFull())
            {
                if (location.Contains(new Point(mouse.X, mouse.Y))) //MARKER TILES
                {
                    return true;
                }
            }

            return false;
        }

        public bool getMarkerSelected() { return markerSelected; }
        public void setMarkerSelected(bool b) { markerSelected = b; }

        public bool getIsSet() { return isSet; }
        public void setIsSet(bool b) { isSet = b; }

        private Player owner;
        private bool isSet,
                     markerSelected;
        private int buttonID;
    }
}
