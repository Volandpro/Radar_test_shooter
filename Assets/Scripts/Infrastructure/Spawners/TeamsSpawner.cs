using Teams;
using Zenject;

namespace Infrastructure.Spawners
{
    public class TeamsSpawner : ISpawner
    {
        private readonly TeamsContainer teamsContainer;
        public const int TeamCount=2;
        
        [Inject]
        public TeamsSpawner(TeamsContainer teamsContainer)
        {
            this.teamsContainer = teamsContainer;
        }
        public void Spawn()
        {
            for (int i = 0; i < TeamCount; i++)
            {
                Team newTeam = new Team(i);
                teamsContainer.Add(newTeam);
            }
        }
    }
}