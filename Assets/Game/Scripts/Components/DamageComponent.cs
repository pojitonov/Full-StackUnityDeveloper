using UnityEngine;

namespace Game.Scripts
{
    public class DamageComponent : MonoBehaviour
    {
        [SerializeField]
        private int _damageValue = 1;
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            HealthComponent damageable = other.gameObject.GetComponent<HealthComponent>();
            if (damageable != null)
            {
                damageable.TakeDamage(_damageValue);
            }
        }
    }
}