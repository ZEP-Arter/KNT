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

namespace KingsNThings.Buttons
{
    public class DiceRollButton : Button
    {
        public DiceRollButton(Texture2D texture, SpriteBatch sBatch, int width, int height, int x, int y, SpriteFont f) :
            base(texture, sBatch, width, height, x, y)
        {
            needDice = false;
            font = f;
        }

        private bool rollClicked()
        {
            if (location.Contains(new Point(mouse.X, mouse.Y)))
                return true;

            return false;
        }

        public override void Update()
        {

            if (KNT_Game.me != null && KNT_Game.me.getDiceroll() == 0)
                needDice = true;

            base.Update();
        }

        protected override void isClicked()
        {
            if (rollClicked() && needDice)
            {
                KNT_Game.me.setDiceroll(GameLogic.Utils.DiceRoller.Roll.rollDice());
                needDice = false;
            }
        }

        protected override void draw()
        {
            if (location.Contains(new Point(mouse.X, mouse.Y)))
            {
                spriteBatch.Draw(image,
                    location,
                    Color.DimGray);

            }
            else if (!needDice)
            {
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

            if (needDice && KNT_Game.me.getDiceroll() != 0)
            {
                spriteBatch.DrawString(font, String.Format("{0} rolled {1}", KNT_Game.me.getName(), KNT_Game.me.getDiceroll()), new Vector2(420, 100), Color.Black);
                spriteBatch.DrawString(font, String.Format("{0} is playing.", KNT_Game.me.getName()), new Vector2(420, 120), Color.Black);
            }
            else if (needDice)
                spriteBatch.DrawString(font, String.Format("{0} Please Roll.", KNT_Game.me.getName()), new Vector2(420, 100), Color.Blue);
        }

        private bool needDice;
        private SpriteFont font;
    }
}
