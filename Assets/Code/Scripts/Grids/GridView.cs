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
            CreateCells();
        }

        private void CreateCells()
        {
            for (int x = 0; x < _grid.Width; x++)
            {
                for (int y = 0; y < _grid.Height; y++)
                {
                    var cellData = _grid.GetCell(x, y);
                    var cell = Instantiate(GridViewData.CellPrefab, transform);
                    cell.gameObject.name = GetCellName(cellData);
                    cell.transform.position = GetCellPosition(cellData);
                    cell.Init(cellData);
                }
            }
        }

        private Vector3 GetCellPosition(Cell cell)
        {
            var halfWidth = _grid.Width / 2f - 0.5f;
            var halfHeight = _grid.Height / 2f - 0.5f;
            var position = new Vector3(cell.X - halfWidth, 0, cell.Y - halfHeight);
            return position;
        }

        private string GetCellName(Cell cell)
        {
            return $"Cell-{cell.X + 1}x{cell.Y + 1}";
        }
    }
}