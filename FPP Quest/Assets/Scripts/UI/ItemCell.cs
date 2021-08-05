using Items.Data;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Image))]
    public class ItemCell : MonoBehaviour, IColorObject
    {
        #region Fields
        [Header("Пиктограмма")]
        [SerializeField] private Image _pictogram;

        private Image _background;

        private Item _currentItem;

        #endregion

        #region Events
        public event UnityAction<int, Item> OnSelect;
        #endregion


        #region Properties
        public Item CurrentItem { get => _currentItem; }
        #endregion


        #region Init
        void Start()
        {
            if (!_pictogram)
            {
                throw new ItemCellException("pictogram not seted");
            }

            if (!TryGetComponent(out _background))
            {
                throw new ItemCellException("item cell not have component Image");
            }

        }
        #endregion
        // Use this for initialization
        #region Color System
        public void SetColorActive() => SetColor(Color.green);

        public void MarkEmtry()
        {
            _currentItem = new Item();
            SetColorPictogram(new Color());
        }

        private void SetColorPictogram(Color color) => _pictogram.color = color;

        public void SetColor(Color color)
        {
            if (!_background)
            {
                if (!TryGetComponent(out _background))
                {
                    throw new ItemCellException("item cell not have component Image");
                }
            }


            var newColor = color;
            newColor.a = _background.color.a;
            _background.color = newColor;


        }
        #endregion

        #region Interactions
        public void SetData(Item item)
        {
            _currentItem = item;
            _pictogram.sprite = _currentItem.Icon;

            SetColorPictogram(Color.white);

            SetColorActive();

        }


        public void Select()
        {
            if (!string.IsNullOrEmpty(_currentItem.Id))
            {
                OnSelect?.Invoke(transform.GetSiblingIndex(), _currentItem);
            }


        }
        #endregion
    }
}