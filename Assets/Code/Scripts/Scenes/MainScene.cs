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
            GridHelper.Instance.CreateDefaultGridView();
        }
    }
}