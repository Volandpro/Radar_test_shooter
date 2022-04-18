using Infrastructure.Services;
using UnityEngine;

namespace Fighters
{
    public class FighterColor : FighterComponent
    {
        public override void SetParameters(IConfigCalculator configCalculator)
        {
            this.GetComponent<SpriteRenderer>().color =
                ((FighterConfigCalculator) configCalculator).GetColor(fighterRoot.myTeam);
        }
    }
}