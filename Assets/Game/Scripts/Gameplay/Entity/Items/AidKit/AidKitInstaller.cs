using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public class AidKitInstaller : SceneEntityInstaller
    {
        [SerializeField] private int _healthAmount = 10;

        public override void Install(IEntity entity)
        {
            //Data:
            entity.AddInteractableTag();

            //Action:
            entity.AddInteractAction(new BaseAction<IEntity>(character =>
            {
                if (character.AddHealth(_healthAmount)) gameObject.SetActive(false);
            }));
        }
    }
}