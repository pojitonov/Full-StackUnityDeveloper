using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public class AmmoInstaller : SceneEntityInstaller
    {
        [SerializeField] private int _clipsAmount = 10;

        public override void Install(IEntity entity)
        {
            //Data:
            entity.AddInteractableTag();

            //Action:
            entity.AddInteractAction(new BaseAction<IEntity>(character =>
            {
                if (WeaponUseCase.AddCLips(character, _clipsAmount)) gameObject.SetActive(false);
            }));
        }
    }
}