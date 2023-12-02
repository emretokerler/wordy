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
            currentGridView.Initialize(currentGrid);
            StartLevel();
        }

        public override void StartLevel()
        {

        }
    }
}