using KNT_Service.Networkable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace KNT_Service.Wrapper
{
    [DataContract]
    public class Board : IBoard
    {
        public Board()
        {
            _tiles = new List<Tile>();

            if (that == null)
                that = new GameLogic.Board();

            Synchronize();
        }

        public Board(GameLogic.Board me)
        {
            that = me;

            _tiles = new List<Tile>();

            foreach (GameLogic.Tile t in that.getHexList())
                _tiles.Add(new Tile(t));

            Synchronize();
        }

        public List<Tile> getHexList()
        { return _tiles; }

        public GameLogic.Board getBase()
        { return that; }

        public void Sync()
        { Synchronize(); }

        private void Synchronize()
        {
            foreach (Tile t in _tiles)
                t.Sync();
        }

        [DataMember]
        private List<Tile> _tiles;

        private GameLogic.Board that;
    }
}