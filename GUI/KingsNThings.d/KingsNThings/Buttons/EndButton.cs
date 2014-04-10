using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameLogic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using KingsNThings.GUI;
using GameLogic.Managers;
using GameLogic.Phases;

namespace KingsNThings.Buttons
{
    public class EndButton : Button
    {
        public EndButton(Texture2D texture,SpriteBatch sBatch, int width, int height, int x, int y) :
            base(texture, sBatch, width, height, x, y)
        {
            image = texture;
            
        }

        protected override void isClicked()
        {
            if (endClicked() && canEnd)
            {
                KNT_Game.me.donePhase();
                canEnd = false;

            }
        }

        private void isCanEnd()
        {
            if (GameBoard.Game.getCurrentPhase().getName().Equals("Recruit Things") &&
                ((RecruitThingsPhase)GameBoard.Game.getCurrentPhase()).canBeDone())
                canEnd = true;
            else if (GameBoard.Game.getCurrentPhase().getName().Equals("Movement") || GameBoard.Game.getCurrentPhase().getName().Equals("Construction") ||
                     GameBoard.Game.getCurrentPhase().getName().Equals("Combat"))
                canEnd = true;
            else
                canEnd = false;
        }

        private bool endClicked()
        {
            if (location.Contains(new Point(mouse.X, mouse.Y)))
                return true;

            return false;
        }

        public override void Update()
        {
            isCanEnd();

            base.Update();
        }

        protected override void draw()
        {
            if (location.Contains(new Point(mouse.X, mouse.Y)))
            {
                spriteBatch.Draw(image,
                    location,
                    Color.DimGray);

            }
            else if (!canEnd)
            {
                spriteBatch.Draw(image,
                    location,
                    Color.DimGray);
            }
            else
            {
                switch (GameBoard.Game.getCurrentPhase().getName())
                {
                    case "Recruit Things":
                        spriteBatch.Draw(image, location, Color.White);
                        break;

                    case "Movement":
                        spriteBatch.Draw(image, location, Color.White);
                        break;
                    case "Combat":
                        spriteBatch.Draw(image, location, Color.White);
                        break;
                    case "Construction":
                        spriteBatch.Draw(image, location, Color.White);
                        break;

                }
            }
        }

        bool canEnd = false;
    }
}
