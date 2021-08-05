using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using GameConstants;
using System;
using CharacterSystem;
using Items.Data;
using System.Linq;

namespace UI
{
    [RequireComponent(typeof(GridLayoutGroup))]
    public class InventoryGrid : MonoBehaviour
    {
        #region Fields

        private bool _inited = false;


        private ItemCell[] _cells;

        private ItemCell itemCellPrefab;

        private Character _character;

        #endregion


        private void Init()
        {

            itemCellPrefab = Resources.Load<ItemCell>(Constants.PATH_PREFAB_ITEM_CELL);

            if (!itemCellPrefab)
            {
                throw new InventoryGridException("item cell prefab not found");
            }

            _cells = new ItemCell[Constants.MAX_COUNT_ITEMS_ON_INVENTORY];

            for (int i = 0; i < _cells.Length; i++)
            {
                ItemCell newCell = Instantiate(itemCellPrefab, transform);
                newCell.OnSelect += SelectCell;
                _cells[i] = newCell;
            }


            _character = FindObjectOfType<Character>();

            _character.OnItemAdded += RefreshGrid;
            _character.OnItemRemoved += ReloadActiveCell;

            _inited = true;
        }

        private void ReloadActiveCell(int index)
        {
            RedrawCells();


            _cells[index].MarkEmtry();

        }

        private void RefreshGrid(Item item, int index)
        {
            RedrawCells();
            _cells[index].SetData(item);

        }

        private void SelectCell (int index, Item item)
        {
            RedrawCells();

            _cells[index].SetColorActive();


            _character.GetItemOnHand(item);
        }

        private void RedrawCells()
        {
            for (int i = 0; i < _cells.Length; i++)
            {
                _cells[i].SetColor(Color.black);
            }
        }

        public void SetStateVisibleCells (bool state)
        {
            for (int i = 0; i < _cells.Length; i++)
            {
                _cells[i].gameObject.SetActive(state);
            }
        }


        private void OnEnable()
        {
            if (!_inited)
            {
                Init();
            }
            RedrawCells();


            if (!string.IsNullOrEmpty(_character.IDActiveItem))
            {
            _cells.First(x => x.CurrentItem.Id == _character.IDActiveItem).SetColorActive();
            }

        }
    }
}