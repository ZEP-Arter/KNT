﻿using GameLogic;
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
using KingsNThings.GUI;
using GameLogic.Things;
using GameLogic.Phases;
using GameLogic.Managers;

namespace KingsNThings.Buttons
{
    public class RecruitButton : Button
    {
        //DOES NOT HAVE A MONEY LIMIT
        public RecruitButton(Texture2D texture, SpriteBatch spriteBatch, int width, int height, int x, int y):
            base(texture, spriteBatch, width, height, x, y)
        {
            canRecruit = false;
            sBatch = spriteBatch;

            P1rack = new List<Point>();
            P1rack.Add(new Point(675, 5));
            P1rack.Add(new Point(735, 5));
            P1rack.Add(new Point(785, 5));
            P1rack.Add(new Point(845, 5));
            P1rack.Add(new Point(905, 5));
            P1rack.Add(new Point(675, 55));
            P1rack.Add(new Point(735, 55));
            P1rack.Add(new Point(785, 55));
            P1rack.Add(new Point(845, 55));
            P1rack.Add(new Point(905, 55));

            P2rack = new List<Point>();
            P2rack.Add(new Point(675, 140));
            P2rack.Add(new Point(735, 140));
            P2rack.Add(new Point(785, 140));
            P2rack.Add(new Point(845, 140));
            P2rack.Add(new Point(905, 140));
            P2rack.Add(new Point(675, 190));
            P2rack.Add(new Point(735, 190));
            P2rack.Add(new Point(785, 190));
            P2rack.Add(new Point(845, 190));
            P2rack.Add(new Point(905, 190));

            P3rack = new List<Point>();
            P3rack.Add(new Point(675, 275));
            P3rack.Add(new Point(735, 275));
            P3rack.Add(new Point(785, 275));
            P3rack.Add(new Point(845, 275));
            P3rack.Add(new Point(905, 275));
            P3rack.Add(new Point(675, 325));
            P3rack.Add(new Point(735, 325));
            P3rack.Add(new Point(785, 325));
            P3rack.Add(new Point(845, 325));
            P3rack.Add(new Point(905, 325));

            P4rack = new List<Point>();
            P4rack.Add(new Point(675, 410));
            P4rack.Add(new Point(735, 410));
            P4rack.Add(new Point(785, 410));
            P4rack.Add(new Point(845, 410));
            P4rack.Add(new Point(905, 410));
            P4rack.Add(new Point(675, 460));
            P4rack.Add(new Point(735, 460));
            P4rack.Add(new Point(785, 460));
            P4rack.Add(new Point(845, 460));
            P4rack.Add(new Point(905, 460));
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
                Thing thing = ((RecruitThingsPhase)GameBoard.Game.getCurrentPhase()).recruitThings();
                bool check = false;
                if (thing != null)
                {
                    if (KNT_Game.me.getPlayerNumber() == 1)
                    {
                        foreach (Point point in P1rack)
                        {
                            foreach (ThingButton button in KNT_Game.P1Tiles)
                            {
                                if (button.location.Contains(point))
                                {
                                    check = true;
                                }
                            }
                            if (!check)
                            {
                                KNT_Game.P1Tiles.Add(new ThingButton(KNT_Game.thingTexture[thing.getTextureID()], KNT_Game.me, sBatch, thing, 30, 30, point.X, point.Y));

                                break;
                            }
                            check = false;
                        }

                    }
                    else if (KNT_Game.me.getPlayerNumber() == 2)
                    {
                        foreach (Point point in P2rack)
                        {
                            foreach (ThingButton button in KNT_Game.P2Tiles)
                            {
                                if (button.location.Contains(point))
                                {
                                    check = true;
                                }
                            }
                            if (!check)
                            {
                                KNT_Game.P2Tiles.Add(new ThingButton(KNT_Game.thingTexture[thing.getTextureID()], KNT_Game.me, sBatch, thing, 30, 30, point.X, point.Y));

                                break;
                            }
                            check = false;
                        }
                    }
                    else if (KNT_Game.me.getPlayerNumber() == 3)
                    {
                        foreach (Point point in P3rack)
                        {
                            foreach (ThingButton button in KNT_Game.P3Tiles)
                            {
                                if (button.location.Contains(point))
                                {
                                    check = true;
                                }
                            }
                            if (!check)
                            {
                                KNT_Game.P3Tiles.Add(new ThingButton(KNT_Game.thingTexture[thing.getTextureID()], KNT_Game.me, sBatch, thing, 30, 30, point.X, point.Y));

                                break;
                            }
                            check = false;
                        }
                    }
                    else if (KNT_Game.me.getPlayerNumber() == 4)
                    {
                        foreach (Point point in P4rack)
                        {
                            foreach (ThingButton button in KNT_Game.P4Tiles)
                            {
                                if (button.location.Contains(point))
                                {
                                    check = true;
                                }
                            }
                            if (!check)
                            {
                                KNT_Game.P4Tiles.Add(new ThingButton(KNT_Game.thingTexture[thing.getTextureID()], KNT_Game.me, sBatch, thing, 30, 30, point.X, point.Y));

                                break;
                            }
                            check = false;
                        }
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
                GameBoard.Game.getCurrentPhase().getName().Equals("Recruit Things"))
            {
                canRecruit = true;
            }
            else
            {
                canRecruit = false;
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
        List<Point> P1rack;
        List<Point> P2rack;
        List<Point> P3rack;
        List<Point> P4rack;
    }
}
