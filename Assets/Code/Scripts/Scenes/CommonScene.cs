using Wordy.Utils;

namespace Wordy.Services.Scenes
{
    public class CommonScene : BaseScene
    {
        public override void OnSceneLoaded()
        {
            base.OnSceneLoaded();
            sceneService.LoadScene(Constants.MAIN_SCENE_NAME);
        }
    }
}
