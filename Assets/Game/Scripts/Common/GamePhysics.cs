using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Common
{
    public class GamePhysics
    {
        private const float _forceMultiplier = 100;
        
        public static void AddForce(Rigidbody2D rigidbody, Vector2 direction, float force, ForceMode2D forceMode = ForceMode2D.Force)
        {
            if (forceMode == ForceMode2D.Force)
                rigidbody.AddForce(direction.normalized * (force * _forceMultiplier), forceMode);
            else if (forceMode == ForceMode2D.Impulse)
                rigidbody.AddForce(direction.normalized * force, forceMode);
        }

        public static void AddForceToInteractable(IEnumerable<GameObject> items, Vector2 direction, float force)
        {
            foreach (var item in items)
            {
                if (item.TryGetComponent(out Rigidbody2D rigidbody))
                {
                    AddForce(rigidbody, direction, force);
                }
            }
        }

        public static Transform GetRaycastTransform(Transform transform, Vector2 direction, float distance, LayerMask layerMask)
        {
            var raycast = Physics2D.Raycast(transform.position, direction, distance, layerMask);
            return raycast.transform;
        }
    }
}