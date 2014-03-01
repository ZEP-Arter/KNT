using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace KNT_Service
{
    [DataContract]
    public class Board
    {

        GameLogic.Board _board;
        [DataMember]
        public List<GameLogic.Tile> tiles;

        public Board(GameLogic.Board b)
        {
            _board = b;
            
        }

        private void init()
        {
            tiles = _board.getHexList();
        }

        public void setHexList(List<GameLogic.Tile> tileList)
        {
            tiles = tileList;
            _board.setHexList(tiles);
        }
    }
}