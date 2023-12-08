using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Wordy.Events;
using Wordy.Gameplay.Inputs.Events;
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
                // Debug.Log($"Cell: {cell.X}x{cell.Y} Anim1");
                yield return new WaitForSeconds(1);
            }
        }

        private void CheckWordCompleted(List<CellController> highlightedCells)
        {
            if (Cells == null || Cells.Count == 0) return;
            if (highlightedCells.Count != Cells.Count) return;
            foreach (var hc in highlightedCells)
            {
                if (!Cells.Contains(hc.Cell)) return;
            }

            Reveal();
        }

        public void Reveal()
        {
            if (IsRevealed) return;
            HandleWordRevealed(this);
            WordRevealedEvent.Trigger(this);
        }

        public char GetCharAt(int index)
        {
            return Content[index];
        }

        void RegisterEvents()
        {
            GameEvents.On<OnPointerUpEvent>(HandlePointerUp);
        }

        void UnregisterEvents()
        {
        }
       
        void HandlePointerUp(OnPointerUpEvent e)
        {
            CheckWordCompleted(e.HighlightedCells);
        }
    }
}