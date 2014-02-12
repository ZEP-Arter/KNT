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
    public class HexButton : Button
    {
        public HexButton(Texture2D[] texture, SpriteBatch sBatch, int width, int height, int x, int y, Tile t) :
            base(texture, sBatch, width, height, x, y, t)
        {
            hex = t;
            hexNumber = hex.getHexNum();
            backside = texture[0];
            spriteB = sBatch;
        }

        protected override void isClicked()
        {
            if ((IsInsideTriangle(topleft, midleft, botleft, new Point(mouse.X, mouse.Y)) ||
                 middle.Contains(new Point(mouse.X, mouse.Y)) ||
                 IsInsideTriangle(topright, midright, botright, new Point(mouse.X, mouse.Y)))) //HEX TILES
            {
                switch (GameBoard.Game.getCurrentPhase())
                {
                    case "Setup":
                        if ((marker = KNT_Game.getMyMarker()) != null)
                        {
                            if (marker.getMarkerSelected() && (this.hex.getStart() || this.hex.getPlayerAble() == KNT_Game.me) &&
                                (this.hex.getPlayerAble() == null || this.hex.getPlayerAble() == KNT_Game.me) && 
                                this.hex.getPlayer() == null &&
                                this.hex.getType() != "Sea")
                            {
                                this.hex.selectedAsStarting(KNT_Game.me);
                                KNT_Game.me.addOwnedTile(hex);
                                marker.setIsSet(true);
                                marker.setMarkerSelected(false);
                                marker.Location(25 + topleft.X, 5 + topleft.Y);
                                KNT_Game.me.placeMarker(marker.getButtonID());
                                KNT_Game.me.setCurrentMarker(marker.getButtonID());
                                KNT_Game.me.setHandsFull();
                            }
                        }
                        break;

                    case "Recruit Things":
                        if(KNT_Game.getButtonInHand() != null)
                        {
                            if(hex.doesPlayerHaveStack(KNT_Game.me.getPlayerNumber()))
                            {
                                if (stack.canAddToStack())
                                {
                                    ((ThingButton)KNT_Game.getButtonInHand()).putInPlay();
                                    hex.addToPlayerStack(KNT_Game.me.getPlayerNumber(), ((ThingButton)KNT_Game.getButtonInHand()).getThing());
                                    stack.addThings(((ThingButton)KNT_Game.getButtonInHand()).getThing());
                                }
                            }
                            else 
                            {
                                if (hex.getPlayer() != null && hex.getPlayer().getName() == KNT_Game.me.getName())
                                {
                                    stack = KNT_Game.createStack(hex,
                                            ((ThingButton)KNT_Game.getButtonInHand()).getThing(), spriteB);

                                    if (stack.canAddToStack())
                                    {
                                        ((ThingButton)KNT_Game.getButtonInHand()).putInPlay();
                                        hex.addToPlayerStack(KNT_Game.me.getPlayerNumber(), ((ThingButton)KNT_Game.getButtonInHand()).getThing());
                                    }

                                    if (KNT_Game.me.getPlayerNumber() == 1)
                                        stack.Location(0 + topleft.X, 35 + topleft.Y);
                                    if (KNT_Game.me.getPlayerNumber() == 2)
                                        stack.Location(25 + topleft.X, 35 + topleft.Y);
                                    if (KNT_Game.me.getPlayerNumber() == 3)
                                        stack.Location(0 + topleft.X, 65 + topleft.Y);
                                    if (KNT_Game.me.getPlayerNumber() == 4)
                                        stack.Location(25 + topleft.X, 65 + topleft.Y);
                                }


                            }
                        }
                        break;

                    case "Movement":

                        break;

                    case "Combat":
                        if (this.hex.getCFlag())
                        {
                            ((CombatPhase)GameBoard.Game.getCurrentPhaseObject()).resolveCombat(this.hex);
                        }
                        break;
                }
            }
        }

        protected override void draw()
        {
            if ((IsInsideTriangle(topleft, midleft, botleft, new Point(mouse.X, mouse.Y)) ||
                middle.Contains(new Point(mouse.X, mouse.Y)) ||
                IsInsideTriangle(topright, midright, botright, new Point(mouse.X, mouse.Y))))
            {
                spriteBatch.Draw(image,
                    location,
                    Color.Silver);
            }
            else if(hex.traversed)
            {
                spriteBatch.Draw(image,
                    location,
                    Color.Blue);
            }
            else
            {
                spriteBatch.Draw(image,
                    location,
                    Color.White);
            }
        }

        private bool IsInsideTriangle(Point A, Point B, Point C, Point P)
        {
            int planeAB = (A.X - P.X) * (B.Y - P.Y) - (B.X - P.X) * (A.Y - P.Y);
            int planeBC = (B.X - P.X) * (C.Y - P.Y) - (C.X - P.X) * (B.Y - P.Y);
            int planeCA = (C.X - P.X) * (A.Y - P.Y) - (A.X - P.X) * (C.Y - P.Y);
            return sign(planeAB) == sign(planeBC) && sign(planeBC) == sign(planeCA);

        }

        private int sign(int n)
        {
            if (n != 0)
            {
                return Math.Abs(n) / n;
            }
            else return 0;
        }

        private Tile hex;
        private int hexNumber;
        private Texture2D backside;
        private MarkerButton marker;
        private SpriteBatch spriteB;
        private StackButton stack;
    }
}
