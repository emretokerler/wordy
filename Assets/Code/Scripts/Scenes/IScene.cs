namespace Wordy.Services.Scenes
{
    public interface IScene
    {
        void Initialize();
        void LoadObjects();
        void UnloadObjects();
        void OnSceneLoaded();
        void OnSceneUnloaded();
    }
}