using TMPro;
using UnityEngine;

namespace Wordy.Grids
{
    [SelectionBase]
    public class CellController : MonoBehaviour
    {
        public Cell Cell;
        [SerializeField] private TextMeshPro letterTxt;

        public void Init(Cell cell)
        {
            Cell = cell;
            letterTxt.text = cell.Letter.ToString();
        }

        private void HandleCellHighlighted()
        {
            Cell.IsHighlighted = true;
        }

        private void HandleCellUnhighlighted()
        {
            Cell.IsHighlighted = false;
        }

        private void OnMouseOver()
        {
            HandleCellHighlighted();
        }

        private void OnMouseExit()
        {
            HandleCellUnhighlighted();
        }
    }
}