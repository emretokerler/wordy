using System;
using System.Collections.Generic;
using UnityEngine;
using Wordy.Resources;
using Wordy.Services;

namespace Wordy.Grids
{
    public class GridHelper : BaseService
    {
        public override void Initialize()
        {
            IsInitialized = true;
        }

        public void SpawnDefaultGridView(Transform parent, Action<GridView> OnComplete)
        {
            AddressableHelper.Instantiate(AddressablePaths.DEFAULT_GRIDVIEW_PREFAB, parent, Vector3.zero, Quaternion.identity, OnComplete);
        }

        public Grid CreateEmptyGrid(int width, int height)
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

        public IEnumerable<Cell> GetGridTraverser(Grid grid, TraverseMethod method)
        {
            return new GridTraverser(grid, method);
        }
    }
}