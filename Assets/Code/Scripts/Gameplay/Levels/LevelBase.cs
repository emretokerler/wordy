using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Wordy.Words;

namespace Wordy.Levels
{
    public abstract class LevelBase : MonoBehaviour, ILevel
    {
        public LevelData LevelConfig;
        public bool IsValid;
        public abstract void InitializeLevel();
        public abstract void StartLevel();

        public void SetLevelConfig(LevelData levelConfig)
        {
            LevelConfig = levelConfig;
            IsValid = Validate();
        }

        public bool Validate()
        {
            if (LevelConfig.Words == null) return false;
            if (LevelConfig.Words.Sum(w => w.Content.Length) < LevelConfig.GridWidth * LevelConfig.GridHeight) return false;
            if (LevelConfig.Words.Any(w => w.Content.Length < LevelConfig.GridHeight && w.Content.Length < LevelConfig.GridWidth)) return false;
            return true;
        }
    }
}