using System;
using System.Collections.Generic;
using Infrastructure.Services;
using Teams;
using UnityEngine;
using Zenject;

namespace Fighters
{
    public class Fighter : MonoBehaviour
    {
        private List<IConfigable> myConfigables = new List<IConfigable>();
        private FighterConfigCalculator configCalculator;
        private ITargetChooser targetChooser;

        protected internal Transform target;
        
        public Team myTeam;
        public Action OnEnabled;
        public Action OnDisabled;
        
        [Inject]
        public void Construct(FighterConfigCalculator configCalculator, ITargetChooser targetChooser)
        {
            this.targetChooser = targetChooser;
            this.configCalculator = configCalculator;
        }

        public void UpdateTargetChooser(ITargetChooser targetChooser)
        {
            this.targetChooser = targetChooser;
            target = targetChooser.GetTarget(this);
        }

        private void Update() => 
            TryFindTarget();

        private void TryFindTarget()
        {
            if (target == null)
                target = targetChooser.GetTarget(this);
        }

        public void Disable() => OnDisabled?.Invoke();

        public void Enable() => OnEnabled?.Invoke();

        public void AddToConfigables(IConfigable newConfigable) => myConfigables.Add(newConfigable);

        public void SetRandomConfig()
        {
            for (int i = 0; i < myConfigables.Count; i++)
            {
                myConfigables[i].SetParameters(configCalculator);
            }
        }

        public void Death()
        {
            myTeam.RemoveFighter(this);
            Destroy(this.gameObject);
        }

        public class Factory : PlaceholderFactory<Fighter>
        {
        }
    }
}