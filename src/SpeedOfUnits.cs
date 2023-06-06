using UnityEngine;
using System.Collections.Generic;

namespace CastleStory_SpeedOfUnits
{
    class SpeedOfUnits
    {
        static private SpeedOfUnits _instance;
        public static SpeedOfUnits Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SpeedOfUnits();
                }

                return _instance;
            }
        }

        private SpeedOfUnits() { }

        private Config.Config config;

        public void Start(Config.Config config)
        {
            this.config = config;
            HandleConfig();
        }

        private void HandleConfig()
        {
            var test = GameObject.Find("PersitantGOs").transform.Find("Factory/Test").transform;

            foreach(KeyValuePair<Config.UnitType, Config.SpeedTable> entry in config.entries){
                var locomotion = test.Find(entry.Key.ToString()).transform.GetComponent<Brix.Game.AI.Locomotion4>();
                locomotion.WalkSpeedMperS = entry.Value.walk;
                locomotion.RunSpeedMperS = entry.Value.run;
            }
        }
    }
}
