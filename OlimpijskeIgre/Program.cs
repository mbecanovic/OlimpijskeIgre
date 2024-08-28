using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OlimpijskeIgre
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string jsonPath = "C:\\Users\\burag\\OneDrive\\Desktop\\OI\\OlimpijskeIgre\\OlimpijskeIgre\\data\\groups.json";
            string json = File.ReadAllText(jsonPath);

            var tournament = JsonConvert.DeserializeObject<Tournament>(json);

            if (tournament?.Groups == null)
            {
                Console.WriteLine("Deserialization failed or JSON structure is incorrect.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Grupna faza - I kolo:");
            foreach (var groupPair in tournament.Groups)
            {
                var groupName = groupPair.Key;
                var teams = groupPair.Value;

                Console.WriteLine($"    Grupa {groupName}:");
                Simulation.SimulateMatchesForRound(teams, 1);
            }

            Console.WriteLine("\nKlikni enter za nastavak\n");
            Console.ReadKey();

          
            Console.WriteLine("Grupna faza - II kolo:");
            foreach (var groupPair in tournament.Groups)
            {
                var groupName = groupPair.Key;
                var teams = groupPair.Value;

                Console.WriteLine($"    Grupa {groupName}:");
                Simulation.SimulateMatchesForRound(teams, 2);
            }

            Console.WriteLine("\nKlikni enter za nastavak\n");
            Console.ReadKey();

            
            Console.WriteLine("Grupna faza - III kolo:");
            foreach (var groupPair in tournament.Groups)
            {
                var groupName = groupPair.Key;
                var teams = groupPair.Value;

                Console.WriteLine($"    Grupa {groupName}:");
                Simulation.SimulateMatchesForRound(teams, 3);
            }

            Console.WriteLine("\nKlikni enter za nastavak\n");
            Console.ReadKey();

            
            Console.WriteLine("\nKonačan plasman u grupama:");

            foreach (var groupPair in tournament.Groups)
            {
                var groupName = groupPair.Key;
                var teams = groupPair.Value;

                Console.WriteLine($"    Grupa {groupName}:");

                var sortedTeams = teams.OrderByDescending(t => t.Wins)
                                        .ThenByDescending(t => t.Points)
                                        .ThenByDescending(t => t.PointDifference)
                                        .ThenBy(t => t.ScoredPoints)
                                        .ToList();

                for (int i = 0; i < sortedTeams.Count; i++)
                {
                    var team = sortedTeams[i];
                    Console.WriteLine($"        {i + 1}. {team.Team} {team.Wins} / {team.Losses} / {team.Points} / {team.ScoredPoints} / {team.ConcededPoints} / {team.PointDifference:+#;-#;0}");
                }
            }

            Console.ReadKey();
        }
    }
}
