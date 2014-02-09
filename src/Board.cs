using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic
{
    class Board
    {
        //ctor 

        public Board() 
        {
            tiles = new List<Tile>();
        }

        //public
        
        public void initBoard()
        {
            tiles.add(new Tile(1 , {2 , 3 , 4 , 5 , 6 , 7 }, ""));
            tiles.add(new Tile(2 , {9 , 10, 3 , 1 , 7 , 8 }, ""));
            tiles.add(new Tile(3 , {10, 11, 12, 4 , 1 , 2 }, ""));
            tiles.add(new Tile(4 , {3 , 12, 13, 14, 5 , 1 }, ""));
            tiles.add(new Tile(5 , {1 , 4 , 14, 15, 16, 6 }, ""));
            tiles.add(new Tile(6 , {7 , 1 , 5 , 16, 17, 18}, ""));
            tiles.add(new Tile(7 , {8 , 2 , 1 , 6 , 18, 19}, ""));
            tiles.add(new Tile(8 , {21, 9 , 2 , 7 , 19, 20}, ""));
            tiles.add(new Tile(9 , {22, 23, 10, 2 , 8 , 21}, ""));
            tiles.add(new Tile(10, {23, 24, 11, 3 , 2 , 9 }, ""));
            tiles.add(new Tile(11, {24, 25, 26, 12, 3 , 10}, ""));
            tiles.add(new Tile(12, {11, 26, 27, 13, 4 , 3 }, ""));
            tiles.add(new Tile(13, {12, 27, 28, 29, 14, 4 }, ""));
            tiles.add(new Tile(14, {4 , 13, 29, 30, 15, 5 }, ""));
            tiles.add(new Tile(15, {5 , 14, 30, 31, 32, 16}, ""));
            tiles.add(new Tile(16, {6 , 5 , 15, 32, 33, 17}, ""));
            tiles.add(new Tile(17, {18, 6 , 16, 33, 34, 35}, ""));
            tiles.add(new Tile(18, {19, 7 , 6 , 17, 35, 36}, ""));
            tiles.add(new Tile(19, {20, 8 , 7 , 18, 36, 37}, ""));
            tiles.add(new Tile(20, {0 , 21, 8 , 19, 37, 0 }, ""));
            tiles.add(new Tile(21, {0 , 22, 9 , 8 , 20, 0 }, ""));
            tiles.add(new Tile(22, {0 , 0 , 23, 9 , 21, 0 }, ""));
            tiles.add(new Tile(23, {0 , 0 , 24, 10, 9 , 22}, ""));
            tiles.add(new Tile(24, {0 , 0 , 25, 11, 10, 23}, ""));
            tiles.add(new Tile(25, {0 , 0 , 0 , 26, 11, 24}, ""));
            tiles.add(new Tile(26, {25, 0 , 0 , 27, 12, 11}, ""));
            tiles.add(new Tile(27, {26, 0 , 0 , 28, 13, 12}, ""));
            tiles.add(new Tile(28, {27, 0 , 0 , 0 , 29, 13}, ""));
            tiles.add(new Tile(29, {13, 28, 0 , 0 , 30, 14}, ""));
            tiles.add(new Tile(30, {14, 29, 0 , 0 , 31, 15}, ""));
            tiles.add(new Tile(31, {15, 30, 0 , 0 , 0 , 32}, ""));
            tiles.add(new Tile(32, {16, 15, 31, 0 , 0 , 33}, ""));
            tiles.add(new Tile(33, {17, 16, 32, 0 , 0 , 34}, ""));
            tiles.add(new Tile(34, {35, 17, 33, 0 , 0 , 0 }, ""));
            tiles.add(new Tile(35, {36, 18, 17, 34, 0 , 0 }, ""));
            tiles.add(new Tile(36, {37, 19, 18, 35, 0 , 0 }, ""));
            tiles.add(new Tile(37, {0 , 20, 19, 36, 0 , 0 }, ""));
        }

        //private

        //private members

            List<Tile> tiles;
    }
}
