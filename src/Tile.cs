namespace GameLogic
{
    //THERE ARE 48 TILES
    //NUMBER OF TILES ON A 4 PLAYER BOARD IS 37
    public class Tile
    {
        //Type of Hex: Jungle, Frozen Waste, Desert, Plains, Forest, Sea, Swamp, Mountain
        private string hexType;
        //Shows whether the Tile is face up or face down
        private bool faceUp;
        //Shows whether the Tile can be selected as a starting point
        private bool startPossible;

        private int playerControl;

    }
}
