using UnityEngine;

namespace Wordy.Services.Grids.Data
{
    [CreateAssetMenu(fileName = "GridViewData", menuName = "ScriptableObject/GridViewData")]
    public class GridViewData : ScriptableObject
    {
        public GameObject CellPrefab;
        public float DistanceBetweenCells = 1;
    }
}
