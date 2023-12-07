using System.Linq;
using UnityEngine;
using Wordy.Grids;
using Wordy.Services;
using Wordy.Words;

namespace Wordy.Levels
{
    public abstract class LevelBase : MonoBehaviour, ILevel
    {
        protected WordsHelper wordsHelper => _wordsHelper ??= ServiceLocator.Current.Get<WordsHelper>(); private WordsHelper _wordsHelper;
        protected GridHelper gridHelper => _gridHelper ??= ServiceLocator.Current.Get<GridHelper>(); private GridHelper _gridHelper;
        public LevelData LevelConfig;
        public bool IsValid => Validate();
        public abstract void InitializeLevel();
        public abstract void StartLevel();

        public virtual void SetLevelConfig(LevelData levelConfig)
        {
            LevelConfig = levelConfig;
        }

        public virtual bool Validate()
        {
            if (LevelConfig.Words == null) return false;
            if (LevelConfig.Words.Sum(w => w.Content.Length) < LevelConfig.GridWidth * LevelConfig.GridHeight) return false;
            if (LevelConfig.Words.Any(w => w.Content.Length < LevelConfig.GridHeight && w.Content.Length < LevelConfig.GridWidth)) return false;
            return true;
        }
    }
}