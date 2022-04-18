using Fighters;
using Teams;
using UnityEngine;
using Zenject;

namespace Infrastructure.Services
{
    public class SwitchTargetChooser
    {
        private readonly TeamsContainer teamsContainer;
        private readonly DiContainer diContainer;
        private int currentNumber;

        [Inject]
        public SwitchTargetChooser(TeamsContainer teamsContainer, DiContainer diContainer)
        {
            this.teamsContainer = teamsContainer;
            this.diContainer = diContainer;
        }

        public void SwitchChooser()
        {
            ITargetChooser targetChooser;
            if (currentNumber == 0)
            {
                targetChooser = diContainer.Instantiate<TeamTargetChooser>();
                currentNumber = 1;
            }
            else
            {
                targetChooser = diContainer.Instantiate<SingleTargetChooser>();
                currentNumber = 0;
            }
            Debug.Log(targetChooser);
            diContainer.Rebind<ITargetChooser>().FromInstance(targetChooser);
            teamsContainer.UpdateTargetChooserForFighters(targetChooser);
        }
        
    }
}