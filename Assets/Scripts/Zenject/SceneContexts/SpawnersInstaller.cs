using Infrastructure.Spawners;

namespace Zenject.SceneContexts
{
    public class SpawnersInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallTeamsSpawner();
            InstallFightersInTeamSpawner();
        }

        private void InstallFightersInTeamSpawner()
        {
            FightersInTeamSpawner fightersSpawner = Container.Instantiate<FightersInTeamSpawner>();
            Container.Bind<FightersInTeamSpawner>().FromInstance(fightersSpawner).AsSingle();
        }

        private void InstallTeamsSpawner()
        {
            TeamsSpawner teamsSpawner = Container.Instantiate<TeamsSpawner>();
            Container.Bind<TeamsSpawner>().FromInstance(teamsSpawner).AsSingle();
        }
    }
}