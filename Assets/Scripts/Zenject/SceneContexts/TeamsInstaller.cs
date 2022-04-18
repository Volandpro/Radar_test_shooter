using Fighters;
using Teams;

namespace Zenject.SceneContexts
{
    public class TeamsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallTeamsContainer();
            InstallTeamsConfig();
        }

        private void InstallTeamsConfig()
        {
            TeamsConfig teamsConfig = Container.Instantiate<TeamsConfig>();
            Container.Bind<TeamsConfig>().FromInstance(teamsConfig).AsSingle();
        }

        private void InstallTeamsContainer()
        {
            TeamsContainer teamsContainer = Container.Instantiate<TeamsContainer>();
            Container.Bind<TeamsContainer>().FromInstance(teamsContainer).AsSingle();
        }
    }
}