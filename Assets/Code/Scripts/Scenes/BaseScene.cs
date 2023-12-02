using UnityEngine;
using Wordy.Events;
using Wordy.Levels;
using Wordy.Services.Events;

namespace Wordy.Services.Scenes
{
    public abstract class BaseScene : MonoBehaviour, IScene
    {
        protected SceneService sceneService => _sceneService ??= ServiceLocator.Current.Get<SceneService>(); private SceneService _sceneService;
        protected LevelsHelper levelService => _levelService ??= ServiceLocator.Current.Get<LevelsHelper>(); private LevelsHelper _levelService;

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
            if (ServiceLoader.Instance.IsAllServicesLoaded)
            {
                OnSceneLoaded();
            }
            else
            {
                ServiceLoader.Instance.LoadAllServices();
            }
        }

        private void OnEnable() => RegisterEvents();
        private void OnDisable() => UnregisterEvents();
        void RegisterEvents()
        {
            GameEvents.On<AllServicesLoadedEvent>(HandleAllServicesLoaded);
        }
        void UnregisterEvents()
        {
            GameEvents.Off<AllServicesLoadedEvent>(HandleAllServicesLoaded);
        }

        void HandleAllServicesLoaded(GameEvent e)
        {
            OnSceneLoaded();
        }
    }
}