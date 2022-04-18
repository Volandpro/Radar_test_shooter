using UI;
using UnityEngine;

namespace Zenject.SceneContexts
{
    public class GameHudInstaller : MonoInstaller
    {
        [SerializeField] private GameObject hud;
        public override void InstallBindings()
        {
            EndGamePanel endGamePanel = InstallEndGamePanel();
            InstallPlayButton(endGamePanel);
        }

        private void InstallPlayButton(EndGamePanel endGamePanel)
        {
            PlayButton playButton = endGamePanel.transform.root.GetComponentInChildren<PlayButton>();
            Container.Bind<PlayButton>().FromInstance(playButton).AsSingle();
        }

        private EndGamePanel InstallEndGamePanel()
        {
            EndGamePanel endGamePanel = Container.InstantiatePrefabForComponent<EndGamePanel>(hud);
            Container.Bind<EndGamePanel>().FromInstance(endGamePanel).AsSingle();
            return endGamePanel;
        }
    }
}