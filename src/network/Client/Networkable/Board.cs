using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KNT_Client.Networkable
{
    public class Board
    {
        public Board(KNT_ServiceReference.Board b)
        { that = b; }

        public List<Tile> getHexList()
        {
            List<Tile> cpy = new List<Tile>();

            foreach (KNT_ServiceReference.Tile t in that._tiles)
                cpy.Add(new Tile(t));

            return cpy;
        }

        public KNT_ServiceReference.Board getBase()
        { return that; }

        KNT_ServiceReference.Board that;
    }
}
