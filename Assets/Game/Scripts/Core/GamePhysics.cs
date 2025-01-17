using UnityEngine;

namespace Game.Scripts.Core
{
    public static class GamePhysics
    {
        private const float _forceMultiplier = 100;
        private const float _impulseMultiplier = 1;

        public static void AddForce(Rigidbody2D rigidbody, Vector2 direction, float force,
            ForceMode2D forceMode = ForceMode2D.Force)
        {
            if (!rigidbody) return;
            if (forceMode == ForceMode2D.Force)
                rigidbody.AddForce(direction.normalized * (force * _forceMultiplier), forceMode);
            if (forceMode == ForceMode2D.Impulse)
                rigidbody.AddForce(direction.normalized * (force * _impulseMultiplier), forceMode);
        }

        public static void AddForceToInteractable(GameObject item, Vector2 direction, float force)
        {
            if (!item) return;
            if (item.TryGetComponent(out Rigidbody2D rigidbody))
                AddForce(rigidbody, direction, force);
        }

        public static GameObject GetInteractable(Vector2 position, float radius, LayerMask mask, Vector2 lookDirection)
        {
            var collider = Physics2D.OverlapCircle(position, radius, mask);
            if (!collider) return null;
            
            GameObject interactable = collider.gameObject;
            
            Vector2 toObject = (collider.transform.position - (Vector3)position).normalized;
            if (Vector2.Dot(lookDirection, toObject) > 0)
                return interactable;
            return null;
        }

        public static Transform GetRaycastTransform(Transform transform, Vector2 direction, float distance,
            LayerMask layerMask)
        {
            var raycast = Physics2D.Raycast(transform.position, direction, distance, layerMask);
            return raycast.transform;
        }
    }
}