using Infrastructure.ActualProviders;

namespace Zenject.ProjectContext
{
    public class ActualProvidersInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallGameLoopStateMachineProvider();
        }
        
        private void InstallGameLoopStateMachineProvider()
        {
            ActualGameLoopStateMachineProvider gameLoopStateProvider =
                Container.Instantiate<ActualGameLoopStateMachineProvider>();
            Container.Bind<ActualGameLoopStateMachineProvider>().FromInstance(gameLoopStateProvider).AsSingle();
        }
    }
}