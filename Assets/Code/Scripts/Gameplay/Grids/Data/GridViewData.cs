using UnityEngine;
using Wordy.Grids;

namespace Wordy.Grids.Data
{
    [CreateAssetMenu(fileName = "GridViewData", menuName = "ScriptableObject/GridViewData")]
    public class GridViewData : ScriptableObject
    {
        public CellController CellPrefab;
        public float DistanceBetweenCells = 1;
    }
}
