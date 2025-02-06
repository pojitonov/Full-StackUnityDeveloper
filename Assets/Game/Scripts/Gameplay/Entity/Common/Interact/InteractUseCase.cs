using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public static class InteractUseCase
    {
        public static bool Interact(this IEntity source, in IEntity target)
        {
            if(source == null) return false;
            if (target == null || !target.HasInteractableTag()) return false;
            target.GetInteractAction().Invoke(source);
            return true;
        }

        public static bool Interact(this IEntity source, in Collider collider)
        {
            return collider != null && collider.TryGetComponent(out IEntity other) && Interact(source, other);
        }
    }
}