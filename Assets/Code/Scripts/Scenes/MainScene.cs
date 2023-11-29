using System.Linq;
using UnityEngine;
using Wordy.Grids;
using Grid = Wordy.Grids.Grid;

namespace Wordy.Services.Scenes
{
    public class MainScene : BaseScene
    {
        public override void OnSceneLoaded()
        {
            base.OnSceneLoaded();
            CreateTestGrid();
        }

        private void CreateTestGrid()
        {
            GridHelper.Instance.CreateDefaultGridView();
            // var grid = new Grid(3, 3);
            // Debug.Log("Horizontal");
            // GridHelper.GetGridTraverser(grid, TraverseMethod.Horizontal).ToList().ForEach(x => Debug.Log($"x:{x.X} y:{x.Y}"));
            // Debug.Log("Vertical");
            // GridHelper.GetGridTraverser(grid, TraverseMethod.Vertical).ToList().ForEach(x => Debug.Log($"x:{x.X} y:{x.Y}"));
            // Debug.Log("Left Diagonal");
            // GridHelper.GetGridTraverser(grid, TraverseMethod.DiagonalLeft).ToList().ForEach(x => Debug.Log($"x:{x.X} y:{x.Y}"));
            // Debug.Log("Right Diagonal");
            // GridHelper.GetGridTraverser(grid, TraverseMethod.DiagonalRight).ToList().ForEach(x => Debug.Log($"x:{x.X} y:{x.Y}"));
        }

        
    }
}