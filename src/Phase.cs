using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic
{
    public abstract class Phase
    {
        public Phase(string n)
        {
            name = n;

            currentState = State.END;
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
            if (currentState == State.END)
                return true;
            else if (currentState == State.BEGIN)
                return false;

            changeState();

            return true;
        }

        protected bool beginPhase()
        {
            if( currentState == State.BEGIN )
                return true;
            else if (currentState == State.IN_PROGRESS)
                return false;

            changeState();

            return true;
        }

        string name;
        protected State currentState;

        protected enum State
        {
            BEGIN,
            IN_PROGRESS,
            END
        }
    }
}
