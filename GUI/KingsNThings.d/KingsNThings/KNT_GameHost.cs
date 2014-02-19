using KNT_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;

namespace KingsNThings
{
    public class KNT_GameHost : KNT_Game, KNT_Host.KNT_Net_Host
    {
        public KNT_GameHost()
            : base()
        {
            CreateGame();
            Poll();
        }

        public void CreateGame()
        {

            baseAddress = new Uri("http://localhost:15608/KNTNet.svc");

            selfHost = new ServiceHost(typeof(KNTNet), baseAddress);
        }

        public void Poll()
        {
            try
            {
                selfHost.AddServiceEndpoint(typeof(IKNTNet), new BasicHttpBinding(), "KNT");

                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                selfHost.Description.Behaviors.Add(smb);

                selfHost.Open();
            }
            catch (CommunicationException ex)
            {
                Console.WriteLine("An Exception ocurred: {0}", ex.Message);
                selfHost.Abort();
            }
        }

        public override StackButton createStack(GameLogic.Tile hex, GameLogic.Thing t, Microsoft.Xna.Framework.Graphics.SpriteBatch s)
        {
            throw new NotImplementedException();
        }

        protected override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            base.Draw(gameTime);
        }

        public override void emptyHand()
        {
            throw new NotImplementedException();
        }

        public override Button getButtonInHand()
        {
            throw new NotImplementedException();
        }

        public override void setButtonInHand(Button b)
        {
            throw new NotImplementedException();
        }

        ServiceHost selfHost;
        Uri baseAddress;
        //Player me;
    }
}
