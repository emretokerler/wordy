using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wordy.Resources;

namespace Wordy.Levels
{
    public class LevelsHelper : SingletonMonobehaviour<LevelsHelper>
    {
        public void SpawnDefaultLevel(LevelData levelData)
        {
            AddressableHelper.Instantiate<LevelBase>(AddressablePaths.DEFAULT_LEVEL_TEMPLATE, transform, Vector3.zero, Quaternion.identity, (level) =>
            {   
                level.SetLevelConfig(levelData);
            });
        }
    }
}