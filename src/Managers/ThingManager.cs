using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameLogic.Things;
using System.Threading;

namespace GameLogic.Managers
{
    public class ThingManager
    {

        //TODO: Might have to do a return bank and return cup for sake of mt-ing

        public Dictionary<string, List<Thing>> getBank()
        {
            return bank;
        }

        public void setBank(Dictionary<string, List<Thing>> b)
        {
            tSemaphore.WaitOne();

            bank = b;

            tSemaphore.Release();
        }

        public List<Thing> getCup()
        {
            return cup;
        }

        public void setCup(List<Thing> c)
        {
            tSemaphore.WaitOne();

            cup = c;

            tSemaphore.Release();
        }

        public Thing getRandomThingFromCup()
        {
            tSemaphore.WaitOne();

            if (cup.Count == 0)
            {
                tSemaphore.Release();
                return null;
            }

            Random r = new Random();

            Thing retVal = cup[r.Next(cup.Count)];

            removeFromCup(retVal);

            tSemaphore.Release();

            return retVal;
        }

        public Thing getThingFromBank(string type)
        {
            tSemaphore.WaitOne();

            List<Thing> typeList = bank[type];

            if (typeList.Count == 0)
            {
                tSemaphore.Release();
                return null;
            }

            Thing t = typeList[0];

            removeFromBank(type, t);

            tSemaphore.Release();

            return t;
        }

        private void removeFromBank(string type, Thing t)
        {
            bank[type].Remove(t);
        }

        private void removeFromCup(Thing t)
        {
            cup.Remove(t);
        }

        private ThingManager()
        {
            cup = new List<Thing>();
            bank = new Dictionary<string, List<Thing>>();
        }

        private List<Thing> cup;

        private Dictionary<string, List<Thing>> bank;

        private static Semaphore tSemaphore = new Semaphore(1, 1);

        private static ThingManager tManager;

        public static ThingManager TManager
        {
            get
            {
                tSemaphore.WaitOne();

                if (tManager == null)
                    tManager = new ThingManager();

                tSemaphore.Release();

                return tManager;
            }
        }
    }
}
