namespace GameLogic
{
    //THERE ARE 48 TILES
    //NUMBER OF TILES ON A 4 PLAYER BOARD IS 37
    public class Tile
    {
        public Tile(int n, int[6] a, string h)
        {
            hexNumber   = n;
            nHex        = a[0];
            neHex       = a[1];
            seHex       = a[2];
            sHex        = a[3];
            swHex       = a[4];
            neHex       = a[5];
            hexType     = h;
        }
        //Hex Number
        int hexNumber;
        
        //Number for connected hexes
        int nHex;
        int neHex;
        int seHex;
        int sHex;
        int swHex;
        int neHex;
        //Type of Hex: Jungle, Frozen Waste, Desert, Plains, Forest, Sea, Swamp, Mountain
        private string hexType;
        //Shows whether the Tile is face up or face down
        private bool faceUp;
        //Shows whether the Tile can be selected as a starting point
        private bool startPossible;

		private Player playerControl;

    }
}
