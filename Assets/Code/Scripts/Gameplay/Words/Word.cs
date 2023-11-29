using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wordy.Grids;

namespace Wordy.Words.Data
{
    public class Word
    {
        public string Content;
        public bool IsFound;
        public List<Cell> Cells;

        public Word()
        {
            Content = string.Empty;
            IsFound = false;
        }

        public Word(string content) : this()
        {
            Content = content;
        }

        private void OnCellHighlighted(Cell cell)
        {
            if (Cells.Contains(cell))
            {
                CheckIfAllCellsHighlighted();
            }
        }

        private void CheckIfAllCellsHighlighted()
        {
            var highlightedCells = Cells.FindAll(c => c.IsHighlighted);

            if (highlightedCells.Count > 0)
            {
                Reveal();
            }
        }

        private void Reveal()
        {

        }

    }
}