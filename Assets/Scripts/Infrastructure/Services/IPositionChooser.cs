using UnityEngine;

namespace Infrastructure.Spawners
{
    public interface IPositionChooser
    {
        Vector3 CalculatePosition(int teamNumber);
    }
}