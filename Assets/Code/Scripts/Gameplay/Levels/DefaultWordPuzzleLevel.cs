using UnityEngine;
using Wordy.Grids;
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
    }
}