using System;
using System.Collections.Generic;
using UnityEngine;
using Wordy.Resources;

namespace Wordy.Grids
{
    public class GridHelper : SingletonMonobehaviour<GridHelper>
    {
        public void CreateDefaultGridView(Transform parent, Action<GridView> OnComplete)
        {
            AddressableHelper.Instantiate<GridView>(AddressablePaths.DEFAULT_GRIDVIEW_PREFAB, parent ?? transform, Vector3.zero, Quaternion.identity, OnComplete);
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

        public static IEnumerable<Cell> GetGridTraverser(Grid grid, TraverseMethod method)
        {
            return new GridTraverser(grid, method);
        }
    }
}