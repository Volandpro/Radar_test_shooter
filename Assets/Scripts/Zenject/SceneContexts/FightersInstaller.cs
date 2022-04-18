using Fighters;
using Infrastructure.Services;
using Infrastructure.Spawners;
using UnityEngine;

namespace Zenject.SceneContexts
{
    public class FightersInstaller : MonoInstaller
    {
        [SerializeField] private GameObject fighterPrefab;
        [SerializeField] private GameObject shapesConfigPrefab;
        public override void InstallBindings()
        {
            InstallShapes();
            InstallPositionChooser();
            InstallFighterConfig();
            InstallConfigCalculator();
            InstallFactory();
        }

        private void InstallFactory()
        {
            Container.BindFactory<Fighter, Fighter.Factory>().FromComponentInNewPrefab(fighterPrefab);
        }

        private void InstallConfigCalculator()
        {
            FighterConfigCalculator fighterConfigCalculator = Container.Instantiate<FighterConfigCalculator>();
            Container.Bind<FighterConfigCalculator>().FromInstance(fighterConfigCalculator).AsSingle();
        }

        private void InstallFighterConfig()
        {
            FighterConfig fighterConfig = Container.Instantiate<FighterConfig>();
            Container.Bind<FighterConfig>().FromInstance(fighterConfig).AsSingle();
        }

        private void InstallPositionChooser()
        {
            FighterPositionChooser positionChooser = Container.Instantiate<FighterPositionChooser>();
            Container.Bind<IPositionChooser>().FromInstance(positionChooser).AsSingle();
        }

        private void InstallShapes()
        {
            FighterShapesConfig shapesConfig = Container.InstantiatePrefabForComponent<FighterShapesConfig>(shapesConfigPrefab);
            Container.Bind<FighterShapesConfig>().FromInstance(shapesConfig);
        }
    }
}