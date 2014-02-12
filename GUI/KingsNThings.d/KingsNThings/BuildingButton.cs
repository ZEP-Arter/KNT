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
    public class BuildingButton: Button
    {

        public BuildingButton(Texture2D texture, Player p, SpriteBatch sBatch, int width, int height, int x, int y) :
            base(texture, sBatch, width, height, x, y)
        {
            buildingSelected = false;
            isSet = false;
            owner = p;

            Random r = new Random();

            buttonID = r.Next(System.DateTime.Now.Millisecond * 1000, System.DateTime.Now.Millisecond * 10000);
            System.Threading.Thread.Sleep(1000);

            while (p.containsMarkerID(buttonID))
            {
                buttonID = r.Next(System.DateTime.Now.Millisecond);
                System.Threading.Thread.Sleep(1000);
            }

            owner.addMarkerID(buttonID);


        }
        protected override void isClicked()
        {
            if (isBuildingSelected())
            {
                if (!buildingSelected)
                {
                    KNT_Game.me.setHandsFull();
                    buildingSelected = true;
                }
            }
        }

        private bool isBuildingSelected()
        {
            if (location.Contains(new Point(mouse.X, mouse.Y))) //MARKER TILES
            {
                if (KNT_Game.me.containsMarkerID(buttonID) &&
                    !isSet &&
                    KNT_Game.me.getDiceRoll() != 0 &&
                    !KNT_Game.me.handsFull())
                {
                    return true;
                }
            }

            return false;
        }


        public override void Update()
        {
            if (buildingSelected)
            {
                this.location.X = mouse.X;
                this.location.Y = mouse.Y;
            }

            base.Update();
        }

        public int getButtonID()
        {
            return buttonID;
        }

        protected override void draw()
        {
            if (location.Contains(new Point(mouse.X, mouse.Y)))
            {
                spriteBatch.Draw(image,
                    location,
                    Color.Silver);

            }
            else
            {
                spriteBatch.Draw(image,
                    location,
                    Color.White);
            }
        }
        public bool getBuildingSelected() { return buildingSelected; }
        public void setBuildingSelected(bool b) { buildingSelected = b; }

        public bool getIsSet() { return isSet; }
        public void setIsSet(bool b) { isSet = b; }

        private Player owner;
        private bool isSet = false;
        private bool buildingSelected = false;
        private int buttonID;
    }
}
