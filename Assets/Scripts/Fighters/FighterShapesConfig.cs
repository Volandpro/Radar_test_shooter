using UnityEngine;

namespace Fighters
{
    public class FighterShapesConfig : MonoBehaviour, IConfig
    {
        public Sprite[] allShapes;
        public IConfig GetConfig()
        {
            return this;
        }
    }
}