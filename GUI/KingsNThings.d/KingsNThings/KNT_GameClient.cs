using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KNT_Client;
using KNT_Client.KNT_ServiceReference;

namespace KingsNThings
{
    public class KNT_GameClient : KNT_Game, Client
    {
        public KNT_GameClient()
            : base()
        {
            open();
        }

        public void open()
        {
            client = new KNTNetClient();
            me = client.addPlayer("Eric");
            currentPhase = client.getCurrentPhase();
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

        public Phase getCurrentPhase()
        {
            return currentPhase;
        }

        public override void emptyHand()
        {
            buttonInHand = null;
            me.holdingMarker = false;
        }

        public override Button getButtonInHand()
        {
            return buttonInHand;
        }

        public override void setButtonInHand(Button b)
        {
            buttonInHand = b;
            me.holdingMarker = true;
        }

        public override StackButton createStack(GameLogic.Tile hex, GameLogic.Thing t, Microsoft.Xna.Framework.Graphics.SpriteBatch s)
        {
            //StackButton stackB = new StackButton(stackTexture, me, s, t, hex, 30, 30, 0, 0);
            //StackButtons.Add(stackB);
            return null;
        }

        KNTNetClient client;
        public static Player me;
        public static Button buttonInHand;
        Phase currentPhase;


        GameLogic.Phase Client.getCurrentPhase()
        {
            throw new NotImplementedException();
        }
    }
}
