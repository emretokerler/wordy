using UnityEngine;

namespace Wordy.Services
{
    public static class SLBootstrapper
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Initialize()
        {
            ServiceLocator.Initialize();
            Debug.Log("service locator init");
        }
    }
}
