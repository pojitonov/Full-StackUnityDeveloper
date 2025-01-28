using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class CharacterAnimInstaller : SceneEntityInstaller
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private string _movingKey = "IsMoving";
        [SerializeField] private string _fireKey = "Attack";

        // private const string FIRE_EVENT = "fire_event";
        // [SerializeField] private AnimationEventReceiver _animationReceiver;

        public override void Install(IEntity entity)
        {
            //Data:
            entity.AddAnimator(_animator);
            entity.AddFireEvent(new BaseEvent());
            
            //Behaviours:
            entity.AddBehaviour(new MoveAnimBehaviour(_movingKey));
            entity.AddBehaviour(new FireAnimBehaviour(_fireKey));
            
            //Actions:
            entity.AddFireAction(new CharacterFireAction(entity));
        }
    }
}