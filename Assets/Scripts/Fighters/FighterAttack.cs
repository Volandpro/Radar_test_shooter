using Infrastructure.Services;
using UnityEngine;

namespace Fighters
{
    public class FighterAttack : FighterComponent
    {
        public float damage;
        private float currentCooldown;
        private const float cooldownToAttack=1f;

        public override void SetParameters(IConfigCalculator configCalculator)
        {
            damage = ((FighterConfigCalculator) configCalculator).CalculateDamage();
        }

        private void Update()
        {
            currentCooldown += Time.deltaTime;
            if (currentCooldown >= cooldownToAttack)
            {
                currentCooldown = 0;
                if(fighterRoot.target!=null)
                    fighterRoot.target.GetComponent<ICanTakeDamage>().TakeDamage(damage);
            }
        }

    }
}