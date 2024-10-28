using System;
using UnityEngine;

namespace ShootEmUp
{
    public class CharacterAttack : IAttackable
    {
        public event Action<Vector2, Vector2> OnFire;

        private readonly Character character;

        public CharacterAttack(Character character)
        {
            this.character = character;
        }

        public void Attack()
        {
            if (character.Target.Health <= 0)
            {
                return;
            }

            character.CurrentTime -= Time.fixedDeltaTime;

            if (character.CurrentTime <= 0)
            {
                Vector2 startPosition = character.FirePoint.position;
                Vector2 vector = (Vector2)character.Target.transform.position - startPosition;
                Vector2 direction = vector.normalized;
                OnFire?.Invoke(startPosition, direction);
                character.CurrentTime += character.Countdown;
            }
        }
    }
}