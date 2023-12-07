using System.Collections;
using TMPro;
using UnityEngine;
using Wordy.Events;

namespace Wordy.Grids
{
    [SelectionBase]
    public class CellController : MonoBehaviour
    {
        public Cell Cell;
        public HighlightInfo HighlightInfo;
        [SerializeField] private TextMeshPro letterTxt;

        public void Init(Cell cell)
        {
            Cell = cell;
            cell.CellController = this;
            HighlightInfo = new();
            letterTxt.text = cell.Letter.ToString();
        }

        private void OnCellHighlighted(CellController cell)
        {
            if (cell == this)
            {
                HighlightInfo.IsHighlighted = true;
                HighlightInfo.HighlightTime = Time.time;
            }
        }

        private void OnCellUnhighlighted(CellController cell)
        {
            if (cell == this)
            {
                Cell.CellController.HighlightInfo.IsHighlighted = false;
            }
        }

        private void HighlightCell()
        {
            CellHighlightedEvent.Trigger(this);
        }

        private void UnhighlightCell()
        {
            CellUnhighlightedEvent.Trigger(this);
        }

        private void OnMouseOver()
        {
            if (!HighlightInfo.IsHighlighted)
            {
                HighlightCell();
            }
        }

        private void OnMouseExit()
        {
            if (!HighlightInfo.IsHighlighted)
            {
                UnhighlightCell();
            }
        }

        private void OnEnable() => RegisterEvents();
        private void OnDisable() => UnregisterEvents();
        void RegisterEvents()
        {
            GameEvents.On<CellHighlightedEvent>(HandleCellHighlighted);
        }
        void UnregisterEvents()
        {
            GameEvents.Off<CellHighlightedEvent>(HandleCellHighlighted);
        }

        void HandleCellHighlighted(CellHighlightedEvent e)
        {
            OnCellHighlighted(e.Cell);
        }

        void HandleCellUnhighlighted(CellHighlightedEvent e)
        {
            OnCellUnhighlighted(e.Cell);
        }
    }
}