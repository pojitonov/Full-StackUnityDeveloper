using UnityEngine;

namespace Gameplay._Samples
{
    public interface IInventoryPresenter
    {
        string Title { get; }
        string Description { get; }
        Sprite Icon { get; }
    }
    
    public sealed class Inventory
    {
        
    }
}