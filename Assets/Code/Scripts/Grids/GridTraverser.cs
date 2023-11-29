using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wordy.Grids
{
    public class GridTraverser : IEnumerable<Cell>
    {
        public Cell Current { get; private set; }
        private readonly Grid grid;
        private readonly TraverseMethod method;

        public GridTraverser(Grid grid, TraverseMethod method)
        {
            this.grid = grid;
            this.method = method;
        }

        public IEnumerator<Cell> GetEnumerator()
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

        private IEnumerator<Cell> TraverseHorizontal()
        {
            for (int y = 0; y < grid.Height; y++)
            {
                for (int x = 0; x < grid.Width; x++)
                {
                    Current = grid.GetCell(x, y);
                    yield return Current;
                }
            }
        }

        private IEnumerator<Cell> TraverseVertical()
        {
            for (int x = 0; x < grid.Width; x++)
            {
                for (int y = 0; y < grid.Height; y++)
                {
                    Current = grid.GetCell(x, y);
                    yield return Current;
                }
            }
        }

        private IEnumerator<Cell> TraverseDiagonalLeft()
        {
            // Top-left to bottom-right
            for (int layer = 0; layer < grid.Width + grid.Height - 1; layer++)
            {
                int startX = layer < grid.Width ? layer : grid.Width - 1;
                int startY = layer < grid.Width ? 0 : layer - grid.Width + 1;

                for (int x = startX, y = startY; x >= 0 && y < grid.Height; x--, y++)
                {
                    Current = grid.GetCell(x, y);
                    yield return Current;
                }
            }
        }

        private IEnumerator<Cell> TraverseDiagonalRight()
        {
            // diagonal traversal starting from top-right
            for (int layer = 0; layer < grid.Width + grid.Height - 1; layer++)
            {
                int startX = Mathf.Min(layer, grid.Width - 1);
                int startY = Mathf.Min(layer, grid.Height - 1);

                for (int x = startX, y = startY; x >= 0 && y >= 0; x--, y--)
                {
                    Current = grid.GetCell(x, y);
                    yield return Current;
                }
            }
        }

        private IEnumerator<Cell> ReverseTraverseHorizontal()
        {
            for (int y = grid.Height - 1; y >= 0; y--)
            {
                for (int x = grid.Width - 1; x >= 0; x--)
                {
                    Current = grid.GetCell(x, y);
                    yield return Current;
                }
            }
        }

        private IEnumerator<Cell> ReverseTraverseVertical()
        {
            for (int x = grid.Width - 1; x >= 0; x--)
            {
                for (int y = grid.Height - 1; y >= 0; y--)
                {
                    Current = grid.GetCell(x, y);
                    yield return Current;
                }
            }
        }

        private IEnumerator<Cell> ReverseTraverseDiagonalLeft()
        {
            for (int layer = grid.Width + grid.Height - 2; layer >= 0; layer--)
            {
                int startX = Mathf.Min(layer, grid.Width - 1);
                int startY = Mathf.Max(0, layer - grid.Width + 1);

                for (int x = startX, y = startY; x >= 0 && y < grid.Height; x--, y++)
                {
                    Current = grid.GetCell(x, y);
                    yield return Current;
                }
            }
        }

        private IEnumerator<Cell> ReverseTraverseDiagonalRight()
        {
            for (int layer = grid.Width + grid.Height - 2; layer >= 0; layer--)
            {
                int startX = Mathf.Max(0, layer - grid.Height + 1);
                int startY = Mathf.Min(layer, grid.Width - 1);

                for (int x = startX, y = startY; x < grid.Width && y < grid.Height; x++, y++)
                {
                    Current = grid.GetCell(x, y);
                    yield return Current;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
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
