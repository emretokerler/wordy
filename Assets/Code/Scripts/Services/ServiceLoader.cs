using System.Collections;
using UnityEngine;
using Wordy.Levels;
using Wordy.Services.Events;
using Wordy.Services.Scenes;

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
