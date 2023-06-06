namespace CastleStory_SpeedOfUnits.Config
{
    public struct SpeedTable
    {
        private float _walk;
        public float walk
        {
            get
            {
                return _walk;
            }
        }

        private float _run;
        public float run
        {
            get
            {
                return _run;
            }
        }

        public SpeedTable(double walk, double run)
        {
            this._walk = (float)walk;
            this._run = (float)run;
        }
    }
}