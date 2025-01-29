using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class PistolInstaller : SceneEntityInstaller<IWeaponEntity>
    {
        [SerializeField] private SceneEntity _bulletPrefab;
        [SerializeField] private Transform _firePoint;
        
        private GameContext _context;
        
        protected override void Install(IWeaponEntity entity)
        {
            //Context:
            _context = GameContext.Instance;
            
            //Data:
            entity.AddBulletPrefab(_bulletPrefab);
            entity.AddFirePoint(_firePoint);
            entity.AddFireEvent(new BaseEvent());
            
            //Conditions:
            entity.AddFireCondition(new Const<bool>(true));
            
            //Actions:
            entity.AddFireAction(new PistolFireAction(entity, _context));
        }
    }
}