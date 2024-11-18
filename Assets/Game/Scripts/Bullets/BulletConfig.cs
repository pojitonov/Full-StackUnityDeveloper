using UnityEngine;

namespace ShootEmUp
{
    [CreateAssetMenu(fileName = "NewBulletConfig", menuName = "ShootEmUp/Bullet Config")]
    public class BulletConfig : ScriptableObject
    {
        public Color color = Color.white;
        public int layer;
        public float speed = 10f;

    }
}