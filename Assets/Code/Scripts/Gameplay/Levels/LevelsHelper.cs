using System.Collections;
using UnityEngine;
using Wordy.Levels.Data;
using Wordy.Resources;
using Wordy.Services;
using Wordy.Words;

namespace Wordy.Levels
{
    public class LevelsHelper : BaseService
    {
        [HideInInspector] public LevelsHelperData LevelHelperData;

        public LevelBase CurrentLevel => currentLevel; private LevelBase currentLevel;

        public override void Initialize()
        {
            AddressableHelper.Load<LevelsHelperData>(AddressablePaths.DEFAULT_LEVELSHELPER_DATA, (levelHelperData) =>
            {
                LevelHelperData = levelHelperData;
                IsInitialized = true;
            });
        }

        public void SpawnDefaultLevel(Transform spawnParent)
        {
            AddressableHelper.Instantiate<LevelBase>(AddressablePaths.DEFAULT_LEVEL_TEMPLATE, spawnParent, Vector3.zero, Quaternion.identity, (level) =>
                {
                    currentLevel = level;
                    currentLevel.SetLevelConfig(LevelHelperData.DefaultLevelData);
                });
        }


    }
}