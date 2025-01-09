using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts
{
    public class PushComponent : MonoBehaviour
    {
        [SerializeField]
        private float _forceStrength = 500f;

        [SerializeField]
        private float _detectionRadius = 1f;

        [SerializeField]
        private LayerMask _tossableMask;

        private ITossable _nearbyTossable;

        public void Push()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _detectionRadius, _tossableMask);

            foreach (var collider in colliders)
            {
                ITossable tossable = collider.GetComponent<ITossable>();
                if (tossable != null)
                {
                    tossable.Toss(Vector2.right, _forceStrength);
                }
            }
        }
    }
}