using UnityEngine;
using Wordy.Resources;

namespace Wordy.Grids
{
    public class GridHelper : SingletonMonobehaviour<GridHelper>
    {
        public GridView CreateDefaultGridView()
        {
            AddressableHelper.Instantiate<GridView>(AddressablePaths.DEFAULT_GRIDVIEW_PREFAB, transform, Vector3.zero, Quaternion.identity, (gridView) =>
            {
                gridView?.Initialize(GetEmptyGrid(3, 3));
            });
            return null;
        }

        public Grid GetEmptyGrid(int width, int height)
        {
            return new Grid(width, height);
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