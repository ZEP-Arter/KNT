using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KNT_Client;
using KNT_Client.Networkable;
using Microsoft.Xna.Framework.GamerServices;

namespace KingsNThings
{
    public class KNT_GameClient : KNT_Game, Client
    {
        public KNT_GameClient()
            : base()
        {
            open();
            joinGame();
        }

        public void open()
        {
            client = new KNT_Client.KNT_ServiceReference.KNTNetClient();
            GameController.CreateGame(client.getPlayers());
            _me = GameController.Game.getPlayer(client.connect("Eric"));
        }

        public void joinGame()
        {
            //List<string> MBOPTIONS = new List<string>();
            //MBOPTIONS.Add("OK");

            //string msg = "Please enter your name. \n Click OK to continue. . .";

            //base.Initialize();

            //Guide.BeginShowMessageBox(
            //    "Enter Name", msg, MBOPTIONS, 0,
            //    MessageBoxIcon.Alert, null, null);
        }

        public void update()
        {

        }

        public void close()
        {
            client.Close();
        }

        protected override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            base.Draw(gameTime);
        }

        public override void emptyHand()
        {
            buttonInHand = null;
            //_me.setHoldingMarker(false);
        }

        public override Button getButtonInHand()
        {
            return buttonInHand;
        }

        public override void setButtonInHand(Button b)
        {
            buttonInHand = b;
            //_me.setHoldingMarker(true);
        }

        public override StackButton createStack(Tile hex, Thing t, Microsoft.Xna.Framework.Graphics.SpriteBatch s)
        {
            //StackButton stackB = new StackButton(stackTexture, me, s, t, hex, 30, 30, 0, 0);
            //StackButtons.Add(stackB);
            return null;
        }

        KNT_Client.KNT_ServiceReference.KNTNetClient client;
        public static Player _me;
        public static Button buttonInHand;
    }
}
