using Atomic.Entities;
using Modules.Gameplay;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class EnemyAnimInstaller : SceneEntityInstaller
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private string _movingKey = "IsMoving";
        [SerializeField] private string _attackKey = "Attack";
        [SerializeField] private string _damageKey = "TakeDamage";
        [SerializeField] private string _deathKey = "Death";
        
        [SerializeField] private AnimationEventReceiver _animationReceiver;
        
        public override void Install(IEntity entity)
        {
            entity.AddAnimator(_animator);
            entity.AddAnimationEventReceiver(_animationReceiver);
            
            //Move:
            entity.AddBehaviour(new MoveAnimBehaviour(_movingKey));
            
            //Attack:
            entity.AddBehaviour(new EnemyAttackAnimBehaviour(_attackKey));
            
            //Damage:
            entity.AddBehaviour(new TakeDamageAnimBehaviour(_damageKey));
            entity.AddBehaviour(new DeathAnimBehaviour(_deathKey));
        }
    }
}