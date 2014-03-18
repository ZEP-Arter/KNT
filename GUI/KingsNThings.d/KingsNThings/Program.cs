using System;
using KingsNThings.GUI;

namespace KingsNThings
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (KNT_GameClient game = new KNT_GameClient())
            {
                game.Run();
            }
        }
    }
#endif
}

