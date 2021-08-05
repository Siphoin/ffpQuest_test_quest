using CharacterSystem;
using Extensions.GameObjects;
using System.Collections;
using UnityEngine;
using GameConstants;
using Items.Data;

namespace Items
{
    public class ItemObject : ContainerDataItem
    {
        #region Fields
        private bool _canTake = false;

        private Character _character;
        #endregion


        #region Init
        void Start() => _character = FindObjectOfType<Character>();


        #endregion
        void Update()
        {
            if (Input.GetKeyDown(Constants.KEY_INTERACTION_OBJECT) && _canTake)
            {
                if (_character.TryTakeItem(ItemData))
                {
                Destroy(gameObject);
                }


            }
        }

        private void SetStateCanTake (bool state) => _canTake = state;

        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.HasComponent<Character>())
            {
                SetStateCanTake(false);

            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.HasComponent<Character>())
            {
                SetStateCanTake(true);

            }
        }
    }
}