using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class EnemyAnimInstaller : SceneEntityInstaller
    {
        // private const string FIRE_EVENT = "fire_event";
        // [SerializeField] private AnimationEventReceiver _animationReceiver;

        [SerializeField] private Animator _animator;
        [SerializeField] private string _movingKey = "IsMoving";
        [SerializeField] private string _attackKey = "Attack";
        [SerializeField] private string _damageKey = "TakeDamage";
        [SerializeField] private string _deathKey = "Death";
        
        public override void Install(IEntity entity)
        {
            //Data:
            entity.AddAnimator(_animator);

            //Behaviours:
            entity.AddBehaviour(new MoveAnimBehaviour(_movingKey));
            entity.AddBehaviour(new AttackAnimBehaviour(_attackKey));
            entity.AddBehaviour(new TakeDamageAnimBehaviour(_damageKey));
            entity.AddBehaviour(new DeathAnimBehaviour(_deathKey));

        }
    }
}