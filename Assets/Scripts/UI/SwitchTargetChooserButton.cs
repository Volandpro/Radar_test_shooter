using Infrastructure.Services;
using UnityEngine;
using Zenject;

namespace UI
{
    public class SwitchTargetChooserButton : MonoBehaviour
    {
        private SwitchTargetChooser switchTargetChooser;
        
        [Inject]
        public void Construct(SwitchTargetChooser switchTargetChooser) => 
            this.switchTargetChooser = switchTargetChooser;

        public void SwitchTargetChooser() => switchTargetChooser.SwitchChooser();
    }
}
