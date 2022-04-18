using System;
using Infrastructure.Services;
using UnityEngine;

namespace Fighters
{
    [RequireComponent(typeof(FighterAttack))]
    public class FighterAttackChecker : FighterComponent
    {
        private float range;
        private float currentDistance;
        private FighterAttack attackComponent;

        private void Start() => attackComponent = this.GetComponent<FighterAttack>();

        private void Update()
        {
            currentDistance = Vector3.Distance(this.transform.position, fighterRoot.target.position);
            SetAttackComponent(currentDistance<=range);
        }

        private void SetAttackComponent(bool enabled)
        {
            if (attackComponent.enabled != enabled)
                attackComponent.enabled = enabled;
        }

        public override void SetParameters(IConfigCalculator configCalculator) => 
            range = ((FighterConfigCalculator) configCalculator).CalculateAttackRange();
    }
}