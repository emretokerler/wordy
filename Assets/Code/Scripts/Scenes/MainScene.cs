using Wordy.Grids;

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
            var gridView = FindObjectOfType<GridView>();
            gridView.Initialize(new Grid(3,5));
        }
    }
}