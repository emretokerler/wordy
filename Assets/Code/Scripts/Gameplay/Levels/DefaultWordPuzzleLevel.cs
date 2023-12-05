using UnityEngine;
using Wordy.Events;
using Wordy.Grids;
using Wordy.UI.Events;
using Grid = Wordy.Grids.Grid;

namespace Wordy.Levels
{
    public class DefaultWordPuzzleLevel : LevelBase
    {
        private Grid currentGrid;
        private GridView currentGridView;

        public override void InitializeLevel()
        {
            ClearPreviousGrid();

            currentGrid = gridHelper.CreateEmptyGrid(LevelConfig.GridWidth, LevelConfig.GridHeight);
            gridHelper.SpawnDefaultGridView(transform, OnGridViewSpawned);
        }

        private void ClearPreviousGrid()
        {
            if (currentGridView != null) Destroy(currentGridView.gameObject);
            currentGrid = null;
        }

        private void OnGridViewSpawned(GridView gridView)
        {
            currentGridView = gridView;
            currentGridView.Initialize(currentGrid);
            StartLevel();
        }


        public override void StartLevel()
        {

        }

        private void OnEnable() => RegisterEvents();
        private void OnDisable() => UnregisterEvents();
        void RegisterEvents()
        {
            GameEvents.On<LevelWidthDecreaseClickedEvent>(HandleLevelWidthDecreased);
            GameEvents.On<LevelWidthIncreaseClickedEvent>(HandleLevelWidthIncreased);
            GameEvents.On<LevelHeightDecreaseClickedEvent>(HandleLevelHeightDecreased);
            GameEvents.On<LevelHeightIncreaseClickedEvent>(HandleLevelHeightIncreased);
            GameEvents.On<RefreshClickedEvent>(HandleRefreshClicked);
            GameEvents.On<FindClickedEvent>(HandleFindClicked);
        }
        void UnregisterEvents()
        {
            GameEvents.Off<LevelWidthDecreaseClickedEvent>(HandleLevelWidthDecreased);
            GameEvents.Off<LevelWidthIncreaseClickedEvent>(HandleLevelWidthIncreased);
            GameEvents.Off<LevelHeightDecreaseClickedEvent>(HandleLevelHeightDecreased);
            GameEvents.Off<LevelHeightIncreaseClickedEvent>(HandleLevelHeightIncreased);
            GameEvents.Off<RefreshClickedEvent>(HandleRefreshClicked);
            GameEvents.Off<FindClickedEvent>(HandleFindClicked);
        }

        void HandleLevelWidthDecreased(LevelWidthDecreaseClickedEvent e)
        {
            Debug.Log(e.GetType().ToString());
        }
        void HandleLevelWidthIncreased(LevelWidthIncreaseClickedEvent e)
        {
            Debug.Log(e.GetType().ToString());
        }
        void HandleLevelHeightDecreased(LevelHeightDecreaseClickedEvent e)
        {
            Debug.Log(e.GetType().ToString());
        }
        void HandleLevelHeightIncreased(LevelHeightIncreaseClickedEvent e)
        {
            Debug.Log(e.GetType().ToString());
        }
        void HandleRefreshClicked(RefreshClickedEvent e)
        {
            Debug.Log(e.GetType().ToString());
        }
        void HandleFindClicked(FindClickedEvent e)
        {
            Debug.Log(e.GetType().ToString());
        }


    }
}