using UnityEngine;

namespace Fighters
{
    public interface ITargetChooser
    {
        Transform GetTarget(Fighter fighterComp);
    }
}