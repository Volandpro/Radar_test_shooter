using Infrastructure.Services;
using UnityEngine;

namespace Zenject.SceneContexts
{
    public class FightTimerInstaller : MonoInstaller
    {
        [SerializeField] private GameObject timerPrefab;
        public override void InstallBindings()
        { 
            FightTimer timer= Container.InstantiatePrefabForComponent<FightTimer>(timerPrefab);
            Container.Bind<FightTimer>().FromInstance(timer).AsSingle();
        }
    }
}