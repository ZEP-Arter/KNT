using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameLogic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace KingsNThings
{
    public class StackButton : Button
    {
        public StackButton(Texture2D texture, Player p, SpriteBatch sBatch, Thing t, Tile hex, int width, int height, int x, int y) :
            base(texture, sBatch, width, height, x, y)
        {
            image = texture;
            thingsInStack = new List<Thing>(10);
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
            if ( canAddToStack() )
                thingsInStack.Add(t);
        }

        public bool canAddToStack()
        {
            if (thingsInStack.Count + 1 <= thingsInStack.Capacity - 1)
                return true;
            return false;
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
            if (stackSelected)
            {
                this.location.X = mouse.X;
                this.location.Y = mouse.Y;
            }
            base.Update();
        }

        private bool isStackSelected()
        {
            if (location.Contains(new Point(mouse.X, mouse.Y)))
            {
                if (!KNT_Game.me.handsFull() &&
                    thingsInStack.Count > 0 &&
                    GameBoard.Game.getCurrentPhase().Equals("Movement"))
                {
                    return true;
                }
            }

            return false;
        }

        private Texture2D image;
        private List<Thing> thingsInStack;
        private bool stackSelected = false;
        private Player owner = null;
        private Tile hexStackIsOn = null;
	}
}
