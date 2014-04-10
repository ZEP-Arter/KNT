﻿using GameLogic.Phases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;

namespace GameLogic.Managers
{
    public class PhaseManager
    {
        public Phase play()
        {
            phSemaphore.WaitOne();

            Phase returnState = (currentPhase.getCurrentState() != Phase.State.END) ? currentPhase : getNextPhase();

            phSemaphore.Release();

            return returnState;
        }

        public Phase getCurrentPhase()
        {
            return currentPhase;
        }

        private PhaseManager()
        {
            phases = new List<Phase>(6);

            initGamePhases();

            currentPhase = phases[0];
        }

        private Phase getNextPhase()
        {
            phSemaphore.WaitOne();

            if (phases.IndexOf(currentPhase) != phases.Capacity - 1)
                currentPhase = phases[phases.IndexOf(currentPhase) + 1];
            else
                currentPhase = phases[1];

            phSemaphore.Release();

            return currentPhase;
        }

        private void initGamePhases()
        {
            phases.Add(new SetupPhase());
            phases.Add(new GoldCollectionPhase());
            phases.Add(new RecruitThingsPhase());
            phases.Add(new MovementPhase());
            phases.Add(new CombatPhase());
            phases.Add(new ConstructionPhase());
        }

        private List<Phase> phases;

        private Phase currentPhase;

        private static Semaphore phSemaphore = new Semaphore(1, 1);

        private static PhaseManager phManager;

        public static PhaseManager PhManager
        {
            get
            {
                phSemaphore.WaitOne();

                if (phManager == null)
                    phManager = new PhaseManager();

                phSemaphore.Release();

                return phManager;
            }
        }
    }
}
