using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace GameLogic
{
    [DataContract]
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
            foreach (Player p in _players)
                p.startPhase();

            currentState = State.IN_PROGRESS;

            return true;
        }

        protected void changePlayer()
        {
            if (_players.IndexOf(currentPlayer) != _players.Capacity - 1)
                currentPlayer = _players[_players.IndexOf(currentPlayer) + 1];
            else
                currentPlayer = _players[0];
        }

        protected bool allDone()
        {
            foreach (Player p in _players)
            {
                if (!p.getInPhase())
                    return false;
            }

            return true;
        }

        public State getCurrentState()
        {
            return currentState;
        }

        public string getName()
        {
            return name;
        }

        public abstract void playPhase(List<Player> players);
        public abstract Player getCurrentPlayer();


        string name;
        protected State currentState;
        volatile protected List<Player> _players;
        protected Player currentPlayer;

        public enum State
        {
            BEGIN,
            IN_PROGRESS,
            END
        }
    }
}
