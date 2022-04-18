using System.Collections.Generic;
using Infrastructure.Services;
using Infrastructure.Spawners;
using Teams;
using UI;
using Zenject;

namespace Infrastructure.States.GameLoopStates
{
    public class LevelCreationState : IState
    {
        private readonly PlayButton playButton;
        private readonly EndGamePanel endGamePanel;
        private readonly TeamsContainer teamsContainer;
        private readonly TeamsObserver teamsObserver;
        private readonly FightTimer fightTimer;
        private List<ISpawner> allSpawners = new List<ISpawner>();
      
        [Inject]
        public LevelCreationState(TeamsSpawner teamsSpawner, FightersInTeamSpawner fightersInTeamSpawner,
            PlayButton playButton, EndGamePanel endGamePanel,TeamsContainer teamsContainer, TeamsObserver teamsObserver, FightTimer fightTimer)
        {
            this.playButton = playButton;
            this.endGamePanel = endGamePanel;
            this.teamsContainer = teamsContainer;
            this.teamsObserver = teamsObserver;
            this.fightTimer = fightTimer;
            allSpawners.Add(teamsSpawner);
            allSpawners.Add(fightersInTeamSpawner);
        }
        public void Enter()
        {
            ClearTeams();
            BeginToSpawn();
            fightTimer.enabled = false;
            endGamePanel.Hide();
            playButton.Show();
            teamsObserver.SubscribeToTeams();
        }
        public void Exit() => playButton.Hide();
        private void ClearTeams() => teamsContainer.ClearTeams();
        private void BeginToSpawn()
        {
            for (int i = 0; i < allSpawners.Count; i++)
            {
                allSpawners[i].Spawn();
            }
        }
    }
}