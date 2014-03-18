﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using KNT_Client.Networkable;

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

        public void moveStack(Tile t)
        {
            hexStackIsOn = t;
        }

        protected override void isClicked()
        {
            if (isStackSelected())
            {
                if (!stackSelected)
                {
                    game.setButtonInHand(this);
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
                if (!KNT_Game.me.isHoldingMarker() &&
                    thingsInStack.Count > 0 &&
                    GameLogic.Managers.PhaseManager.PhManager.getCurrentPhase().Equals("Movement"))
                {
                    return true;
                }
            }

            return false;
        }

        public Tile getHexStackIsOn()
        { return hexStackIsOn; }

        private Texture2D image;
        private List<Thing> thingsInStack;
        private bool stackSelected = false;
        private Player owner = null;
        private Tile hexStackIsOn = null;
        private KNT_Game game;
	}
}
