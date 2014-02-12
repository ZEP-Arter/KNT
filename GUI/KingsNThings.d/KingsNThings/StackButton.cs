using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameLogic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace KingsNThings
{
    class StackButton : Button
    {
        public StackButton(Texture2D texture, Player p, SpriteBatch sBatch, Thing t, Tile hex, int width, int height, int x, int y) :
            base(texture, sBatch, width, height, x, y)
        {
            thingsInStack = new List<Thing>();
            thingsInStack.Add(t);
            hexStackIsOn = hex;
            owner = p;
        }

        public void addThings(List<Thing> t)
        {
            thingsInStack.AddRange(t);
        }

        public void addThings(Thing t)
        {
            thingsInStack.Add(t);
        }

        protected override void isClicked()
        {
            if (isStackSelected())
            {
                if (!stackSelected)
                {
                    KNT_Game.setButtonInHand(this);
                    stackSelected = true;
                }
            }
        }

        protected override void draw()
        {
                spriteBatch.Draw(image, location, Color.White);
        }

        public override void Update()
        {

            base.Update();
        }

        private bool isStackSelected()
        {
            if (location.Contains(new Point(mouse.X, mouse.Y)))
            {
                if (!KNT_Game.me.handsFull())
                {
                    return true;
                }
            }

            return false;
        }

        private List<Thing> thingsInStack;
        private bool stackSelected = false;
        private Player owner = null;
        private Tile hexStackIsOn = null;
    }
}
