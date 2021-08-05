using Camera.Settings;
using UnityEngine;
using GameConstants;
using CharacterSystem;

namespace Camera
{
    public class GameCamera : MonoBehaviour
    {
        #region Fields

        private float _xRoot = 0f;

        private bool _enabledRotating = true;

        private GameCameraSettings _cameraSettings;


        private Character _character;
        #endregion

        #region Init
        void Start()
        {
            _cameraSettings = Resources.Load<GameCameraSettings>(Constants.PATH_SETTINGS_GAME_CAMERA);

            if (!_cameraSettings)
            {
                throw new GameCameraException("camera settings not found");
            }

            if (transform.parent == null)
            {
                throw new GameCameraException("camerra must be child");
            }

            if (!transform.parent.TryGetComponent(out _character))
            {
                throw new GameCameraException($"parent {name} not have component Character");
            }

            _character.OnStateMoving += SetStateEnableRotating;
        }
        #endregion

        #region Rotating System
        private void SetStateEnableRotating(bool state) => _enabledRotating = state;

        void Update() => Rotating();

        private void Rotating()
        {
            if (_enabledRotating)
            {
                float mouseX = GetAxis(GameCameraAxisMouse.X);
                float mouseY = GetAxis(GameCameraAxisMouse.Y);

                _xRoot -= mouseY;

                _xRoot = Mathf.Clamp(_xRoot, -90f, 90f);

                transform.localRotation = Quaternion.Euler(_xRoot, 0f, 0f);

                _character.Rotate(Vector3.up * mouseX);
            }

        }

        private float GetAxis(GameCameraAxisMouse axisMouse)
        {
            return Input.GetAxis($"Mouse {axisMouse}") * _cameraSettings.MouseSensitivity * Time.deltaTime;
        }
        #endregion


        #region Unity Callbacks
        private void OnDestroy() => _character.OnStateMoving += SetStateEnableRotating;
        #endregion
    }
}