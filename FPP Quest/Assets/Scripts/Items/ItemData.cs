using CustomAttributes;
using UnityEditor;
using UnityEngine;
using shortid;
namespace Items.Data
{
    [CreateAssetMenu(menuName = "SO/Items/Item", order = 2)]
    public class ItemData : ScriptableObject
    {
        #region Fields
        [Header("Иконка предмета"), SerializeField]
        private Sprite _icon;

        [Header("ID"), SerializeField, ReadOnlyField]
        private string _id;
        #endregion


        #region Properties
        public string Id { get => _id; }
        public Sprite Icon { get => _icon; }
        #endregion


        #region Unity Methods
        private void Awake() => _id = ShortId.Generate(false, true, 15);
        #endregion
    }
}