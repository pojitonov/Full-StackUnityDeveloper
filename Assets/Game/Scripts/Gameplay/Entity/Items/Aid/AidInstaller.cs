using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public class AidInstaller : SceneEntityInstaller
    {
        [SerializeField] private int _healthAmount = 10;
        [SerializeField] private ParticleSystem _vfx;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private GameObject _visual;

        public override void Install(IEntity entity)
        {
            //Data:
            entity.AddInteractableTag();

            //Actions:
            entity.AddInteractAction(new BaseAction<IEntity>(character =>
            {
                if (character.AddHealth(_healthAmount))
                {
                    _vfx.Play();
                    _audioSource.Play();
                    _visual.SetActive(false);
                }
            }));
        }
    }
}