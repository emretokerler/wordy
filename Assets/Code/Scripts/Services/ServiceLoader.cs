using System.Collections;
using Wordy.Services.Events;
using Wordy.Services.Scenes;
using Wordy.Grids;
using Wordy.Levels;
using Wordy.Words;

namespace Wordy.Services
{
    public class ServiceLoader : SingletonMonobehaviour<ServiceLoader>
    {
        public bool IsAllServicesLoaded => ServiceLocator.Current != null && ServiceLocator.Current.IsAllServicesInitialized();

        public void LoadAllServices()
        {
            ServiceLocator.Initialize();
            
            ServiceLocator.Current.Register(new SceneService());
            ServiceLocator.Current.Register(new LevelsHelper());
            ServiceLocator.Current.Register(new WordsHelper());
            ServiceLocator.Current.Register(new GridHelper());

            WatchServiceInitializationStatus();
        }

        private void WatchServiceInitializationStatus()
        {
            StartCoroutine(CR_WatchServiceInitializationStatus());
        }

        private IEnumerator CR_WatchServiceInitializationStatus()
        {
            while (true)
            {
                if (ServiceLocator.Current.IsAllServicesInitialized())
                {
                    AllServicesLoadedEvent.Trigger();
                    yield break;
                }
                yield return null;
            }
        }
    }
}
