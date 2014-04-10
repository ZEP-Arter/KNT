using GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Windows.Forms;
using KingsNThings.GUI;
using KingsNThings.Forms;
using GameLogic.Managers;
using GameLogic.Things;
using GameLogic.Utils.Forms;
using GameLogic.Phases;

namespace KingsNThings.Buttons
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
            stacks = new Dictionary<int, StackButton>(4);
            stacks[1] = null;
            stacks[2] = null;
            stacks[3] = null;
            stacks[4] = null;
        }

        protected override void isClicked()
        {
            if ((IsInsideTriangle(topleft, midleft, botleft, new Point(mouse.X, mouse.Y)) ||
                 middle.Contains(new Point(mouse.X, mouse.Y)) ||
                 IsInsideTriangle(topright, midright, botright, new Point(mouse.X, mouse.Y)))) //HEX TILES
            {
                Thread.Sleep(1);
                switch (GameBoard.Game.getCurrentPhase().getName())
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
                                currentMarkerID = marker.getButtonID();
                                marker.setIsSet(true);
                                marker.setMarkerSelected(false);
                                marker.Location(25 + topleft.X, 5 + topleft.Y);
                                KNT_Game.me.placeMarker(marker.getButtonID());
                                KNT_Game.me.setCurrentMarker(marker.getButtonID());
                                KNT_Game.me.setHandsFull();
                            }
                        }
                        else if (((SetupPhase)GameBoard.Game.getCurrentPhase()).getTowerPlacementPhase() && this.hex.getPlayerControlBool())
                        {
                            if (this.hex.getPlayer() == KNT_Game.me)
                            {
                                KNT_Game.me.towerPlaced = 1;
                                this.hex.upgradeFort();
                            }
                        }
                        break;

                    case "Recruit Things":
                        if(KNT_Game.getButtonInHand() != null)
                        {
                            if(hex.doesPlayerHaveStack(KNT_Game.me.getPlayerNumber()))
                            {
                                if (stacks[KNT_Game.me.getPlayerNumber()].canAddToStack())
                                {
                                    ((ThingButton)KNT_Game.getButtonInHand()).putInPlay();
                                    hex.addToPlayerStack(KNT_Game.me.getPlayerNumber(), ((ThingButton)KNT_Game.getButtonInHand()).getThing());
                                    stacks[KNT_Game.me.getPlayerNumber()].addThings(((ThingButton)KNT_Game.getButtonInHand()).getThing());
                                    KNT_Game.buttonInHand = null;
                                }
                            }
                            else 
                            {
                                if (hex.getPlayer() != null && hex.getPlayer().getName() == KNT_Game.me.getName())
                                {
                                    stacks[KNT_Game.me.getPlayerNumber()] = KNT_Game.createStack(hex,
                                            ((ThingButton)KNT_Game.getButtonInHand()).getThing(), spriteB);

                                    if (stacks[KNT_Game.me.getPlayerNumber()].canAddToStack())
                                    {
                                        ((ThingButton)KNT_Game.getButtonInHand()).putInPlay();
                                        hex.addToPlayerStack(KNT_Game.me.getPlayerNumber(), ((ThingButton)KNT_Game.getButtonInHand()).getThing());
                                        KNT_Game.buttonInHand = null;
                                    }

                                    if (KNT_Game.me.getPlayerNumber() == 1)
                                        stacks[1].Location(0 + topleft.X, 35 + topleft.Y);
                                    if (KNT_Game.me.getPlayerNumber() == 2)
                                        stacks[2].Location(25 + topleft.X, 35 + topleft.Y);
                                    if (KNT_Game.me.getPlayerNumber() == 3)
                                        stacks[3].Location(0 + topleft.X, 65 + topleft.Y);
                                    if (KNT_Game.me.getPlayerNumber() == 4)
                                        stacks[4].Location(25 + topleft.X, 65 + topleft.Y);
                                }


                            }
                        }
                        break;

                    case "Movement":
                        if (hex.doesPlayerHaveStack(KNT_Game.me.getPlayerNumber()) && !KNT_Game.me.handsFull() && hex.movePossible[KNT_Game.me.getPlayerNumber()])
                        {
                            foreach(Tile t in GameBoard.Game.getMap().getHexList())
                                t.resetMovementLogic();
                            ((MovementPhase)GameBoard.Game.getCurrentPhase()).checkMovement(hexNumber, 4);
                            KNT_Game.putStackInHand(stacks[KNT_Game.me.getPlayerNumber()].getList());
                            KNT_Game.removeStack(stacks[KNT_Game.me.getPlayerNumber()]);
                            hex.clearPlayerStack(KNT_Game.me.getPlayerNumber());
                            stacks[KNT_Game.me.getPlayerNumber()] = null;
                        }
                        else if (hex.traversed && KNT_Game.me.handsFull() && !hex.doesPlayerHaveStack(KNT_Game.me.getPlayerNumber()))
                        {
                            stacks[KNT_Game.me.getPlayerNumber()] = KNT_Game.createStack(hex, KNT_Game.getStackInHand(), spriteB);
                            hex.movePossible[KNT_Game.me.getPlayerNumber()] = false;
                            foreach (Thing aThing in stacks[KNT_Game.me.getPlayerNumber()].getList())
                                hex.addToPlayerStack(KNT_Game.me.getPlayerNumber(), aThing);
                            if (KNT_Game.me.getPlayerNumber() == 1)
                                stacks[1].Location(0 + topleft.X, 35 + topleft.Y);
                            if (KNT_Game.me.getPlayerNumber() == 2)
                                stacks[2].Location(25 + topleft.X, 35 + topleft.Y);
                            if (KNT_Game.me.getPlayerNumber() == 3)
                                stacks[3].Location(0 + topleft.X, 65 + topleft.Y);
                            if (KNT_Game.me.getPlayerNumber() == 4)
                                stacks[4].Location(25 + topleft.X, 65 + topleft.Y);
                            foreach (Tile t in GameBoard.Game.getMap().getHexList())
                                t.resetMovementLogic();
                            if (this.hex.getPlayerControlBool() == false)
                            {
                                KNT_Game.deleteMarker(currentMarkerID);
                                this.hex.setPlayerControl(KNT_Game.me);
                                this.hex.setPlayerControlBool(true);
                                KNT_Game.me.addOwnedTile(this.hex);
                                currentMarkerID = KNT_Game.createMarker(topleft, KNT_Game.me.getPlayerNumber(), spriteB);
                            }
                            else if (this.hex.getPlayerControlBool() && this.hex.getPlayer() != KNT_Game.me)
                            {
                                if (stacks[this.hex.getPlayer().getPlayerNumber()] == null)
                                {
                                    KNT_Game.deleteMarker(currentMarkerID);
                                    this.hex.getPlayer().removeOwnedTile(this.hex);
                                    this.hex.setPlayerControl(KNT_Game.me);
                                    this.hex.setPlayerControlBool(true);
                                    KNT_Game.me.addOwnedTile(this.hex);
                                    currentMarkerID = KNT_Game.createMarker(topleft, KNT_Game.me.getPlayerNumber(), spriteB);
                                }
                            }
                        }
                        else if (hex.traversed && KNT_Game.me.handsFull() && hex.doesPlayerHaveStack(KNT_Game.me.getPlayerNumber()))
                        {
                            List<Thing> temp = new List<Thing>();
                            temp = KNT_Game.getStackInHand();
                            foreach (Thing aThing in temp)
                                hex.addToPlayerStack(KNT_Game.me.getPlayerNumber(), aThing);

                            KNT_Game.removeStack(stacks[KNT_Game.me.getPlayerNumber()]);
                            stacks[KNT_Game.me.getPlayerNumber()] = KNT_Game.createStack(hex, hex.getPlayerStack(KNT_Game.me.getPlayerNumber()), spriteB);
                            hex.movePossible[KNT_Game.me.getPlayerNumber()] = false;
                            if (KNT_Game.me.getPlayerNumber() == 1)
                                stacks[1].Location(0 + topleft.X, 35 + topleft.Y);
                            if (KNT_Game.me.getPlayerNumber() == 2)
                                stacks[2].Location(25 + topleft.X, 35 + topleft.Y);
                            if (KNT_Game.me.getPlayerNumber() == 3)
                                stacks[3].Location(0 + topleft.X, 65 + topleft.Y);
                            if (KNT_Game.me.getPlayerNumber() == 4)
                                stacks[4].Location(25 + topleft.X, 65 + topleft.Y);
                            

                            foreach (Tile t in GameBoard.Game.getMap().getHexList())
                                t.resetMovementLogic();
                        }

                        break;

                    case "Combat":
                        if (this.hex.getCFlag())
                        {
                            if (this.hex.doesPlayerHaveStack(KNT_Game.me.getPlayerNumber()))
                            {
                                Thread.Sleep(1);
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
                            if (this.hex.getFort() == 3 )
                            {
                                bool haveCitadel = false;
                                //check income > 15
                                int g = 0;
                                foreach (Tile t in KNT_Game.me.getOwnedTiles())
                                {
                                    g++;
                                    g = g + t.getFort();
                                    if (t.getFort() == 4)
                                        haveCitadel = true;
                                }
                                //if so, upgrade Fort
                                if (!haveCitadel && g >=15)
                                {
                                    this.hex.upgradeFort();
                                    ((ConstructionPhase)GameBoard.Game.getCurrentPhase()).citadelBuilt();
                                }
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
            else if (hex.getCFlag())
            {
                spriteBatch.Draw(image, location, Color.Red);
            }
            else
            {
                spriteBatch.Draw(image,
                    location,
                    Color.White);
            }
            if (this.hex.getFort() > 0)
            {
                spriteBatch.Draw(fortTexture[this.hex.getFort() - 1], new Rectangle(topleft.X + 1, topleft.Y + 6, 30, 30), Color.White);
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
            int attacker = 0;
            int defender = t.getPlayer().getPlayerNumber();
            for (int i = 1; i < 5; i++)
            {
                if (i != defender)
                {
                    if (t.doesPlayerHaveStack(i))
                        attacker = i;
                }
            }

            BattleForm combatF;

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


            combatF = new BattleForm(attackerStack, defenderStack, attackerRolls, defenderRolls, attacker, defender);
            DialogResult dResult = combatF.ShowDialog();

            //Tile stack for attacker is refreshed
            this.hex.clearPlayerStack(attacker);
            foreach (Thing aThing in combatF.getAttackerStack())
                this.hex.addToPlayerStack(attacker, aThing);
            KNT_Game.removeStack(stacks[attacker]);
            if (this.hex.doesPlayerHaveStack(attacker))
            {
                stacks[attacker] = KNT_Game.createStack(this.hex, this.hex.getPlayerStack(attacker), spriteBatch);
                if (attacker == 1)
                    stacks[attacker].Location(0 + topleft.X, 35 + topleft.Y);
                if (attacker == 2)
                    stacks[attacker].Location(25 + topleft.X, 35 + topleft.Y);
                if (attacker == 3)
                    stacks[attacker].Location(0 + topleft.X, 65 + topleft.Y);
                if (attacker == 4)
                    stacks[attacker].Location(25 + topleft.X, 65 + topleft.Y);

                stacks[attacker].thingsInStack = this.hex.getPlayerStack(attacker);
            }

            //Tile stack for defender is refreshed
                this.hex.clearPlayerStack(defender);
            foreach (Thing aThing in combatF.getDefenderStack())
                this.hex.addToPlayerStack(defender, aThing);
            KNT_Game.removeStack(stacks[defender]);
            if (this.hex.doesPlayerHaveStack(defender))
            {
                stacks[defender] = KNT_Game.createStack(this.hex, this.hex.getPlayerStack(defender), spriteBatch);
                if (defender == 1)
                    stacks[defender].Location(0 + topleft.X, 35 + topleft.Y);
                if (defender == 2)
                    stacks[defender].Location(25 + topleft.X, 35 + topleft.Y);
                if (defender == 3)
                    stacks[defender].Location(0 + topleft.X, 65 + topleft.Y);
                if (defender == 4)
                    stacks[defender].Location(25 + topleft.X, 65 + topleft.Y);

                stacks[defender].thingsInStack = this.hex.getPlayerStack(defender);
            }

            if (!this.hex.doesPlayerHaveStack(attacker) || !this.hex.doesPlayerHaveStack(defender))
            {
                resolved = true;
                this.hex.setCFlag(false);

                //CONQUER BY COMBAT
                if (this.hex.doesPlayerHaveStack(attacker))
                {
                    KNT_Game.deleteMarker(currentMarkerID);
                    this.hex.getPlayer().removeOwnedTile(this.hex);
                    this.hex.setPlayerControl(GameBoard.Game.getPlayerByNumber(attacker));
                    this.hex.setPlayerControlBool(true);
                    GameBoard.Game.getPlayerByNumber(attacker).addOwnedTile(this.hex);
                    int c = 0;
                    foreach(Tile aTile in GameBoard.Game.getPlayerByNumber(attacker).getOwnedTiles())
                    {
                        if (aTile.getFort() == 4)
                            c++;
                    }
                    if (c == 2)
                    {
                        WinMessage wm = new WinMessage(KNT_Game.me.getName());
                        wm.Show();
                    }
                    currentMarkerID = KNT_Game.createMarker(topleft, attacker, spriteB);
                }
            }

            if (dResult == DialogResult.OK && resolved == false)
            {
                resolveCombat(this.hex);
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

        private bool doesPlayerHaveStack(int i)
        {
            if (stacks[i] != null)
                return true;
            else
                return false;
        }

        private Tile hex;
        private int hexNumber;
        private Texture2D backside;
        private Texture2D[] fortTexture;
        private MarkerButton marker;
        private SpriteBatch spriteB;
        private Dictionary<int, StackButton> stacks;
        private int currentMarkerID = -1;
    }
}
