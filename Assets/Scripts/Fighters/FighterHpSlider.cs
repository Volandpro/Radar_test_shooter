using System;
using UnityEngine;

namespace Fighters
{
    [RequireComponent(typeof(FighterHealth))]
    public class FighterHpSlider : MonoBehaviour
    {
        [SerializeField] private UnityEngine.UI.Image foreground;
        private float maxHealth;
        private void Start()
        {
            FighterHealth fighterHealth = GetComponent<FighterHealth>();
            fighterHealth.OnHit += SetHpSlider;
            maxHealth=fighterHealth.maxHp;
        }

        private void OnDestroy() => 
            GetComponent<FighterHealth>().OnHit -= SetHpSlider;

        private void SetHpSlider(float currentHp) => 
            foreground.fillAmount = currentHp / maxHealth;
    }
}