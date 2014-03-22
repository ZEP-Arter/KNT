using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GameLogic;
using GameLogic.Managers;

namespace KNT_Service
{
    public class GameController
    {
        private GameController()
        {
            _players = new List<Wrapper.Player>(4);

            foreach (GameLogic.Player p in GameLogic.Managers.GameBoard.Game.getPlayers())
                _players.Add(new Wrapper.Player(p));

            _board = new Wrapper.Board(GameLogic.Managers.GameBoard.Game.getMap());

            _cup = new List<Wrapper.Thing>();

            foreach (GameLogic.Things.Thing t in ThingManager.TManager.getCup())
                _cup.Add(new Wrapper.Thing(t));

            _bank = new Dictionary<string, List<Wrapper.Thing>>();

            Dictionary<string, List<GameLogic.Things.Thing>> tempBank = ThingManager.TManager.getBank();

            foreach (String type in tempBank.Keys)
            {
                if (!_bank.ContainsKey(type))
                    _bank.Add(type, new List<Wrapper.Thing>());

                foreach (GameLogic.Things.Thing t in tempBank[type])
                    _bank[type].Add(new Wrapper.Thing(t));
            }

        }

        public bool havePlayer(GameLogic.Player p)
        {
            return GameBoard.Game.getPlayers().Contains(p);
        }

        public Wrapper.Player getNetPlayer(GameLogic.Player p)
        {
            foreach (Wrapper.Player player in _players)
            {
                if (player.getPlayerNumber() == p.getPlayerNumber())
                    return player;
            }

            if (_players.Count + 1 < _players.Capacity)
                _players.Add(new Wrapper.Player(p));
            else
                return null;

            return getNetPlayer(p);
        }

        public Wrapper.Player addNewPlayer(GameLogic.Player p)
        {
            if (_players.Count != _players.Capacity)
            {
                Wrapper.Player player = new Wrapper.Player(p);
                _players.Add(player);
                return player;
            }

            return null;
        }

        public Wrapper.Player changePlayerName(Wrapper.Player player, string name)
        {
            player.setName(name);

            player.Sync();

            if (!_players.Contains(player) && _players.Count != _players.Capacity)
                _players.Add(player);
                
            return player;

        }

        public Wrapper.Player newConnection(string playerName)
        {
            GameLogic.Player player = null;

            if ((player = PlayerManager.PManager.changePlayerName(playerName)) != null)
            {
                if (havePlayer(player))
                {
                    return changePlayerName(getNetPlayer(player), playerName);
                }
                else if (_players.Count != _players.Capacity)
                {
                    return addNewPlayer(player);
                }
            }

            return null;
        }

        public void Sync()
        {
            foreach (Wrapper.Player p in _players)
                p.Sync();

            foreach (Wrapper.Thing t in _cup)
                t.Sync();

            foreach (String type in _bank.Keys)
                foreach (Wrapper.Thing t in _bank[type])
                    t.Sync();

            _board.Sync();
        }

        public Dictionary<string, List<Wrapper.Thing>> getBank()
        {
            return _bank;
        }

        public List<Wrapper.Player> getPlayers()
        {
            return _players;
        }

        public Wrapper.Board getMap()
        {
            return _board;
        }

        public List<Wrapper.Thing> getCup()
        {
            return _cup;
        }

        private List<Wrapper.Player> _players;

        private Wrapper.Board _board;

        private List<Wrapper.Thing> _cup;

        private Dictionary<string, List<Wrapper.Thing>> _bank;

        public GameBoard Controller;

        private static GameController gc;

        public static GameController Game
        {
            get
            {
                if (gc == null)
                    gc = new GameController();

                return gc;
            }
        }
    }
}