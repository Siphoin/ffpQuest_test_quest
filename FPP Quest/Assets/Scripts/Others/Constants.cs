using UnityEngine;


namespace GameConstants
{
    /// <summary>
    /// Зафиксированные игровые константы
    /// </summary>
    public static  class Constants
    {
        public static readonly string PATH_SETTINGS_CHARACTER = "Data/CharacterData/CharacterSettings";

        public static readonly string PATH_SETTINGS_GAME_CAMERA = "Data/GameCameraData/GameCameraSettings";

        public static readonly string PATH_PREFAB_ITEM_CELL = "Prefabs/UI/itemCell";

        public static readonly string PATH_PREFAB_WIN_WINDOW = "Prefabs/UI/win_window";

        public static readonly int MAX_COUNT_ITEMS_ON_INVENTORY = 2;

        public static readonly KeyCode KEY_INTERACTION_INVENTORY = KeyCode.Tab;

        public static readonly KeyCode KEY_INTERACTION_OBJECT = KeyCode.E;

        public static readonly KeyCode KEY_DROP_ITEM = KeyCode.F;
    }
}
