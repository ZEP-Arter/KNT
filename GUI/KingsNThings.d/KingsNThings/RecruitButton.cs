using GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Threading.Tasks;

namespace KingsNThings
{
    public class RecruitButton : Button
    {
        //DOES NOT HAVE A MONEY LIMIT
        public RecruitButton(Texture2D texture, SpriteBatch spriteBatch, int width, int height, int x, int y):
            base(texture, spriteBatch, width, height, x, y)
        {
            canRecruit = false;
            sBatch = spriteBatch;
        }

        private bool recruitClicked()
        {
            if (location.Contains(new Point(mouse.X, mouse.Y)))
                return true;

            return false;
        }

        protected override void isClicked()
        {
            if (recruitClicked() && canRecruit)
            {
                Thing thing = ((RecruitThingsPhase)GameBoard.Game.getCurrentPhaseObject()).recruitThings();

                if (thing != null)
                {
                    if (KNT_Game.me.getPlayerNumber() == 1)
                    {
                        KNT_Game.P1Tiles.Add(new ThingButton(KNT_Game.scripttileTexture[20], KNT_Game.me, sBatch, thing, 30, 30, 675 + ((KNT_Game.me.numberOfRackTiles() - 5) * 60), 55));
                    }
                    else if (KNT_Game.me.getPlayerNumber() == 2)
                    {
                        KNT_Game.P2Tiles.Add(new ThingButton(KNT_Game.scripttileTexture[20], KNT_Game.me, sBatch, thing, 30, 30, 675 + ((KNT_Game.me.numberOfRackTiles() - 5) * 60), 190));
                    }
                    else if (KNT_Game.me.getPlayerNumber() == 3)
                    {
                        KNT_Game.P3Tiles.Add(new ThingButton(KNT_Game.scripttileTexture[20], KNT_Game.me, sBatch, thing, 30, 30, 675 + ((KNT_Game.me.numberOfRackTiles() - 5) * 60), 325));
                    }
                    else if (KNT_Game.me.getPlayerNumber() == 4)
                    {
                        KNT_Game.P4Tiles.Add(new ThingButton(KNT_Game.scripttileTexture[20], KNT_Game.me, sBatch, thing, 30, 30, 675 + ((KNT_Game.me.numberOfRackTiles() - 5) * 60), 460));
                    }
                }
                /*
                if (KNT_Game.me.getPlayerNumber() == 1)
                {
                    if(KNT_Game.me.numberOfRackTiles() > 5)
                        KNT_Game.P1Tiles.Add(new ThingButton (KNT_Game.scripttileTexture[20], KNT_Game.me, sBatch, GameBoard.Game.getRandomThingFromCup(), 30, 30, 675 + ((KNT_Game.me.numberOfRackTiles() - 5)* 60) ,55));
                    else
                        KNT_Game.P1Tiles.Add(new ThingButton (KNT_Game.scripttileTexture[20], KNT_Game.me, sBatch, GameBoard.Game.getRandomThingFromCup(), 30, 30, 675 + ((KNT_Game.me.numberOfRackTiles() - 5)* 60) ,5));
                }
                else if (KNT_Game.me.getPlayerNumber() == 2)
                {
                     if(KNT_Game.me.numberOfRackTiles() > 5)
                        KNT_Game.P1Tiles.Add(new ThingButton (KNT_Game.scripttileTexture[20], KNT_Game.me, sBatch, GameBoard.Game.getRandomThingFromCup(), 30, 30, 675 + ((KNT_Game.me.numberOfRackTiles() - 5)* 60) ,190));
                    else
                        KNT_Game.P1Tiles.Add(new ThingButton (KNT_Game.scripttileTexture[20], KNT_Game.me, sBatch, GameBoard.Game.getRandomThingFromCup(), 30, 30, 675 + ((KNT_Game.me.numberOfRackTiles() - 5)* 60) ,140));
                }
                else if (KNT_Game.me.getPlayerNumber() == 3)
                {
                     if(KNT_Game.me.numberOfRackTiles() > 5)
                         KNT_Game.P1Tiles.Add(new ThingButton(KNT_Game.scripttileTexture[20], KNT_Game.me, sBatch, GameBoard.Game.getRandomThingFromCup(), 30, 30, 675 + ((KNT_Game.me.numberOfRackTiles() - 5) * 60), 325));
                    else
                        KNT_Game.P1Tiles.Add(new ThingButton (KNT_Game.scripttileTexture[20], KNT_Game.me, sBatch, GameBoard.Game.getRandomThingFromCup(),30, 30, 675 + ((KNT_Game.me.numberOfRackTiles() - 5)* 60) ,275));
                }
                else if (KNT_Game.me.getPlayerNumber() == 4)
                {
                     if(KNT_Game.me.numberOfRackTiles() > 5)
                         KNT_Game.P1Tiles.Add(new ThingButton(KNT_Game.scripttileTexture[20], KNT_Game.me, sBatch, GameBoard.Game.getRandomThingFromCup(), 30, 30, 675 + ((KNT_Game.me.numberOfRackTiles() - 5) * 60), 460));
                    else
                         KNT_Game.P1Tiles.Add(new ThingButton(KNT_Game.scripttileTexture[20], KNT_Game.me, sBatch, GameBoard.Game.getRandomThingFromCup(), 30, 30, 675 + ((KNT_Game.me.numberOfRackTiles() - 5) * 60), 410));
                }*/

                canRecruit = false;
            }
        }

        public override void Update()
        {
            if (KNT_Game.me != null && KNT_Game.me.getGold() >= 5 &&
                !KNT_Game.me.isRackFull() &&
                GameBoard.Game.getCurrentPhase().Equals("Recruit Things"))
            {
                canRecruit = true;
            }

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

            else if(!canRecruit) {
                
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
        }
        private bool canRecruit;
        SpriteBatch sBatch;
    }
}
