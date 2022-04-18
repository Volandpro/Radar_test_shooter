using Infrastructure.Services;
using Teams;
using Zenject;

namespace Infrastructure.States.GameLoopStates
{
    public class PlayingState : IState
    {
        private readonly TeamsContainer teamsContainer;
        private readonly FightTimer fightTimer;

        [Inject]
        public PlayingState(TeamsContainer teamsContainer, FightTimer fightTimer)
        {
            this.teamsContainer = teamsContainer;
            this.fightTimer = fightTimer;
        }
        public void Enter()
        {
            fightTimer.ResetTimer();
            fightTimer.enabled = true;
            EnableFighters();
        }
        public void Exit()
        {
            
        }
        private void EnableFighters()
        {
            for (int i = 0; i < teamsContainer.allActiveTeams.Count; i++)
            {
                for (int j = 0; j < teamsContainer.allActiveTeams[i].myFighters.Count; j++)
                {
                    teamsContainer.allActiveTeams[i].myFighters[j].Enable();
                }
            }
        }
    }
}