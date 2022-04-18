using Fighters;
using Zenject;

namespace Infrastructure.Services
{
    public class TargetChooserInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallITargetChooser();
            InstallSwitchTargetChooser();
        }

        private void InstallSwitchTargetChooser()
        {
            SwitchTargetChooser switchTargetChooser = Container.Instantiate<SwitchTargetChooser>();
            Container.Bind<SwitchTargetChooser>().FromInstance(switchTargetChooser);
        }

        private void InstallITargetChooser()
        {
            ITargetChooser singleTargetChooser = Container.Instantiate<SingleTargetChooser>();
            Container.Bind<ITargetChooser>().FromInstance(singleTargetChooser);
        }
    }
}