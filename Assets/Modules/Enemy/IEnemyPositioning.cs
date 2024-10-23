using UnityEngine;

namespace ShootEmUp
{
    public interface IEnemyPositioning
    {
        Transform GetRandomPoints(Transform[] points);
    }
}