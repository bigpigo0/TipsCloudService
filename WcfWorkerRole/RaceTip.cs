using System.Collections.Generic;

namespace WcfWorkerRole
{
    public class RaceTip
    {
        public string ImagePath { get; set; }

        public IDictionary<string, string> SpeedIndex { get; set; }
        public IDictionary<string, string> FitnessRating { get; set; }
        public IDictionary<string, string> NewsPaperTip { get; set; }
        public IDictionary<string, string> JockyTip { get; set; }
    }
}