using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class TakeDamageBloodBehaviour : IEntityInit, IEntityDispose
    {
        private readonly ParticleSystem bulletBlood;
        private readonly ParticleSystem meleeBlood;
        private readonly Transform originTransform;

        private IReactive<DamageArgs> _damageEvent;
        private IReactive<DamageArgs> _deathEvent;

        public TakeDamageBloodBehaviour(
            ParticleSystem bulletBlood,
            ParticleSystem meleeBlood,
            Transform originTransform
        )
        {
            this.bulletBlood = bulletBlood;
            this.meleeBlood = meleeBlood;
            this.originTransform = originTransform;
        }

        public void Init(in IEntity entity)
        {
            _damageEvent = entity.GetTakeDamageEvent();
            _deathEvent = entity.GetDeathEvent();

            _damageEvent.Subscribe(this.OnDamageTaken);
            _deathEvent.Subscribe(this.OnDamageTaken);
        }

        public void Dispose(in IEntity entity)
        {
            _damageEvent.Subscribe(this.OnDamageTaken);
            _deathEvent.Subscribe(this.OnDamageTaken);
        }

        private void OnDamageTaken(DamageArgs args)
        {
            IEntity source = args.source;
            if (source == null)
                return;

            Vector3 sourcePosition = source.GetTransform().position;
            Vector3 myPosition = this.originTransform.position;
            Vector3 direction = (sourcePosition - myPosition).normalized;
            direction.y = 0;
            
            if (source.HasEnemyTag() && this.bulletBlood != null)
            {
                this.bulletBlood.transform.forward = direction;
                this.bulletBlood.Play(withChildren: true);
            }
            
            if (!source.HasEnemyTag() && this.meleeBlood != null)
            {
                this.meleeBlood.Play(withChildren: true);
            }
        }
    }
}