using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public class AmmoInstaller : SceneEntityInstaller
    {
        [SerializeField] private int _ammoAmount = 10;
        [SerializeField] private ParticleSystem _vfx;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private GameObject _visual;

        public override void Install(IEntity entity)
        {
            entity.AddInteractableTag();

            entity.AddInteractAction(new BaseAction<IEntity>(character =>
            {
                if (character.AddAmmo(_ammoAmount))
                {
                    _vfx.Play();
                    _audioSource.Play();
                    _visual.SetActive(false);
                    entity.DelInteractableTag();
                }
            }));
        }
    }
}