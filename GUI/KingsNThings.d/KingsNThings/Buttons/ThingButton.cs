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
    class ThingButton : Button
    {
        public ThingButton(Texture2D texture, Player p, SpriteBatch sBatch, Thing t, int width, int height, int x, int y) :
            base(texture, sBatch, width, height, x, y)
        {
            owner = p;
            buttonID = t.getID();
            thingOnButton = t;
            thingOnButton.setOwned();
            owner.AddThingToRack(buttonID, t);
            thingSelected = false;
            isInPlay = false;
            originalPosition = location;
        }

        public int getButtonID()
        {
            return buttonID;
        }

        private bool isSelected()
        {
            if (location.Contains(new Point(mouse.X, mouse.Y)))
            {
                if (GameBoard.Game.getCurrentPhase().getName().Equals("Recruit Things") && 
                    KNT_Game.me.rackContains(buttonID) &&
                    !thingSelected &&
                    !isInPlay &&
                    !KNT_Game.me.handsFull())
                {
                    return true;
                }
            }

            return false;
        }

        private bool isInOriginalPosition()
        {
            if (thingSelected &&
                originalPosition.Contains(new Point(mouse.X, mouse.Y)))
                return true;

            return false;
        }

        protected override void isClicked()
        {

            if (isInOriginalPosition())
            {
                location = originalPosition;
                KNT_Game.me.setHandsFull();
                thingSelected = false;

            }
            else if (isSelected())
            {
                if (!thingSelected)
                {
                    KNT_Game.setButtonInHand(this);
                    thingSelected = true;
                }
            }
        }

        protected override void draw()
        {
            if (location.Contains(new Point(mouse.X, mouse.Y)) && !isInPlay)
            {
                spriteBatch.Draw(image,
                                 new Rectangle(location.X - 15, location.Y, 50, 50),
                                 Color.White);
                spriteBatch.Draw(image,
                                 new Rectangle(525, 145, 100, 95),
                                 Color.White);
            }
            else if (!isInPlay)
            {
                spriteBatch.Draw(image,
                                 location,
                                 Color.White);
            }
        }

        public override void Update()
        {
            if (thingSelected)
            {
                location.X = mouse.X;
                location.Y = mouse.Y;
            }

            base.Update();
        }

        public bool inPlay()
        {
            return isInPlay;
        }

        public void putInPlay()
        {
            if (!isInPlay)
            {
                isInPlay = true;
                thingSelected = false;
                KNT_Game.me.playThing(buttonID);
                KNT_Game.me.setHandsFull();
            }
            else if ( KNT_Game.me.rackContains(buttonID) && isInPlay )
            {
                KNT_Game.emptyHand();
                isInPlay = false;
            }
        }

        public Thing getThing()
        {
            return thingOnButton;
        }

        private Thing thingOnButton;
        private Player owner;
        private Rectangle originalPosition;
        private int buttonID;
        private bool thingSelected,
                     isInPlay;
    }
}
