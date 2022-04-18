using Infrastructure.Services;

namespace Zenject.SceneContexts
{
    public class TeamsObserverInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            TeamsObserver teamsObserver = Container.Instantiate<TeamsObserver>();
            Container.Bind<TeamsObserver>().FromInstance(teamsObserver).AsSingle();
        }
    }
}