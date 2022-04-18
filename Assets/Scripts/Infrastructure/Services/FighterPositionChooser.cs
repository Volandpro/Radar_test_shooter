using UnityEngine;

namespace Infrastructure.Spawners
{
    public class FighterPositionChooser : IPositionChooser
    {
        private const float MinOffset=0.1f;
        private const float MaxOffset=0.3f;
        public Vector3 CalculatePosition(int teamNumber)
        {
            float width = Screen.width;
            float minXPos = Mathf.Abs(width * (MinOffset-teamNumber));
            float maxXPos = Mathf.Abs(width * (MaxOffset-teamNumber));
            float xPos = Random.Range(minXPos, maxXPos);
            float yPos = Random.Range(0, Screen.height);
            Vector3 targetPosition=Camera.main.ScreenToWorldPoint(new Vector3(xPos, yPos, -Camera.main.transform.position.z));
            return targetPosition;
        }
    }
}