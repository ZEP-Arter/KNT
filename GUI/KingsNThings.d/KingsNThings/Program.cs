using System;

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
            //using (KNT_Game game = new KNT_Game())
            //{
            //    game.Run();
            //}
        }
    }
#endif
}

