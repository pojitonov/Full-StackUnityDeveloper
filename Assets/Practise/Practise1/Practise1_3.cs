using UnityEngine;

namespace Practise1
{
    /// Упражнение №3
    public interface IWeapon
    {
        void Attack(Transform firePoint);
    }

    public class Bazooka : IWeapon
    {
        private readonly GameObject _projectilePrefab;

        public Bazooka(GameObject projectilePrefab)
        {
            _projectilePrefab = projectilePrefab;
        }

        public void Attack(Transform firePoint)
        {
            Object.Instantiate(_projectilePrefab, firePoint.position, firePoint.rotation);
        }
    }

    public class Knife : IWeapon
    {
        private readonly int _damage;
        private readonly float _radius;

        public Knife(int damage, float radius)
        {
            _damage = damage;
            _radius = radius;
        }

        public void Attack(Transform firePoint)
        {
            Collider[] colliders = Physics.OverlapSphere(firePoint.position, _radius);
            foreach (Collider collider in colliders)
            {
                if (collider.TryGetComponent(out HealthComponent healthComponent))
                {
                    healthComponent.TakeDamage(_damage);
                    return;
                }
            }
        }
    }

    public class Rifle : IWeapon
    {
        private readonly int _damage;
        private readonly float _distance;

        public Rifle(int damage, float distance)
        {
            _damage = damage;
            _distance = distance;
        }

        public void Attack(Transform firePoint)
        {
            Ray ray = new Ray(firePoint.position, firePoint.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, _distance))
            {
                if (hit.collider.TryGetComponent(out HealthComponent healthComponent))
                {
                    healthComponent.TakeDamage(_damage);
                }
            }
        }
    }

    public sealed class WeaponController : MonoBehaviour
    {
        [SerializeField]
        private Transform _firePoint;

        private IWeapon _currentWeapon;

        private void Start()
        {
            _currentWeapon = new Rifle(50, 100f);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _currentWeapon.Attack(_firePoint);
            }
        }

        public void SetWeapon(IWeapon weapon)
        {
            _currentWeapon = weapon;
        }
    }
}