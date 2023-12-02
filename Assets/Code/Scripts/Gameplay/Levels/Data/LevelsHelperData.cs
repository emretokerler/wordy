using UnityEngine;

namespace Wordy.Levels.Data
{
    [CreateAssetMenu(fileName = "LevelsHelperData", menuName = "ScriptableObject/LevelsHelperData")]
    public class LevelsHelperData : ScriptableObject
    {
        public LevelData DefaultLevelData;
    }
}
