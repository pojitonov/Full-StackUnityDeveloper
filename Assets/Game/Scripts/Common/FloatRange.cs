using UnityEngine;

namespace ShootEmUp
{
    [System.Serializable]
    public class FloatRange
    {
        public float min = 1f;
        public float max = 2f;

        public float GetRandomValue()
        {
            return Random.Range(min, max);
        }
    }
}