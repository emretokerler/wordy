using System.Collections.Generic;
using UnityEngine;
using Wordy.Grids.Data;
using Wordy.Grids.Events;
using Wordy.Resources;

namespace Wordy.Grids
{
    public class GridView : MonoBehaviour
    {
        [HideInInspector] public GridViewData GridViewData;
        private Grid _grid;
        public int GridWidth => _grid.Width;
        public int GridHeight => _grid.Height;

        public void Initialize(Grid grid)
        {
            _grid = grid;

            AddressableHelper.Load<GridViewData>(AddressablePaths.DEFAULT_GRIDVIEW_DATA, (gridViewData) =>
            {
                GridViewData = gridViewData;
                CreateCells();
                GridViewInitializedEvent.Trigger(this);
            });
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

        public List<Vector3> GetCornerPoints()
        {
            var bounds = transform.GetMaxBounds();

            var corners = new List<Vector3>
            {
                new (bounds.max.x, 0, bounds.min.z),
                new (bounds.min.x, 0, bounds.max.z),
                new (bounds.min.x, 0, bounds.min.z),
                new (bounds.max.x, 0, bounds.max.z)
            };

            return corners;
        }
    }
}