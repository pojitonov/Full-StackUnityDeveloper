using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class CharacterAnimInstaller : SceneEntityInstaller
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private string _isMovingKey = "IsMoving";

        // private const string FIRE_EVENT = "fire_event";
        // [SerializeField] private AnimationEventReceiver _animationReceiver;

        public override void Install(IEntity entity)
        {
            //Data:
            entity.AddAnimator(_animator);
            
            //Behaviours:
            entity.AddBehaviour(new MoveAnimBehaviour(_isMovingKey));
        }
    }
}