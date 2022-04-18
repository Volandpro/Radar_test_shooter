using Infrastructure.Services;
using UnityEngine;

namespace Fighters
{
    public class FighterShape : FighterComponent
    {
        public override void SetParameters(IConfigCalculator configCalculator)
        {
            this.GetComponent<SpriteRenderer>().sprite =
                ((FighterConfigCalculator) configCalculator).GetSprite();
        }
    }
}