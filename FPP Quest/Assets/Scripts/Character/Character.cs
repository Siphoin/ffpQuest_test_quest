using CharacterSystem.Settings;
using GameConstants;
using Items.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.Events;
using Inventory;

namespace CharacterSystem
{

    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(Rigidbody))]
    public class Character : MonoBehaviour
    {
        #region Constants
        private const string HORIZONTAL_AXIS = "Horizontal";
        private const string VERTICAL_AXIS = "Vertical";
        #endregion


        #region Fields
        private bool _enabledControl = true;

        private CharacterSettings _characterSettings;

        private CharacterController _characterController;

        private UIController _uiController;

        private Rigidbody _body;

        private InventoryPlayer _inventoryPlayer = new InventoryPlayer();

        #endregion

        #region Events
        public event UnityAction<bool> OnStateMoving;

        public event UnityAction<Item, int> OnItemAdded;

        public event UnityAction<int> OnItemRemoved;
        #endregion

        #region Properties
        public string IDActiveItem {get => _inventoryPlayer.ItemOnHand.Id; }
        #endregion


        #region Init
        void Start()
        {
            _uiController = FindObjectOfType<UIController>();


            // load character settings

            _characterSettings = Resources.Load<CharacterSettings>(Constants.PATH_SETTINGS_CHARACTER);

            if (!_characterSettings)
            {
                throw new CharacterControllerException("character settings not found");
            }


            //

            if (!TryGetComponent(out _characterController))
            {
                throw new CharacterControllerException("component CharacterController not seted");
            }

            if (!TryGetComponent(out _body))
            {
                throw new CharacterControllerException("component Rightbody not seted");
            }

            _uiController.OnNewStateInventory += SetStateCheckUI;

        }
        #endregion

        private void Update()
        {
            if (_enabledControl)
            {
                Moving();

            }

        }

        private void SetStateCheckUI (bool state) => SetStateControl(!state);

        #region Moving System

        private void Moving ()
        {
            if (_enabledControl)
            {
            float horizontal = Input.GetAxis(HORIZONTAL_AXIS);
            float vertical = Input.GetAxis(VERTICAL_AXIS);

            Vector3 directionMove = transform.right * horizontal + transform.forward * vertical;


            _characterController.Move(directionMove * _characterSettings.Speed * Time.deltaTime);
            }
            
        }

        public void SetStateControl (bool state)
        {
            _enabledControl = state;

            _body.isKinematic = !state;

            

            OnStateMoving?.Invoke(_enabledControl);
        }

        #endregion

        #region Rotating
        public void Rotate (Vector3 direction) => transform.Rotate(direction);
        #endregion



        #region Item Interaction
        public bool TryTakeItem (ItemData itemData)
        {
            if (itemData == null)
            {
                throw new CharacterControllerException("item data argument is null. Item not added on inventory");
            }
            Item newItem = new Item(itemData);

            bool result = _inventoryPlayer.TryAdd(newItem);
            if (result)
            {
                _inventoryPlayer.ItemOnHand = newItem;
                OnItemAdded?.Invoke(newItem, _inventoryPlayer.Count - 1);
                
            }


            return result;


        }

        public void RemoveLastItem ()
        {
            int index =_inventoryPlayer.Items.FindIndex(x => x.Id == _inventoryPlayer.ItemOnHand.Id);

            OnItemRemoved?.Invoke(index);

            _inventoryPlayer.Remove(_inventoryPlayer.Items[index]);

            if (_inventoryPlayer.Count > 0)
            {
                _inventoryPlayer.ItemOnHand = _inventoryPlayer.Items[_inventoryPlayer.Count - 1];
            }
        }

        public void GetItemOnHand (Item item) => _inventoryPlayer.ItemOnHand = item;
        #endregion


        #region Unity Callbacks
        private void OnDestroy() => _uiController.OnNewStateInventory -= SetStateCheckUI;
        #endregion


    }

}
