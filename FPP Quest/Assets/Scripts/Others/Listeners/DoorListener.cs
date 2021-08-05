using DoorSystem;
using UnityEngine;
using GameConstants;


namespace Listeners
{
    public class DoorListener : MonoBehaviour
    {
        #region Fields

        private int _countOpenedDoors;

        private Door[] _doors;

        private GameObject _windowWin;
        #endregion

        #region Init
        void Start()
        {
            _windowWin = Resources.Load<GameObject>(Constants.PATH_PREFAB_WIN_WINDOW);

            if (!_windowWin)
            {
                throw new DoorsListenerException("window win prefab not found");
            }

            _doors = FindObjectsOfType<Door>();

            for (int i = 0; i < _doors.Length; i++)
            {
                _doors[i].OnOpened += CheckDoors;
            }
        }
        #endregion


        #region Checking Doors
        private void CheckDoors()
        {
          IncrementScoreOpenedDoors();
            
           
            if (_countOpenedDoors == _doors.Length)
            {
                for (int i = 0; i < _doors.Length; i++)
                {
                    _doors[i].OnOpened -= CheckDoors;
                }

                Instantiate(_windowWin);

                enabled = false;
            }
            
        }
        #endregion

        #region Calculating
        private void IncrementScoreOpenedDoors() => _countOpenedDoors++;
        #endregion

    }
}