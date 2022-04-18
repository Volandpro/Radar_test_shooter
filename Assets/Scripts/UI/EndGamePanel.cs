using Infrastructure.ActualProviders;
using Infrastructure.Services;
using Infrastructure.States.GameLoopStates;
using UnityEngine;
using Zenject;

namespace UI
{
    public class EndGamePanel : MonoBehaviour
    {
        [SerializeField] private TMPro.TextMeshProUGUI timerValue;
        private GameLoopStateMachine stateMachine;
        private FightTimer fightTimer;

        [Inject]
        public void Construct(ActualGameLoopStateMachineProvider stateMachineProvider, FightTimer fightTimer)
        {
            this.fightTimer = fightTimer;
            stateMachineProvider.OnStateMachineSet += SetGameLoopStateMachine;
        }

        private void SetGameLoopStateMachine(GameLoopStateMachine gameLoopStateMachine) => 
            stateMachine = gameLoopStateMachine;

        private void SetTimerValue() => 
            timerValue.text = Mathf.Round(fightTimer.GetTimer()).ToString();

        public void Show()
        {
            this.gameObject.SetActive(true);
            SetTimerValue();
        }

        public void Hide() => this.gameObject.SetActive(false);
        
        public void Quit() => Application.Quit();

        public void Replay() => stateMachine.Enter<LevelCreationState>();
    }
}
