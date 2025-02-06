using Atomic.Entities;
using Modules.Gameplay;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class EnemyAnimInstaller : SceneEntityInstaller
    {
        private const string FIRE_EVENT = "fire_event";

        [SerializeField] private Animator _animator;
        [SerializeField] private string _movingKey = "IsMoving";
        [SerializeField] private string _attackKey = "Attack";
        [SerializeField] private string _damageKey = "TakeDamage";
        [SerializeField] private string _deathKey = "Death";
        [SerializeField] private AnimationEventReceiver _animationReceiver;
        
        public override void Install(IEntity entity)
        {
            //Data:
            entity.AddAnimator(_animator);
            entity.AddAnimationEventReceiver(_animationReceiver);

            //Behaviours:
            entity.AddBehaviour(new MoveAnimBehaviour(_movingKey));
            entity.AddBehaviour(new AttackAnimBehaviour(_attackKey));
            entity.AddBehaviour(new TakeDamageAnimBehaviour(_damageKey));
            entity.AddBehaviour(new DeathAnimBehaviour(_deathKey));

        }
    }
}