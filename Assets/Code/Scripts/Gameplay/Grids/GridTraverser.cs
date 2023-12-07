using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wordy.Grids
{
    public class GridTraverser
    {
        public Cell Current { get; private set; }
        private readonly Grid grid;
        private readonly TraverseMethod method;

        public GridTraverser(Grid grid, TraverseMethod method)
        {
            this.grid = grid;
            this.method = method;
        }

        public List<List<Cell>> GetTraverseList()
        {
            switch (method)
            {
                case TraverseMethod.Horizontal:
                    return TraverseHorizontal();
                case TraverseMethod.Vertical:
                    return TraverseVertical();
                case TraverseMethod.DiagonalLeft:
                    return TraverseDiagonalLeft();
                case TraverseMethod.DiagonalRight:
                    return TraverseDiagonalRight();
                case TraverseMethod.ReverseHorizontal:
                    return ReverseTraverseHorizontal();
                case TraverseMethod.ReverseVertical:
                    return ReverseTraverseVertical();
                case TraverseMethod.ReverseDiagonalLeft:
                    return ReverseTraverseDiagonalLeft();
                case TraverseMethod.ReverseDiagonalRight:
                    return ReverseTraverseDiagonalRight();
                default:
                    throw new System.NotImplementedException("Traversal method not implemented");
            }
        }

        private List<List<Cell>> TraverseHorizontal()
        {
            List<List<Cell>> cellRows = new();
            for (int y = 0; y < grid.Height; y++)
            {
                cellRows.Add(new());
                for (int x = 0; x < grid.Width; x++)
                {
                    cellRows[^1].Add(grid.GetCell(x, y));
                }
            }
            return cellRows;
        }

        private List<List<Cell>> TraverseVertical()
        {
            List<List<Cell>> cellColumns = new();
            for (int x = 0; x < grid.Width; x++)
            {
                List<Cell> column = new();
                for (int y = 0; y < grid.Height; y++)
                {
                    column.Add(grid.GetCell(x, y));
                }
                cellColumns.Add(column);
            }
            return cellColumns;
        }


        private List<List<Cell>> TraverseDiagonalLeft()
        {
            List<List<Cell>> diagonals = new();
            for (int layer = 0; layer < grid.Width + grid.Height - 1; layer++)
            {
                List<Cell> diagonal = new();
                int startX = layer < grid.Width ? layer : grid.Width - 1;
                int startY = layer < grid.Width ? 0 : layer - grid.Width + 1;

                for (int x = startX, y = startY; x >= 0 && y < grid.Height; x--, y++)
                {
                    diagonal.Add(grid.GetCell(x, y));
                }
                diagonals.Add(diagonal);
            }
            return diagonals;
        }


        private List<List<Cell>> TraverseDiagonalRight()
        {
            List<List<Cell>> diagonals = new();
            for (int layer = 0; layer < grid.Width + grid.Height - 1; layer++)
            {
                List<Cell> diagonal = new();
                int startX = Mathf.Min(layer, grid.Width - 1);
                int startY = Mathf.Min(layer, grid.Height - 1);

                for (int x = startX, y = startY; x >= 0 && y >= 0; x--, y--)
                {
                    diagonal.Add(grid.GetCell(x, y));
                }
                diagonals.Add(diagonal);
            }
            return diagonals;
        }


        private List<List<Cell>> ReverseTraverseHorizontal()
        {
            List<List<Cell>> cellRows = new();
            for (int y = grid.Height - 1; y >= 0; y--)
            {
                List<Cell> row = new();
                for (int x = grid.Width - 1; x >= 0; x--)
                {
                    row.Add(grid.GetCell(x, y));
                }
                cellRows.Add(row);
            }
            return cellRows;
        }


        private List<List<Cell>> ReverseTraverseVertical()
        {
            List<List<Cell>> cellColumns = new();
            for (int x = grid.Width - 1; x >= 0; x--)
            {
                List<Cell> column = new();
                for (int y = grid.Height - 1; y >= 0; y--)
                {
                    column.Add(grid.GetCell(x, y));
                }
                cellColumns.Add(column);
            }
            return cellColumns;
        }


        private List<List<Cell>> ReverseTraverseDiagonalLeft()
        {
            List<List<Cell>> diagonals = new();
            for (int layer = grid.Width + grid.Height - 2; layer >= 0; layer--)
            {
                List<Cell> diagonal = new();
                int startX = Mathf.Min(layer, grid.Width - 1);
                int startY = Mathf.Max(0, layer - grid.Width + 1);

                for (int x = startX, y = startY; x >= 0 && y < grid.Height; x--, y++)
                {
                    diagonal.Add(grid.GetCell(x, y));
                }
                diagonals.Add(diagonal);
            }
            return diagonals;
        }


        private List<List<Cell>> ReverseTraverseDiagonalRight()
        {
            List<List<Cell>> diagonals = new();
            for (int layer = grid.Width + grid.Height - 2; layer >= 0; layer--)
            {
                List<Cell> diagonal = new();
                int startX = Mathf.Max(0, layer - grid.Height + 1);
                int startY = Mathf.Min(layer, grid.Width - 1);

                for (int x = startX, y = startY; x < grid.Width && y < grid.Height; x++, y++)
                {
                    diagonal.Add(grid.GetCell(x, y));
                }
                diagonals.Add(diagonal);
            }
            return diagonals;
        }
    }

    public enum TraverseMethod
    {
        None = -1,
        Horizontal,
        Vertical,
        DiagonalLeft,
        DiagonalRight,
        ReverseHorizontal,
        ReverseVertical,
        ReverseDiagonalLeft,
        ReverseDiagonalRight
    }
}
