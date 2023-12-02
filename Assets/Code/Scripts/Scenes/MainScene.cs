using System.Linq;
using UnityEngine;
using Wordy.Grids;
using Wordy.Levels;
using Wordy.Words;
using Grid = Wordy.Grids.Grid;

namespace Wordy.Services.Scenes
{
    public class MainScene : BaseScene
    {
        public override void OnSceneLoaded()
        {
            base.OnSceneLoaded();
            StartDefaultLevel();
        }

        void StartDefaultLevel()
        {
            LevelsHelper.Instance.SpawnDefaultLevel();
        }
    }
}