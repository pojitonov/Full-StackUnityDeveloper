using UnityEngine;

namespace ShootEmUp
{
    public class EnemyPositioning : IEnemyPositioning
    {
        public Transform GetRandomPoints(Transform[] points)
        {
            int index = Random.Range(0, points.Length);
            return points[index];
        }
    }
}