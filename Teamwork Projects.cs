

namespace _5._Teamwork_Projects
{
    using System;
    using System.Numerics;
    using System.Collections.Generic;
    using System.Linq;
    class Program
    {
        static void Main(string[] args)
        {

            int countOfTeams = int.Parse(Console.ReadLine());

            List<CreatedTeams> createdTeams = new List<CreatedTeams>();

            for (int i = 0; i < countOfTeams; i++)
            {

                string[] inputParameters = Console.ReadLine()
                    .Split("-", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string creator = inputParameters[0];
                string teamName = inputParameters[1];
                

                if (IsTeamExists(createdTeams, teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }
                else if (IsCreatorExist(createdTeams, creator))
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                }
                else
                {
                    CreatedTeams team = new CreatedTeams(teamName, creator);
                    createdTeams.Add(team);
                    Console.WriteLine($"Team {teamName} has been created by {creator}!");
                }

            }

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "end of assignment")
            {
                string[] inputParameters = command
                    .Split("->", StringSplitOptions.RemoveEmptyEntries);

                string joiner = inputParameters[0];
                string teamName = inputParameters[1];

                

                if (!IsTeamExists(createdTeams, teamName))
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                }
                else if (IsJoinerExist(createdTeams, joiner))
                {
                    Console.WriteLine($"Member {joiner} cannot join team {teamName}!");
                }
                else
                {
                    CreatedTeams teamToJoin = createdTeams.First(t => t.TeamName == teamName);
                    teamToJoin.AddMembers(joiner);
                }
            }

            // за да може обектите да са видими се прави втори лист с филтрация
            List<CreatedTeams> teamsWithMembers = createdTeams
                .Where(t => t.Members.Count() > 0)
                .OrderByDescending(t => t.Members.Count())
                .ThenBy(t => t.TeamName)
                .ToList();// винаги слагаме ToList, ако има метод, който връща друго освен масив

            foreach (var team in teamsWithMembers)
            {
                Console.WriteLine(team.TeamName);
                Console.WriteLine($"- {team.Creator}");
                foreach (var memberName in team.Members.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {memberName}");
                }
            }

            Console.WriteLine("Teams to disband:");

            List<CreatedTeams> teamsToDisband = createdTeams
                .Where(t => t.Members.Count() == 0)
                .OrderBy(t => t.TeamName)
                .ToList();

            foreach (CreatedTeams disbandTeam in teamsToDisband)
            {
                Console.WriteLine($"{disbandTeam.TeamName}");
            }
        }

        public static bool IsJoinerExist(List<CreatedTeams> createdTeams, string joiner)
        {

            return createdTeams.Any(t => t.Members.Contains(joiner)) || createdTeams.Any(t => t.Creator == joiner);

        }

        public static bool IsTeamExists(List<CreatedTeams> createdTeams, string teamName)
        {

                return createdTeams.Any(t => t.TeamName == teamName);
        }

        public static bool IsCreatorExist(List<CreatedTeams> createdTeams, string creator)
        {
                return createdTeams.Any(t => t.Creator == creator);
        }

    }

    public class CreatedTeams
    {
        private readonly List<string> members;
        public CreatedTeams(string teamNameCreated, string creator)
        {
            TeamName = teamNameCreated;
            Creator = creator;
            members = new List<string>();// don't forget to initialize the collection
        }
        public string TeamName { get; private set; }
        public string Creator { get; private set; }
        
        //readonly property
        public List<string> Members
            => members;

        public void AddMembers(string joiner)
        {
            members.Add(joiner);
        }
    }
}
