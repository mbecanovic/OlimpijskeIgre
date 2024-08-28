using System.Collections.Generic;

namespace OlimpijskeIgre
{
    public class TeamInfo
    {
        public string Team { get; set; }
        public string ISOCode { get; set; }
        public int FIBARanking { get; set; }

        // Dodajte statistiku tima
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Points { get; set; }
        public int ScoredPoints { get; set; }
        public int ConcededPoints { get; set; }
        public int PointDifference => ScoredPoints - ConcededPoints;
    }

    public class GroupStats
    {
        public string GroupName { get; set; }
        public List<TeamInfo> Teams { get; set; }
    }

    public class Tournament
    {
        public Dictionary<string, List<TeamInfo>> Groups { get; set; }
    }
}
