using System;
using System.Collections;
using UI;
using UnityEngine;

namespace Listeners
{
    public class CursorListener : MonoBehaviour
    {
        private UIController _UIController;

        // Use this for initialization
        void Start()
        {
            _UIController = FindObjectOfType<UIController>();


          _UIController.OnNewStateInventory += SetVisibleCursor;

          SetVisibleCursor(false);
        }

        private void SetVisibleCursor(bool state)
        {
            Cursor.visible = state;

            Cursor.lockState = state ? CursorLockMode.None : CursorLockMode.Locked;
        }


        #region Unity Callbacks
        private void OnDestroy() => _UIController.OnNewStateInventory -= SetVisibleCursor;
        #endregion
    }
}