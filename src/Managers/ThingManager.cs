using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;

namespace GameLogic.Managers
{
    [DataContract(IsReference = false)]
    public class ThingManager
    {

        //TODO: Might have to do a return bank and return cup for sake of mt-ing

        public Dictionary<string, List<Thing>> getBank()
        {
            return bank;
        }

        public List<Thing> getCup()
        {
            return cup;
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

        [DataMember]
        private List<Thing> cup;

        private Dictionary<string, List<Thing>> bank;

        [DataMember]
        private static Semaphore tSemaphore = new Semaphore(1, 1);

        [DataMember]
        private static ThingManager tManager;

        [DataMember]
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
