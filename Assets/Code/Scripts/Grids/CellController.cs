using TMPro;
using UnityEngine;

namespace Wordy.Grids
{
    public class CellController : MonoBehaviour
    {
        public Cell Cell;
        [SerializeField] private TextMeshPro letterTxt;
        
        public void Init(Cell cell)
        {
            Cell = cell;
            letterTxt.text = cell.Letter.ToString();
        }
    }
}