using Items.Data;
using System.Collections;
using UnityEngine;

    public abstract class ContainerDataItem : MonoBehaviour
    {
    #region Fields
    [Header("Данные по предмету"), SerializeField]

    private ItemData _itemData;
    #endregion


    #region Properties
    public ItemData ItemData { get => _itemData; }
    #endregion

    }