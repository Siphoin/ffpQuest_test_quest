using UnityEditor;
using UnityEngine;

namespace Camera.Settings
{
    [CreateAssetMenu(menuName = "SO/Game Camera/Camera Settings", order = 1)]
    public class GameCameraSettings : ScriptableObject
    {
        #region Fields
        [Header("Чувствительность мыши"), SerializeField]
        private float _mouseSensitivity = 100f;

        #endregion

        #region Properties
        public float MouseSensitivity { get => _mouseSensitivity; }
        #endregion
    }
}