using UnityEngine.SceneManagement;

namespace Wordy.Services.Scenes
{
    public class SceneService : BaseService
    {
        public override void Initialize()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            IsInitialized = true;
        }

        public void LoadScene(string name)
        {
            SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
        }

        public void UnloadScene(string name)
        {
            SceneManager.UnloadSceneAsync(name);
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            SceneManager.SetActiveScene(scene);
        }
    }
}