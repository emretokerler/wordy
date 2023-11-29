namespace Wordy.Resources
{
    public static class AddressablePaths
    {
        public static readonly string ADDRESSABLES_ROOT = "Assets/Addressables";

        public static readonly string DATA_ROOT = $"{ADDRESSABLES_ROOT}/Data";
        public static readonly string PREFABS_ROOT = $"{ADDRESSABLES_ROOT}/Prefabs";

        public static readonly string SCENES_ROOT = $"{PREFABS_ROOT}/SceneObjects";
        public static readonly string GRIDS_ROOT = $"{PREFABS_ROOT}/Grid";
        public static readonly string LEVELS_ROOT = $"{ADDRESSABLES_ROOT}/Levels";


        public static readonly string DEFAULT_GRIDVIEW_PREFAB = $"{GRIDS_ROOT}/GridView.prefab";
        public static readonly string DEFAULT_CELL_PREFAB = $"{GRIDS_ROOT}/Cell.prefab";



        public static readonly string COMMON_SCENE_PREFAB = $"{SCENES_ROOT}/CommonSceneObjects.prefab";
        public static readonly string MAIN_SCENE_PREFAB = $"{SCENES_ROOT}/MainSceneObjects.prefab";

        public static readonly string DEFAULT_LEVEL_TEMPLATE = $"{PREFABS_ROOT}/Levels/DefaultLevelTemplate.prefab";


        public static readonly string DEFAULT_GRIDVIEW_DATA = $"{DATA_ROOT}/GridViews/GridViewData.asset";
        public static readonly string DEFAULT_WORDSHELPER_DATA = $"{DATA_ROOT}/Words/WordsHelperData.asset";





    }
}