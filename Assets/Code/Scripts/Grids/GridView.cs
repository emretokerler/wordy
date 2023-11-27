using UnityEngine;
using Wordy.Services.Grids.Data;

namespace Wordy.Grids
{
    public class GridView : MonoBehaviour
    {
        public GridViewData GridViewData;
        private Grid _grid;

        public void Initialize(Grid grid)
        {
            _grid = grid;
        }

        private void CreateCells()
        {
            for (int x = 0; x < _grid.Width; x++)
            {
                for (int y = 0; y < _grid.Height; y++)
                {
                    var cellData = _grid.GetCell(x, y);
                    var cell = Instantiate(GridViewData.CellPrefab, transform.parent);
                    cell.transform.position = GetCellPosition(cellData);
                }
            }

        }

        private Vector3 GetCellPosition(Cell cell)
        {
            var halfWidth = _grid.Width / 2f;
            var halfHeight = _grid.Height / 2f;
            var position = new Vector3(cell.X - halfWidth, 0, cell.Y - halfHeight);
            return position;
        }
    }
}