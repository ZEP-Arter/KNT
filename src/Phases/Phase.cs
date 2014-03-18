using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KNT_Client.Networkable;

namespace GameLogic.Phases
{
    public abstract class Phase
    {
        public Phase(string n)
        {
            name = n;

            currentState = State.BEGIN;
        }

        protected void changeState()
        {
            switch (currentState)
            {
                case State.BEGIN :
                    currentState = State.IN_PROGRESS;
                    break;

                case State.END :
                    currentState = State.BEGIN;
                    break;

                case State.IN_PROGRESS :
                    currentState = State.END;
                    break;
            }
        }

        protected bool endPhase()
        {
            /*if (currentState == State.END)
                return true;
            else if (currentState == State.BEGIN)
                return false;*/

            //changeState();
            currentState = State.END;

            return true;
        }

        protected bool beginPhase()
        {
            _player.startPhase();

            currentState = State.IN_PROGRESS;

            return true;
        }

        //protected void changePlayer()
        //{
        //    if (_players.IndexOf(currentPlayer) != _players.Capacity - 1)
        //        currentPlayer = _players[_players.IndexOf(currentPlayer) + 1];
        //    else
        //        currentPlayer = _players[0];
        //}

        //protected bool allDone()
        //{
        //    foreach (KNT_Client.Networkable.Player p in _players)
        //    {
        //        if (!p.isInPhase())
        //            return false;
        //    }

        //    return true;
        //}

        public State getCurrentState()
        {
            return currentState;
        }

        public string getName()
        {
            return name;
        }

        public KNT_Client.Networkable.Player getCurrentPlayer()
        { return _player; }

        public abstract void playPhase(KNT_Client.Networkable.Player player);

        string name;

        protected State currentState;

        protected KNT_Client.Networkable.Player _player;

        public enum State
        {
            BEGIN,
            IN_PROGRESS,
            END
        }
    }
}
