using UnityEngine;

namespace Infrastructure.Services
{
    public class FightTimer : MonoBehaviour
    {
        private float currentTimer;

        public void ResetTimer()
        {
            currentTimer = 0;
        }

        public float GetTimer()
        {
            return currentTimer;
        }
        private void Update()
        {
            currentTimer += Time.deltaTime;
        }
    }
}