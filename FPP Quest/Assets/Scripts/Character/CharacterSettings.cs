using UnityEngine;

namespace CharacterSystem.Settings
{
    [CreateAssetMenu(menuName = "SO/Character/Character Settings", order = 0)]
    public class CharacterSettings : ScriptableObject
    {
        #region Fields

        [Header("Скорость движения")]
        [SerializeField] private float _speed = 10f;

        #endregion


        #region Properties

        public float Speed { get => _speed; }

        #endregion
    }
}