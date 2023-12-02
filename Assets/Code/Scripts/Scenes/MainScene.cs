namespace Wordy.Services.Scenes
{
    public class MainScene : BaseScene
    {
        public override void OnSceneLoaded()
        {
            base.OnSceneLoaded();
            StartDefaultLevel();
        }

        void StartDefaultLevel()
        {
            levelService.SpawnDefaultLevel(transform);
        }
    }
}