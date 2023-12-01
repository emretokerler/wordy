using System.Collections.Generic;
using UnityEngine;
using Wordy.Grids;
using Wordy.Words;
using Grid = Wordy.Grids.Grid;
namespace Wordy.Levels
{
    public class TestWordPuzzleLevel : LevelBase
    {
        private Grid currentGrid;
        private GridView currentGridView;

        public override void InitializeLevel()
        {
            ClearPreviousGrid();

            currentGrid = GridHelper.Instance.GetEmptyGrid(LevelConfig.GridWidth, LevelConfig.GridHeight);

            if (currentGridView != null) Destroy(currentGridView.gameObject);
            GridHelper.Instance.CreateDefaultGridView(transform, OnGridViewInitialized);
        }

        private void ClearPreviousGrid()
        {
            if (currentGridView != null) Destroy(currentGridView.gameObject);
            currentGrid = null;
        }

        void OnGridViewInitialized(GridView gridView)
        {
            currentGridView = gridView;
            StartLevel();
        }

        public override void StartLevel()
        {

        }
    }
}