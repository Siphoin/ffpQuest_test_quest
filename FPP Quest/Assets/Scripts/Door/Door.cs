using CharacterSystem;
using System.Collections;
using UnityEngine;
using GameConstants;
using Extensions.GameObjects;
using UnityEngine.Events;

namespace DoorSystem
{
    [RequireComponent(typeof(MeshRenderer))]
    public class Door : ContainerDataItem, IColorObject
    {
        #region Constants
        private const float TIME_OUT_NOT_VALID_ITEM = 0.5f;
        #endregion

        #region Fields

        private bool _canInteraction = true;

        private bool _enteredPlayer = false;

        private MeshRenderer _mesh;

        private Character _character;

        private Color _defaultColor;
        #endregion

        #region Events
        public event UnityAction OnOpened;
        #endregion

        #region Init
        void Start()
        {
            if (!ItemData)
            {
                throw new DoorException($"door {name} not have data item for checking opwn");
            }

            if (!TryGetComponent(out _mesh))
            {
                throw new DoorException("door not have component Mesh Renderer");
            }

            _character = FindObjectOfType<Character>();

            _defaultColor = _mesh.material.color;
        }
        #endregion

        #region Interaction

        private void Update()
        {
            if (_canInteraction && _enteredPlayer)
            {
                if (Input.GetKeyDown(Constants.KEY_INTERACTION_OBJECT))
                {
                    if (_character.IDActiveItem == ItemData.Id)
                    {
                        OpenDoor();

                        _character.RemoveLastItem();
                    }

                    else
                    {
                        StartCoroutine(AnimationNotValidItem());
                    }
                }
            }
        }
        private void OpenDoor()
        {
            SetColor(Color.green);

            SetStateInteraction(false);

            OnOpened?.Invoke();

            enabled = false;
        }


        private void SetStateInteraction(bool state) => _canInteraction = state;

        private void SetStateEnteredPlayer(bool state) => _enteredPlayer = state;

        #endregion

        #region Color System
        public void SetColor(Color color)
        {
            _mesh.material.color = color;
        }
        
        private IEnumerator AnimationNotValidItem()
        {
            SetColor(Color.red);

            SetStateInteraction(false);

            yield return new WaitForSeconds(TIME_OUT_NOT_VALID_ITEM);

            SetColor(_defaultColor);

            SetStateInteraction(true);

            yield return null;
        }
        
        #endregion

        #region Collision Checking
        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.HasComponent<Character>())
            {
                Character character = null;
                SetStateEnteredPlayer(false);

            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.HasComponent<Character>())
            {
                SetStateEnteredPlayer(true);

            }
        }
        #endregion

    }
}
