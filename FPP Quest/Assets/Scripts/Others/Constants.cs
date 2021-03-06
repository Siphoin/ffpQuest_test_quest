using UnityEngine;


namespace GameConstants
{
    /// <summary>
    /// Зафиксированные игровые константы
    /// </summary>
    public static  class Constants
    {
        public const string PATH_SETTINGS_CHARACTER = "Data/CharacterData/CharacterSettings";

        public const string PATH_SETTINGS_GAME_CAMERA = "Data/GameCameraData/GameCameraSettings";

        public const string PATH_PREFAB_ITEM_CELL = "Prefabs/UI/itemCell";

        public const string PATH_PREFAB_WIN_WINDOW = "Prefabs/UI/win_window";

        public const int MAX_COUNT_ITEMS_ON_INVENTORY = 2;

        public const KeyCode KEY_INTERACTION_INVENTORY = KeyCode.Tab;

        public const KeyCode KEY_INTERACTION_OBJECT = KeyCode.E;

        public const KeyCode KEY_DROP_ITEM = KeyCode.F;
    }
}
