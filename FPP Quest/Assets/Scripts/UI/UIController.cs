using System.Collections;
using UnityEngine;
using GameConstants;
using UnityEngine.Events;

namespace UI
{
    public class UIController : MonoBehaviour
    {
        #region Fields
        private bool _UIActive = false;

        [Header("Grid ячеек предметов"), SerializeField]
        private InventoryGrid _inventoryGrid;
        #endregion

        #region Events
        public event UnityAction<bool> OnNewStateInventory;
        #endregion

        #region Init
        void Start()
        {
            if (!_inventoryGrid)
            {
                throw new UIControllerException("inventory grid not seted");
            }

            SetStateVisibleCells();

            #endregion

        }

        #region Interactions

        private void Update()
        {
            if (Input.GetKeyDown(Constants.KEY_INTERACTION_INVENTORY))
            {
                _UIActive = !_UIActive;

                SetStateVisibleCells();

                OnNewStateInventory?.Invoke(_UIActive);
            }
        }

        private void SetStateVisibleCells() => _inventoryGrid.SetStateVisibleCells(_UIActive);


        #endregion

        #region Unity Callbacks
        private void OnDisable()
        {
            _UIActive = false;

            SetStateVisibleCells();
        }


        private void OnDestroy() => Destroy(_inventoryGrid.gameObject);
        #endregion
    }
}