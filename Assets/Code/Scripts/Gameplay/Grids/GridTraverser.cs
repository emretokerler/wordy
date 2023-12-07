using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        void ReverseCellList(List<Cell> list)
        {
            list.Reverse();
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
            List<List<Cell>> diagonals = new List<List<Cell>>();

            for (int start = 0; start < grid.Height + grid.Width - 1; start++)
            {
                List<Cell> diagonal = new List<Cell>();
                int x = start < grid.Height ? 0 : start - grid.Height + 1;
                int y = start < grid.Height ? grid.Height - 1 - start : 0;

                while (x < grid.Width && y < grid.Height)
                {
                    diagonal.Add(grid.GetCell(x, y));
                    x++;
                    y++;
                }
                diagonals.Add(diagonal);
            }
            return diagonals;
        }

        private List<List<Cell>> ReverseTraverseHorizontal()
        {
            var list = TraverseHorizontal();
            list.ForEach(ReverseCellList);
            return list;
        }

        private List<List<Cell>> ReverseTraverseVertical()
        {
            var list = TraverseVertical();
            list.ForEach(ReverseCellList);
            return list;
        }

        private List<List<Cell>> ReverseTraverseDiagonalLeft()
        {
            var list = TraverseDiagonalLeft();
            list.ForEach(ReverseCellList);
            return list;
        }

        private List<List<Cell>> ReverseTraverseDiagonalRight()
        {
            var list = TraverseDiagonalRight();
            list.ForEach(ReverseCellList);
            return list;
        }
    }

    public enum TraverseMethod
    {
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
