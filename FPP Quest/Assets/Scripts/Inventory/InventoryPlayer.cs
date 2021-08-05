using Items.Data;
using System.Collections.Generic;
using GameConstants;


namespace Inventory
{
    [System.Serializable]
    public  class InventoryPlayer
    {
        #region Fields
        private List<Item> _items;

        private Item _itemOnHand;
        #endregion


        #region Properties
        public int Count { get => _items.Count; }


        public List<Item> Items { get => _items; }
        public Item ItemOnHand { get => _itemOnHand; set => _itemOnHand = value; }
        #endregion


        public InventoryPlayer ()
        {
            _items = new List<Item>();
        }


        #region Interaction
        public bool TryAdd(Item item)
        {
            if (Count >= Constants.MAX_COUNT_ITEMS_ON_INVENTORY)
            {
                return false;
            }


            _items.Add(item);

            return true;
        }

        public void Remove(Item item) => _items.Remove(item);
        #endregion
    }
}
