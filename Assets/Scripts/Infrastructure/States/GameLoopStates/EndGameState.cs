using Infrastructure.Services;
using Teams;
using UI;
using UnityEngine;
using Zenject;

namespace Infrastructure.States.GameLoopStates
{
    public class EndGameState : IState
    {
        private readonly TeamsContainer teamsContainer;
        private readonly EndGamePanel endGamePanel;
        private readonly FightTimer fightTimer;


        [Inject]
        public EndGameState(TeamsContainer teamsContainer,EndGamePanel endGamePanel, FightTimer fightTimer)
        {
            this.teamsContainer = teamsContainer;
            this.endGamePanel = endGamePanel;
            this.fightTimer = fightTimer;
        }
        public void Enter()
        {
           DisableFighters();
           fightTimer.enabled = false;
           endGamePanel.Show();
        }

        public void Exit() => endGamePanel.Hide();

        private void DisableFighters()
        {
            for (int i = 0; i < teamsContainer.allActiveTeams.Count; i++)
            {
                for (int j = 0; j < teamsContainer.allActiveTeams[i].myFighters.Count; j++)
                {
                    teamsContainer.allActiveTeams[i].myFighters[j].Disable();
                }
            }
        }
    }
}