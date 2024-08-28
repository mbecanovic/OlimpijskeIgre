using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
//koristimo ovaj nuget paket da bismo preuzeli json podatke


namespace OlimpijskeIgre
{
    internal class Groups
    {
        public void Stampanje()
        {
            // Path to the JSON file
            string filePath = "C:\\Users\\burag\\OneDrive\\Desktop\\OI\\OlimpijskeIgre\\OlimpijskeIgre\\data\\groups.json";

            // Read the JSON file
            string jsonString = File.ReadAllText(filePath);

            // Deserialize the JSON into a dictionary
            var groupsData = JsonConvert.DeserializeObject<Dictionary<string, List<Dictionary<string, object>>>>(jsonString);

            // Print each group and its teams
            foreach (var group in groupsData)
            {
                Console.WriteLine($"Group {group.Key}:");
                foreach (var team in group.Value)
                {
                    Console.WriteLine($"- Team: {team["Team"]}, ISOCode: {team["ISOCode"]}, FIBARanking: {team["FIBARanking"]}");
                }
                Console.WriteLine();
            }

        }
    }
}
