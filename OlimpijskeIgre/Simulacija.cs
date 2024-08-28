using System;
using System.Collections.Generic;

namespace OlimpijskeIgre
{
    public static class Simulation
    {
        private static Random random = new Random();

        public static void SimulateMatchesForRound(List<TeamInfo> teams, int round)
        {
            switch (round)
            {
                case 1:
                    SimulateRound1(teams);
                    break;
                case 2:
                    SimulateRound2(teams);
                    break;
                case 3:
                    SimulateRound3(teams);
                    break;
                default:
                    Console.WriteLine("Invalid round number.");
                    break;
            }
        }

        private static void SimulateRound1(List<TeamInfo> teams)
        {
            for (int i = 0; i < teams.Count; i += 4)
            {
                if (i + 1 < teams.Count)
                {
                    SimulateMatch(teams[i], teams[i + 1]);
                }

                if (i + 2 < teams.Count && i + 3 < teams.Count)
                {
                    SimulateMatch(teams[i + 2], teams[i + 3]);
                }
            }
        }

        private static void SimulateRound2(List<TeamInfo> teams)
        {
            for (int i = 0; i < teams.Count; i += 4)
            {
                if (i + 1 < teams.Count)
                {
                    SimulateMatch(teams[i], teams[i + 2]);
                }

                if (i + 2 < teams.Count && i + 3 < teams.Count)
                {
                    SimulateMatch(teams[i + 1], teams[i + 3]);
                }
            }
        }

        private static void SimulateRound3(List<TeamInfo> teams)
        {
            for (int i = 0; i < teams.Count; i += 4)
            {
                if (i + 1 < teams.Count)
                {
                    SimulateMatch(teams[i + 1], teams[i + 2]);
                }

                if (i + 2 < teams.Count && i + 3 < teams.Count)
                {
                    SimulateMatch(teams[i], teams[i + 3]);
                }
            }
        }

        private static void SimulateMatch(TeamInfo team1, TeamInfo team2)
        {
            int rankingDifference = Math.Abs(team1.FIBARanking - team2.FIBARanking);
            double winProbability = 1.0 / (1.0 + Math.Exp(rankingDifference / 10.0));

            bool team1Wins = random.NextDouble() < winProbability;

            int team1Score = random.Next(70, 120);
            int team2Score = random.Next(70, 120);

            if (team1Wins)
            {
                team2Score = (int)(team1Score * (1 - winProbability));
            }
            else
            {
                team1Score = (int)(team2Score * winProbability);
            }

            team1Score = Math.Max(0, team1Score);
            team2Score = Math.Max(0, team2Score);

            
            if (team1Wins)
            {
                team1.Wins++;
                team2.Losses++;
                team1.Points += 2; //for win
            }
            else
            {
                team2.Wins++;
                team1.Losses++;
                team2.Points += 2; 
            }

            team1.ScoredPoints += team1Score;
            team1.ConcededPoints += team2Score;
            team2.ScoredPoints += team2Score;
            team2.ConcededPoints += team1Score;

            Console.WriteLine($"         {team1.Team} - {team2.Team} ({team1Score}:{team2Score})");
        }
    }
}
