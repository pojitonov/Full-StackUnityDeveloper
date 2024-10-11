using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay._Samples
{
    public sealed class InventoryView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshPro title;

        [SerializeField]
        private TextMeshPro description;

        [SerializeField]
        private Image icon;

        private IInventoryPresenter _presenter;

        public void Construct(IInventoryPresenter presenter)
        {
            _presenter = presenter;
        }

        public void Show()
        {
            this.title.text = _presenter.Title;
            this.description.text = _presenter.Description;
            this.icon.sprite = _presenter.Icon;
        }
    }
}