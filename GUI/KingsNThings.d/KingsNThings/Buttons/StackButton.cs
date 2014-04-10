using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameLogic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using KingsNThings.GUI;
using GameLogic.Things;
using GameLogic.Managers;

namespace KingsNThings.Buttons
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

        public StackButton(Texture2D texture, Player p, SpriteBatch sBatch, List<Thing> t, Tile hex, int width, int height, int x, int y) :
            base(texture, sBatch, width, height, x, y)
        {
            image = texture;
            thingsInStack = new List<Thing>(10);
            foreach (Thing aThing in t)
                thingsInStack.Add(aThing);
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
            if (thingsInStack.Count + 1 <= thingsInStack.Capacity)
                return true;
            return false;
        }

        public void moveStack(Tile t)
        {
            hexStackIsOn = t;
        }

        protected override void isClicked()
        {
            //if (isStackSelected())
            //{
            //    if (!stackSelected)
            //    {
            //        //KNT_Game.setButtonInHand(this);
            //        //stackSelected = true;
            //    }
            //}
        }

        protected override void draw()
        {
           spriteBatch.Draw(image, location, Color.White);

           if (location.Contains(new Point(mouse.X, mouse.Y)) && KNT_Game.me.getPlayerNumber() == this.owner.getPlayerNumber())
           {
               int i = 0;
               int j = 0;
               if (thingsInStack != null)
               {
                   foreach (Thing thing in thingsInStack)
                   {
                       if (i >= 5) { j = 1; i = 0; }
                       spriteBatch.Draw(KNT_Game.thingTexture[thing.getTextureID()], new Rectangle(645 + (i * 60), 585 + (j * 60), 50, 50), Color.White);
                       i++;
                   }
               }
           }
                           
        }

        public override void Update()
        {
            base.Update();
        }

        private bool isStackSelected()
        {
            if (location.Contains(new Point(mouse.X, mouse.Y)))
            {
                if (!KNT_Game.me.handsFull() &&
                    thingsInStack.Count > 0 &&
                    GameBoard.Game.getCurrentPhase().getName().Equals("Movement"))
                {
                    return true;
                }
            }

            return false;
        }

        public Tile getHexStackIsOn()
        { return hexStackIsOn; }

        public List<Thing> getList()
        { return thingsInStack; }

        private Texture2D image;
        public List<Thing> thingsInStack;
        private bool stackSelected = false;
        private Player owner = null;
        private Tile hexStackIsOn = null;
	}
}
