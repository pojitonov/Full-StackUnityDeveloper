using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts
{
    public class TossComponent : MonoBehaviour
    {
        [SerializeField]
        private float _strength = 500f;
        
        [SerializeField]
        private float _detectionRadius = 1f;

        private int MASK;
        private ITossable _nearbyTossable;

        private void Awake()
        {
            MASK = LayerMask.GetMask("Enemy");
        }
        
        public void Toss()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _detectionRadius, MASK);

            List<ITossable> tossableItems = new List<ITossable>();

            foreach (var collider in colliders)
            {
                ITossable tossable = collider.GetComponent<ITossable>();
                if (tossable != null)
                {
                    tossableItems.Add(tossable);
                }
            }

            foreach (var tossableItem in tossableItems)
            {
                tossableItem.Toss(_strength);
            }
        }
    }
}