using Infrastructure.ActualProviders;
using Infrastructure.States.GameLoopStates;
using UnityEngine;
using Zenject;

namespace UI
{
    public class PlayButton : MonoBehaviour
    {
        private GameLoopStateMachine stateMachine;
        
        [Inject]
        public void Construct(ActualGameLoopStateMachineProvider stateMachineProvider) => 
            stateMachineProvider.OnStateMachineSet += SetGameLoopStateMachine;

        private void SetGameLoopStateMachine(GameLoopStateMachine gameLoopStateMachine) => 
            stateMachine = gameLoopStateMachine;

        public void Play()
        {
            stateMachine.Enter<PlayingState>();
            this.gameObject.SetActive(false);
        }
        public void Show() => this.gameObject.SetActive(true);
        
        public void Hide() => this.gameObject.SetActive(false);
    }
}
