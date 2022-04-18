using UnityEngine;

namespace Fighters
{
    public abstract class FighterComponent : MonoBehaviour, IConfigable
    {
        protected Fighter fighterRoot;
        private void Awake()
        {
            fighterRoot = this.GetComponent<Fighter>();
            fighterRoot.AddToConfigables(this);
            fighterRoot.OnEnabled += Enable;
            fighterRoot.OnDisabled += Disable;
        }

        private void OnDestroy()
        {
            fighterRoot.OnEnabled -= Enable;
            fighterRoot.OnDisabled -= Disable;
        }

        private void Disable() => this.enabled = false;

        private void Enable() => this.enabled = true;
        public virtual void SetParameters(IConfigCalculator configCalculator)
        {
           
        }
    }
}