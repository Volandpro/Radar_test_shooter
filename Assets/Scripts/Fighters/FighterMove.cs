using Infrastructure.Services;
using UnityEngine;

namespace Fighters
{
    [RequireComponent(typeof(Fighter))]
    public class FighterMove : FighterComponent
    {
        private float moveSpeed;
        private const float minDistance=2f;
        
        private void Update()
        {
            if (fighterRoot.target != null)
            {
                if (TargetNotReached())
                    MoveToTarget();
            }
        }

        private bool TargetNotReached() => 
            (Vector3.Distance(this.transform.position, fighterRoot.target.transform.position) > minDistance);

        private void MoveToTarget()
        {
            if (fighterRoot.target != null)
                transform.Translate(Vector3.Normalize(fighterRoot.target.position-transform.position) * Time.deltaTime*moveSpeed);
        }
        
        public override void SetParameters(IConfigCalculator fighterConfigCalculator) =>
            moveSpeed = ((FighterConfigCalculator) fighterConfigCalculator).CalculateMoveSpeed();
    }
}