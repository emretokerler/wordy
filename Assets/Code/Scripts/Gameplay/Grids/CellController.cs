using System.Collections;
using TMPro;
using UnityEngine;
using Wordy.Events;
using Wordy.Gameplay.Inputs;
using Wordy.Gameplay.Inputs.Events;

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

        public bool IsNeigbourTo(CellController other)
        {
            if (this == other) return false;
            if (Mathf.Abs(Cell.X - other.Cell.X) <= 1 || Mathf.Abs(Cell.Y - other.Cell.Y) <= 1) return true;
            return false;
        }

        IEnumerator PlayHighlightedAnim1()
        {
            transform.position += Vector3.up * 0.2f;
            yield return null;
        }

        IEnumerator PlayUnhighlightedAnim1()
        {
            transform.position -= Vector3.up * 0.2f;
            yield return null;
        }

        private void OnCellHighlighted(CellController cell)
        {
            if (cell == this)
            {
                HighlightInfo.IsHighlighted = true;
                HighlightInfo.HighlightTime = Time.time;
                CoroutineHelper.Run(PlayHighlightedAnim1());

                Debug.Log(cell.Cell + " hihlight.");
            }
        }

        private void OnCellUnhighlighted(CellController cell)
        {
            if (cell == this)
            {
                Cell.CellController.HighlightInfo.IsHighlighted = false;
                CoroutineHelper.Run(PlayUnhighlightedAnim1());
            }
        }

        public void HighlightCell()
        {
            if (!HighlightInfo.IsHighlighted)
            {
                CellHighlightedEvent.Trigger(this);
            }
        }

        public void UnhighlightCell()
        {
            if (HighlightInfo.IsHighlighted)
            {
                CellUnhighlightedEvent.Trigger(this);
            }
        }

        private void OnEnable() => RegisterEvents();
        private void OnDisable() => UnregisterEvents();
        void RegisterEvents()
        {
            GameEvents.On<CellHighlightedEvent>(HandleCellHighlighted);
            GameEvents.On<CellUnhighlightedEvent>(HandleCellUnhighlighted);
        }
        void UnregisterEvents()
        {
            GameEvents.Off<CellHighlightedEvent>(HandleCellHighlighted);
            GameEvents.Off<CellUnhighlightedEvent>(HandleCellUnhighlighted);
        }

        void HandleCellHighlighted(CellHighlightedEvent e)
        {
            OnCellHighlighted(e.Cell);
        }

        void HandleCellUnhighlighted(CellUnhighlightedEvent e)
        {
            OnCellUnhighlighted(e.Cell);
        }
    }
}