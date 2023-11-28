using TMPro;
using UnityEngine;

namespace Wordy.Grids
{
    public class CellController : MonoBehaviour
    {
        [SerializeField] private TextMeshPro letterTxt;
        
        public void Init(Cell cell)
        {
            letterTxt.text = cell.Letter.ToString();
        }
    }
}