using UnityEngine;

namespace Gameplay._Samples
{
    public class InventoryPresenter : IInventoryPresenter
    {
        public string Title { get; }
        public string Description { get; }
        public Sprite Icon { get; }

        private Inventory _inventory;
    }
}