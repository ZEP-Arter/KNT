using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace KNT_Service
{
    [DataContract]
    public class Game
    {
        public Game()
        {
            GameLogic.GameBoard.Create();

            _players = new List<Player>(4);

            foreach (GameLogic.Player p in GameLogic.GameBoard.Game.getPlayers())
            {
                _players.Add(new Player(p));
            }

            _currentPhase = new Phase(GameLogic.GameBoard.Game.getCurrentPhaseObject());
        }

        public List<Player> getPlayers()
        {
            return _players;
        }

        public GameLogic.GameBoard getGame()
        {
            return GameLogic.GameBoard.Game;
        }

        [DataMember]
        List<Player> _players;

        [DataMember]
        Phase _currentPhase;
    }
}