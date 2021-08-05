using CustomAttributes;
using UnityEngine;

namespace Items.Data
{
    [System.Serializable]
    public struct Item
    {
        #region Fields

        private string _id;

        private Sprite _icon;

        #endregion


        #region Properties
        public string Id { get => _id; }
        public Sprite Icon { get => _icon; }
        #endregion


        public Item (ItemData itemData)
        {
            if (itemData == null)
            {
                throw new ItemException("item data is null");
            }

            _id = itemData.Id;
            _icon = itemData.Icon;
        }
    }
}
