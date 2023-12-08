using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Wordy.Events;
using Wordy.Grids;
using Wordy.Words.Events;

namespace Wordy.Words
{
    [System.Serializable]
    public class Word
    {
        public string Content;
        public bool IsRevealed;
        public List<Cell> Cells;
        public int Length => Content.Length;

        public Word()
        {
            Content = string.Empty;
            IsRevealed = false;
            Cells = new();
        }

        public Word(string content) : this()
        {
            Content = content;
            RegisterEvents();
        }

        private void HandleWordRevealed(Word word)
        {
            if (word == this)
            {
                IsRevealed = true;
                PlayRevealAnimation1();
            }
        }

        private void PlayRevealAnimation1()
        {
            CoroutineHelper.Run(CR_PlayRevealAnimation1());
        }

        private IEnumerator CR_PlayRevealAnimation1()
        {
            var cells = Cells.OrderBy(c => c.CellController.HighlightInfo.HighlightTime);

            foreach (var cell in cells)
            {
                // tweens
                Debug.Log($"Cell: {cell.X}x{cell.Y} Anim1");
                yield return new WaitForSeconds(1);
            }
        }

        private void CheckIfAllCellsHighlighted()
        {
            Debug.Log("checking for " + Content);
            var highlightedCells = Cells.FindAll(c => c.CellController.HighlightInfo.IsHighlighted);

            if (highlightedCells.Count >= Content.Length)
            {
                Reveal();
            }
        }

        private void Reveal()
        {
            HandleWordRevealed(this);
            WordRevealedEvent.Trigger(this);
        }

        public char GetCharAt(int index)
        {
            return Content[index];
        }

        void RegisterEvents()
        {
            GameEvents.On<CellHighlightedEvent>(HandleCellHighlighted);
        }
        void UnregisterEvents()
        {
            GameEvents.Off<CellHighlightedEvent>(HandleCellHighlighted);
        }

        private void HandleCellHighlighted(CellHighlightedEvent e)
        {
            if (Cells.Contains(e.Cell.Cell))
            {
                CheckIfAllCellsHighlighted();
            }
        }
    }
}