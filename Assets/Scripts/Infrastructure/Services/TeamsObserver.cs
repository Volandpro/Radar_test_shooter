using Infrastructure.ActualProviders;
using Infrastructure.States.GameLoopStates;
using Teams;
using Zenject;

namespace Infrastructure.Services
{
    public class TeamsObserver
    {
        private TeamsContainer teamsContainer;
        private GameLoopStateMachine stateMachine;
        
        [Inject]
        public void Construct(TeamsContainer teamsContainer, ActualGameLoopStateMachineProvider stateMachineProvider)
        {
            this.teamsContainer = teamsContainer;
            stateMachineProvider.OnStateMachineSet += SetGameLoopStateMachine;
        }
        private void SetGameLoopStateMachine(GameLoopStateMachine gameLoopStateMachine) => 
            stateMachine = gameLoopStateMachine;

        public void SubscribeToTeams()
        {
            for (int i = 0; i < teamsContainer.allActiveTeams.Count; i++)
            {
                teamsContainer.allActiveTeams[i].OnRemoveFighter += CheckForEndGame;
            }
        }

        private void CheckForEndGame(Team team)
        {
            if(team.myFighters.Count==0)
                stateMachine.Enter<EndGameState>();
        }
    }
}