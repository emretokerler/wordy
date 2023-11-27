using Wordy.Services.Scenes.Data;
using UnityEngine;

namespace Wordy.Services.Scenes
{
    public abstract class BaseScene : MonoBehaviour, IScene
    {
        public SceneData SceneData;
        
        protected SceneService sceneService => _sceneService ??= ServiceLocator.Current.Get<SceneService>(); private SceneService _sceneService;
        protected GameObject sceneContent;

        public virtual void Initialize()
        {
            LoadObjects();
        }

        public virtual void LoadObjects()
        {
            if (!SceneData)
            {
                Debug.LogError("No scene data found!");
                return;
            }

            if (SceneData.SceneContent)
            {
                sceneContent = Instantiate(SceneData.SceneContent);
            }
            OnSceneLoaded();
        }

        public virtual void UnloadObjects()
        {
            if (sceneContent)
            {
                Destroy(sceneContent);
            }
            OnSceneUnloaded();
        }

        public virtual void OnSceneLoaded()
        {
            // onloadedevent
        }

        public virtual void OnSceneUnloaded()
        {
            // onunloadedevent
        }

        public virtual void Awake()
        {
            Initialize();
        }
    }
}