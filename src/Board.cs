using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic
{
    public class Board
    {
        //ctor 

        public Board() 
        {
            tiles = new List<Tile>();
        }

        //public
        
        public void initBoard()
        {
            tiles.Add(new Tile(1 , new int[]{2 , 3 , 4 , 5 , 6 , 7 }, "Frozen Waste"));
            tiles.Add(new Tile(2 , new int[]{9 , 10, 3 , 1 , 7 , 8 }, "Forest"));
            tiles.Add(new Tile(3 , new int[]{10, 11, 12, 4 , 1 , 2 }, "Jungle"));
            tiles.Add(new Tile(4 , new int[]{3 , 12, 13, 14, 5 , 1 }, "Plains"));
            tiles.Add(new Tile(5 , new int[]{1 , 4 , 14, 15, 16, 6 }, "Sea"));
            tiles.Add(new Tile(6 , new int[]{7 , 1 , 5 , 16, 17, 18}, "Forest"));
            tiles.Add(new Tile(7 , new int[]{8 , 2 , 1 , 6 , 18, 19}, "Swamp"));
            tiles.Add(new Tile(8 , new int[]{21, 9 , 2 , 7 , 19, 20}, "Plains"));
            tiles.Add(new Tile(9 , new int[]{22, 23, 10, 2 , 8 , 21}, "Frozen Waste"));
            tiles.Add(new Tile(10, new int[]{23, 24, 11, 3 , 2 , 9 }, "Mountain"));
            tiles.Add(new Tile(11, new int[]{24, 25, 26, 12, 3 , 10}, "Frozen Waste"));
            tiles.Add(new Tile(12, new int[]{11, 26, 27, 13, 4 , 3 }, "Swamp"));
            tiles.Add(new Tile(13, new int[]{12, 27, 28, 29, 14, 4 }, "Desert"));
            tiles.Add(new Tile(14, new int[]{4 , 13, 29, 30, 15, 5 }, "Swamp"));
            tiles.Add(new Tile(15, new int[]{5 , 14, 30, 31, 32, 16}, "Forest"));
            tiles.Add(new Tile(16, new int[]{6 , 5 , 15, 32, 33, 17}, "Desert"));
            tiles.Add(new Tile(17, new int[]{18, 6 , 16, 33, 34, 35}, "Plains"));
            tiles.Add(new Tile(18, new int[]{19, 7 , 6 , 17, 35, 36}, "Mountain"));
            tiles.Add(new Tile(19, new int[]{20, 8 , 7 , 18, 36, 37}, "Jungle"));
            tiles.Add(new Tile(20, new int[]{0 , 21, 8 , 19, 37, 0 }, "Swamp", true));
            tiles.Add(new Tile(21, new int[]{0 , 22, 9 , 8 , 20, 0 }, "Mountain"));
            tiles.Add(new Tile(22, new int[]{0 , 0 , 23, 9 , 21, 0 }, "Jungle"));
            tiles.Add(new Tile(23, new int[]{0 , 0 , 24, 10, 9 , 22}, "Swamp"));
            tiles.Add(new Tile(24, new int[]{0 , 0 , 25, 11, 10, 23}, "Desert", true));
            tiles.Add(new Tile(25, new int[]{0 , 0 , 0 , 26, 11, 24}, "Forest"));
            tiles.Add(new Tile(26, new int[]{25, 0 , 0 , 27, 12, 11}, "Desert"));
            tiles.Add(new Tile(27, new int[]{26, 0 , 0 , 28, 13, 12}, "Forest"));
            tiles.Add(new Tile(28, new int[]{27, 0 , 0 , 0 , 29, 13}, "Frozen Waste"));
            tiles.Add(new Tile(29, new int[]{13, 28, 0 , 0 , 30, 14}, "Jungle", true));
            tiles.Add(new Tile(30, new int[]{14, 29, 0 , 0 , 31, 15}, "Mountain"));
            tiles.Add(new Tile(31, new int[]{15, 30, 0 , 0 , 0 , 32}, "Desert"));
            tiles.Add(new Tile(32, new int[]{16, 15, 31, 0 , 0 , 33}, "Plains"));
            tiles.Add(new Tile(33, new int[]{17, 16, 32, 0 , 0 , 34}, "Jungle", true));
            tiles.Add(new Tile(34, new int[]{35, 17, 33, 0 , 0 , 0 }, "Mountain"));
            tiles.Add(new Tile(35, new int[]{36, 18, 17, 34, 0 , 0 }, "Forest"));
            tiles.Add(new Tile(36, new int[]{37, 19, 18, 35, 0 , 0 }, "Frozen Waste"));
            tiles.Add(new Tile(37, new int[]{0 , 20, 19, 36, 0 , 0 }, "Desert"));
        }
        
        public List<Tile> getMap() { return tiles; }

        //private

        //private members

            List<Tile> tiles;
    }
}
