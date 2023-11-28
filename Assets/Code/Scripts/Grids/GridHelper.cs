namespace Wordy.Grids
{
    public class GridHelper : SingletonMonobehaviour<GridHelper>
    {
        public void CreateTestCell()
        {

        }

        public GridView CreateGridView()
        {
            // var gridViewPrefab = 
            return null;
        }

        public Grid GetEmptyGrid()
        {
            return null;
        }

        private void FillWithBlankCells(Grid grid)
        {
            for (int x = 0; x < grid.Width; x++)
            {
                for (int y = 0; y < grid.Height; y++)
                {
                    grid.Cells[x, y] = new Cell(x, y, ' ');
                }
            }
        }
    }
}