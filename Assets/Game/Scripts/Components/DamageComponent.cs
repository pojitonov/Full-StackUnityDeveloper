using UnityEngine;

namespace Game.Scripts
{
    public class DamageComponent : MonoBehaviour
    {
        [SerializeField]
        private int _damageValue = 1;

        private void OnCollisionEnter2D(Collision2D other)
        {
            ApplyDamage(other.gameObject);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            ApplyDamage(other.gameObject);
        }

        private void ApplyDamage(GameObject other)
        {
            Collider2D[] colliders = other.GetComponentsInChildren<Collider2D>();

            foreach (var collider in colliders)
            {
                HealthComponent damageable = collider.transform.root.GetComponent<HealthComponent>();

                if (damageable != null)
                {
                    damageable.TakeDamage(_damageValue);
                    break;
                }
            }
        }
    }
}