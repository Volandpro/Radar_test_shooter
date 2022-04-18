using Fighters;
using Teams;
using Zenject;

namespace Infrastructure.Spawners
{
    public class FightersInTeamSpawner : ISpawner
    {
        private readonly TeamsContainer teamsContainer;
        private readonly Fighter.Factory fightersFactory;
        private readonly IPositionChooser positionChooser;
        private const int FightersInTeamCount=3;
        
        [Inject]
        public FightersInTeamSpawner(TeamsContainer teamsContainer,Fighter.Factory fightersFactory,
            IPositionChooser positionChooser)
        {
            this.teamsContainer = teamsContainer;
            this.fightersFactory = fightersFactory;
            this.positionChooser = positionChooser;
        }
        
        public void Spawn()
        {
            for (int i = 0; i < teamsContainer.allActiveTeams.Count; i++)
            {
                for (int j = 0; j < FightersInTeamCount; j++)
                {
                    Fighter newFighter = fightersFactory.Create();
                    newFighter.transform.position = positionChooser.CalculatePosition(i);
                    newFighter.myTeam = teamsContainer.allActiveTeams[i];
                    newFighter.SetRandomConfig();
                    newFighter.Disable();
                    teamsContainer.allActiveTeams[i].AddFighter(newFighter);
                }
            }
        }
    }
}