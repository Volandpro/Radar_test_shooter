using System;
using Infrastructure.Services;
using UnityEngine;

namespace Fighters
{
    public class FighterHealth : FighterComponent, ICanTakeDamage
    {
        public float maxHp;
        public Action<float> OnHit;
        
        private float currentHp;

        public override void SetParameters(IConfigCalculator configCalculator) => 
            maxHp = currentHp = ((FighterConfigCalculator) configCalculator).CalculateHp();

        public void TakeDamage(float value)
        {
            currentHp -= value;
            OnHit?.Invoke(currentHp);
            if (currentHp <= 0)
            {
                fighterRoot.Death();
            }
        }
    }
}