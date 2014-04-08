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
        public HexButton(Texture2D[] texture, SpriteBatch sBatch, int width, int height, int x, int y, Tile t, Texture2D[] forts) :
            base(texture, sBatch, width, height, x, y, t)
        {
            hex = t;
            hexNumber = hex.getHexNum();
            backside = texture[0];
            spriteB = sBatch;
            fortTexture = forts;
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
                                this.hex.getPlayer() == null && this.hex.adjacencyRule(KNT_Game.me) &&
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
                        if(hex.doesPlayerHaveStack(KNT_Game.me.getPlayerNumber()) && !KNT_Game.me.handsFull())
                        {
                            foreach(Tile t in GameBoard.Game.getMap().getHexList())
                                t.resetMovementLogic();
                            ((MovementPhase)GameBoard.Game.getCurrentPhaseObject()).checkMovement(hexNumber, 4);
                            KNT_Game.putStackInHand(stack.getList());
                            KNT_Game.removeStack(stack);
                            hex.clearPlayerStack(KNT_Game.me.getPlayerNumber());
                            stack = null;
                        }
                        else if (hex.traversed && KNT_Game.me.handsFull() && !hex.doesPlayerHaveStack(KNT_Game.me.getPlayerNumber()))
                        {
                            stack = KNT_Game.createStack(hex, KNT_Game.getStackInHand(), spriteB);
                            if (KNT_Game.me.getPlayerNumber() == 1)
                                stack.Location(0 + topleft.X, 35 + topleft.Y);
                            if (KNT_Game.me.getPlayerNumber() == 2)
                                stack.Location(25 + topleft.X, 35 + topleft.Y);
                            if (KNT_Game.me.getPlayerNumber() == 3)
                                stack.Location(0 + topleft.X, 65 + topleft.Y);
                            if (KNT_Game.me.getPlayerNumber() == 4)
                                stack.Location(25 + topleft.X, 65 + topleft.Y);
                            foreach (Tile t in GameBoard.Game.getMap().getHexList())
                                t.resetMovementLogic();
                            if (this.hex.getPlayerControlBool() == false)
                            {
                                this.hex.setPlayerControl(KNT_Game.me);
                                this.hex.setPlayerControlBool(true);
                                KNT_Game.me.addOwnedTile(this.hex);
                                KNT_Game.createMarker(topleft, KNT_Game.me.getPlayerNumber(), spriteB);
                            }
                        }
                        else if (hex.traversed && KNT_Game.me.handsFull() && hex.doesPlayerHaveStack(KNT_Game.me.getPlayerNumber()))
                        {
                            List<Thing> temp = new List<Thing>();
                            temp = KNT_Game.getStackInHand();
                            foreach (Thing aThing in temp)
                                hex.addToPlayerStack(KNT_Game.me.getPlayerNumber(), aThing);

                            KNT_Game.removeStack(stack);
                            stack = KNT_Game.createStack(hex, hex.getPlayerStack(KNT_Game.me.getPlayerNumber()), spriteB);
                            if (KNT_Game.me.getPlayerNumber() == 1)
                                stack.Location(0 + topleft.X, 35 + topleft.Y);
                            if (KNT_Game.me.getPlayerNumber() == 2)
                                stack.Location(25 + topleft.X, 35 + topleft.Y);
                            if (KNT_Game.me.getPlayerNumber() == 3)
                                stack.Location(0 + topleft.X, 65 + topleft.Y);
                            if (KNT_Game.me.getPlayerNumber() == 4)
                                stack.Location(25 + topleft.X, 65 + topleft.Y);
                            

                            foreach (Tile t in GameBoard.Game.getMap().getHexList())
                                t.resetMovementLogic();
                        }

                        break;

                    case "Combat":
                        if (this.hex.getCFlag())
                        {
                            if (this.hex.doesPlayerHaveStack(KNT_Game.me.getPlayerNumber()))
                            {
                                resolveCombat(this.hex);
                            }
                        }
                        break;

                    case "Construction":
                        if (this.hex.getPlayer() == KNT_Game.me)
                        {
                            if (this.hex.getFort() < 3 && KNT_Game.me.getPlayerGold() >= 5)
                            {
                                KNT_Game.me.takePlayerGold(5);
                                this.hex.upgradeFort();
                            }
                            if (this.hex.getFort() == 4)
                            {
                                //check income > 15
                                int g = 0;
                                foreach (Tile t in KNT_Game.me.getOwnedTiles())
                                {
                                    g++;
                                    g = g + t.getFort();
                                }
                                //if so, upgrade Fort
                                this.hex.upgradeFort();
                                ((ConstructionPhase)GameBoard.Game.getCurrentPhaseObject()).citadelBuilt();
                            }
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
            if (this.hex.getFort() > 0)
            {
                spriteBatch.Draw(fortTexture[this.hex.getFort() - 1], new Rectangle(topleft.X + 25, topleft.Y + 12, 30, 30), Color.White);
            }

        }

        private bool IsInsideTriangle(Point A, Point B, Point C, Point P)
        {
            int planeAB = (A.X - P.X) * (B.Y - P.Y) - (B.X - P.X) * (A.Y - P.Y);
            int planeBC = (B.X - P.X) * (C.Y - P.Y) - (C.X - P.X) * (B.Y - P.Y);
            int planeCA = (C.X - P.X) * (A.Y - P.Y) - (A.X - P.X) * (C.Y - P.Y);
            return sign(planeAB) == sign(planeBC) && sign(planeBC) == sign(planeCA);

        }

        public void resolveCombat(Tile t)
        {
            bool resolved = false;
            int attacker = t.getPlayer().getPlayerNumber();
            int defender = 0;
            for (int i = 1; i < 5; i++)
            {
                if (i != KNT_Game.me.getPlayerNumber())
                {
                    if (t.doesPlayerHaveStack(i))
                        defender = i;
                }
            }

            while (!resolved)
            {
                BattleForm combat;

                List<Thing> attackerStack = t.getPlayerStack(attacker);
                List<Thing> defenderStack = t.getPlayerStack(defender);

                Random r = new Random();
                int attackerRolls = 0;
                int defenderRolls = 0;

                foreach (Thing aThing in attackerStack)
                {
                    if (aThing.combatScore() <= r.Next(1, 7))
                        attackerRolls++;
                }

                foreach (Thing aThing in defenderStack)
                {
                    if (aThing.combatScore() <= r.Next(1, 7))
                        defenderRolls++;
                }


                combat = new BattleForm(attackerStack, defenderStack, attackerRolls, defenderRolls);
                combat.ShowDialog();

                //List<Thing> attackerMagicStack = findAttribute(attackerStack, Attributes.CombatAttributes.MAGIC);
                //List<Thing> defenderMagicStack = findAttribute(defenderStack, Attributes.CombatAttributes.MAGIC);

                //List<Thing> attackerRangeStack = findAttribute(attackerStack, Attributes.CombatAttributes.RANGED);
                //List<Thing> defenderRangeStack = findAttribute(defenderStack, Attributes.CombatAttributes.RANGED);

                //List<Thing> attackerMeleeStack = findAttribute(attackerStack, Attributes.CombatAttributes.MAGIC);
                //List<Thing> defenderMeleeStack = findAttribute(defenderStack, Attributes.CombatAttributes.MAGIC);
            }
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
        private Texture2D[] fortTexture;
        private MarkerButton marker;
        private SpriteBatch spriteB;
        private StackButton stack;
    }
}
